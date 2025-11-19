from time import sleep
from time import monotonic

import board
import busio
from digitalio import DigitalInOut
from digitalio import Direction

import adafruit_ssd1306

from adafruit_mcp2515 import MCP2515 as CAN

from adafruit_mcp2515.canio import Message, RemoteTransmissionRequest, Match




#Инициализация переменных
cs = DigitalInOut(board.GP5)
cs.switch_to_output()
spi = busio.SPI(board.GP6, board.GP7, board.GP4)
BUILTIN_LED = DigitalInOut(board.LED)
BUILTIN_LED.direction = Direction.OUTPUT


# xxB IDMs gMID
# xxx xxxx xxxx
BOARD_CON_ID=0x0C0 #ID узла контроллер
BOARD_LED_ID=0x100 #ID узла LED-экран
MSG_RECEIVE_CON_ID=0x003 #ID принимаемого кадра контроллер
MSG_RECEIVE_LED_ID=0x004 #ID принимаемого кадра LED-экран

MOTOR_BOARD_ID=0x080
MOTOR_ID=0x002

matches = [
        Match(MSG_RECEIVE_CON_ID, mask=0x007),
        Match(MSG_RECEIVE_LED_ID, mask=0x007),
        Match(0x000, mask=0x7FF),
    ]

#Индикация состояния миганием светодиода
blink_timer = monotonic()
current_state = "init"
blink_state_delay = {"init": 1}


#Контроллер электромотора
motor_timer=0
current_motor_state = "stop"
#stop runnig running_to_ang update req
state_update_delay = 1
ang_req=0
rpm_req=0


#Индикатор угла поворота
cur_ang=0
LED_timer=0
LED_update_delay=0.25

i2c = busio.I2C(board.GP9, board.GP8)


def signed_from_bytes(data):
    val = int.from_bytes(data, 'big')
    if val >= (1<<(len(data)*8 - 1)):
        return val - (1<<len(data)*8)
    else:
        return val


#основные сообщения
MSG_STOP = Message(id=(BOARD_CON_ID|MOTOR_ID|0x000), data=b"")
RTR_RPM = RemoteTransmissionRequest(id=(BOARD_CON_ID|MOTOR_ID|0x018), length=4)
RTR_ANG = RemoteTransmissionRequest(id=(BOARD_CON_ID|MOTOR_ID|0x020), length=3)
def MSG_TURN (rpm):
    _id=BOARD_CON_ID|MOTOR_ID|0x010
    if isinstance(rpm, bytearray):
        _data=rpm
    else:
        _data=(int(round(rpm*1000))).to_bytes(4, byteorder='big', signed=True)
    return Message(id=_id, data=_data)

RTR_LED_ANG = RemoteTransmissionRequest(id=(BOARD_LED_ID|MOTOR_ID|0x020), length=2)

def send(mesg):
    can_bus.send(mesg)
    

def motor_control():
    global current_motor_state
    if(current_motor_state=="running_to_ang"):
        if(motor_timer<=monotonic()):
            send(MSG_STOP)
            current_motor_state = "stop"
    

def motor_state_update():
    global current_motor_state, motor_timer
    if(current_motor_state=="stop")or(current_motor_state=="running"):
        if(motor_timer+state_update_delay)<monotonic():
            send(RTR_RPM)
            motor_timer=monotonic()
            current_motor_state="update"


def blink_led():
    global blink_timer
    if(blink_timer+blink_state_delay[current_state])<monotonic():
        BUILTIN_LED.value = not BUILTIN_LED.value
        blink_timer=monotonic()


def con_msg(msg):
    global ang_req,rpm_req, current_motor_state,motor_timer
    if(msg.id&0x1c0)==MOTOR_BOARD_ID:
        if current_motor_state=="update":
            if signed_from_bytes(msg.data)==0:
                current_motor_state="stop"
            else:
                current_motor_state="running"
        elif current_motor_state=="req":
            d_ang=(ang_req-int.from_bytes(msg.data,byteorder='big', signed=False)/10)%360
            d_time=d_ang/(rpm_req*6)
            current_motor_state="running_to_ang"
            send(MSG_TURN(rpm_req))
            motor_timer=monotonic()+d_time
    elif(msg.id&0x038)==0x000:
        send(MSG_STOP)
        current_motor_state = "stop"
    elif(msg.id&0x038)==0x008:
        send(MSG_TURN(msg.data))
        current_motor_state = "running"
    elif(msg.id&0x038)==0x010:
        ang_req=int.from_bytes(msg.data[0:4], 'big', signed=False)/10
        rpm_req=signed_from_bytes(msg.data[4:8])/1000
        current_motor_state="req"
        send(RTR_ANG)
            
    
    
def led_msg(msg):
    cur_ang=int.from_bytes(msg.data,byteorder='big', signed=False)
    display.fill(0)
    display.text(f"{cur_ang:03d}",5,10,1,size=2)
    display.show()
    

def LED_update():
    global LED_timer
    if(LED_timer+LED_update_delay)<monotonic():
        send(RTR_LED_ANG)


def bus_listen(bus_listener):
    message_count = bus_listener.in_waiting()
    for _i in range(message_count):
        msg = bus_listener.receive()
        if(msg.id&0x007)==MSG_RECEIVE_CON_ID:
            con_msg(msg)
        elif(msg.id&0x007)==MSG_RECEIVE_LED_ID:
            led_msg(msg)
            
                
                

#Инициализация
BUILTIN_LED.value = 1
sleep(0.5)

display = adafruit_ssd1306.SSD1306_I2C(128, 32, i2c)
display.fill(0)
display.show()

can_bus = CAN(spi, cs, loopback=False, silent=False,baudrate=250000)
listener = can_bus.listen(matches, timeout=0.1)

if (can_bus.state == 0):
    for i in range(7):
        BUILTIN_LED.value = (BUILTIN_LED.value + 1) % 2
        sleep(0.1)
        




#Рабочий цикл
while True:
    blink_led()
    bus_listen(listener)
    motor_control()
    motor_state_update()
    LED_update()