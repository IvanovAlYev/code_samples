from time import sleep
from time import monotonic

import board
import busio
from digitalio import DigitalInOut
from digitalio import Direction

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
BOARD_ID=0x080 #ID узла
MSG_RECEIVE_ID=0x002 #ID принимаемого кадра

matches = [
        Match(MSG_RECEIVE_ID, mask=0x007),
        Match(MSG_RECEIVE_ID, mask=0x007),
        Match(0x000, mask=0x7FF),
    ]

#Индикация состояния миганием светодиода
blink_timer = monotonic()
current_state = "init"
blink_state_delay = {"init": 1}


#Имитация электромотора с датчиком угла поворота
rpm=1
ang=0
motor_timer = monotonic()

def signed_from_bytes(data):
    val = int.from_bytes(data, 'big')
    if val >= (1<<(len(data)*8 - 1)):
        return val - (1<<len(data)*8)
    else:
        return val

def mot_calc():
    global motor_timer, ang
    delta_time = monotonic() - motor_timer
    angle_change = (rpm / 60) * delta_time * 360
    ang = (ang + angle_change) % 360
    motor_timer = monotonic()
    

def blink_led():
    global blink_timer
    if(blink_timer+blink_state_delay[current_state])<monotonic():
        BUILTIN_LED.value = not BUILTIN_LED.value
        blink_timer=monotonic()
        
def send_rpm(len, id):
    res_id=(id&0x1c0)>>6
    data=int(round(rpm*1000))
    flg=True
    try:
        send_data=data.to_bytes(len, byteorder='big', signed=True)
    except OverflowError:
        flg=False
    if flg:
        mesg=Message(id=(BOARD_ID|res_id|0x008), data=send_data)
        can_bus.send(mesg)
        
def send_ang(len, id):
    res_id=(id&0x1c0)>>6
    if(len==2):
        send_data=(int(round(ang))).to_bytes(len, byteorder='big', signed=False)
    elif(len>2):
        send_data=(int(round(ang*10))).to_bytes(len, byteorder='big', signed=False)
    mesg=Message(id=(BOARD_ID|res_id|0x010), data=send_data)
    can_bus.send(mesg)


def bus_listen(bus_listener):
    global rpm
    message_count = bus_listener.in_waiting()
    for _i in range(message_count):
        msg = bus_listener.receive()
        if isinstance(msg, Message):
            if((msg.id & 0x038)==0x000):
                rpm=0;
                print('stop')
                print(monotonic())
            elif((msg.id & 0x038)==0x008):
                rpm=-rpm
            elif((msg.id & 0x038)==0x010):
                rpm=signed_from_bytes(msg.data)/1000
                print(rpm)
                print(monotonic())
        else:
            if((msg.id & 0x038)==0x018):
               send_rpm(msg.length, msg.id)
            elif((msg.id & 0x038)==0x020):
               send_ang(msg.length, msg.id)
                
                

#Инициализация
BUILTIN_LED.value = 1
sleep(0.5)
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
    mot_calc()