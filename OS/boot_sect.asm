org 0x7c00
jmp main

os_text:
;db 2, ' ', 10, '#', 4, ' ', 11, '#', 2, ' ', 3, '#', 12, ' ', 11, '#', 2, ' ', 3, '#', 4, ' ', 2, '#',    1, 10, 1, 13
db 1, ' ', 12, '#', 3, ' ', 11, '#', 2, ' ', 3, '#', 12, ' ', 12, '#', 1, ' ', 3, '#', 3, ' ', 3, '#',    1, 10, 1, 13
db 1, ' ', 13, '#', 1, ' ', 13, '#', 1, ' ', 3, '#', 11, ' ', 12, '#', 2, ' ', 3, '#', 2, ' ', 3, '#',    1, 10, 1, 13
db 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 3, '#', 11, ' ', 3, '#', 11, ' ', 3, '#', 1, ' ', 3, '#',    1, 10, 1, 13
db 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 13, '#', 1, ' ', 3, '#', 11, ' ', 12, '#', 2, ' ', 6, '#',     1, 10, 1, 13
db 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 13, '#', 1, ' ', 3, '#', 11, ' ', 13, '#', 1, ' ', 5, '#',     1, 10, 1, 13
db 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 13, '#', 1, ' ', 3, '#', 11, ' ', 12, '#', 2, ' ', 6, '#',     1, 10, 1, 13
db 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 3, '#', 11, ' ', 3, '#', 11, ' ', 3, '#', 1, ' ', 3, '#',    1, 10, 1, 13
db 1, ' ', 13, '#', 1, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 12, '#', 2, ' ', 12, '#', 2, ' ', 3, '#', 2, ' ', 3, '#',     1, 10, 1, 13
db 1, ' ', 12, '#', 2, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 12, '#', 3, ' ', 12, '#', 1, ' ', 3, '#', 3, ' ', 3, '#',     1, 10, 1, 13
;db 1, ' ', 11, '#', 3, ' ', 2, '#', 9, ' ', 2, '#', 1, ' ', 12, '#', 3, ' ', 11, '#', 2, ' ', 3, '#', 4, ' ', 3, '#',     1, 10, 1, 13

db 3,10
;db 21, ' ', 11, '#', 3, ' ', 11, '#',     1, 10, 1, 13
db 21, ' ', 11, '#', 3, ' ', 12, '#',     1, 10, 1, 13
db 20, ' ', 13, '#', 1, ' ', 12, '#',     1, 10, 1, 13
db 20, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 3, '#',     1, 10, 1, 13
db 20, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 12, '#',     1, 10, 1, 13
db 20, ' ', 3, '#', 7, ' ', 3, '#', 1, ' ', 13, '#',     1, 10, 1, 13
db 20, ' ', 3, '#', 7, ' ', 3, '#', 2, ' ', 12, '#',     1, 10, 1, 13
db 20, ' ', 3, '#', 7, ' ', 3, '#', 11, ' ', 3, '#',     1, 10, 1, 13
db 20, ' ', 13, '#', 2, ' ', 12, '#',     1, 10, 1, 13
db 21, ' ', 11, '#', 2, ' ', 12, '#',     1, 10, 1, 13
;db 21, ' ', 11, '#', 3, ' ', 11, '#',     1, 10, 1, 13

db 0

print_c:
pusha
mov ah , 0x0e
print_c_loop:
mov cl , [bx]
cmp cl , 0
je print_c_exit
inc bx
mov al ,[bx]
print_c_loop_i:
int 0x10
dec cl
cmp cl, 0
jne print_c_loop_i
inc bx
jmp print_c_loop
print_c_exit:
popa
ret

print:
pusha
mov ah, 0x0e
print_loop:
mov al, [bx]
cmp al, 0
je print_exit
int 0x10
inc bx
jmp print_loop
print_exit:
popa
ret


main:
mov bx, os_text
call print_c

pusha
mov ah, 0x02
mov al, 3
;mov dl, [BOOT_DRIVE]
mov dh, 0x00
mov ch, 0x00
mov cl, 0x02
mov bx, 0x7e0
mov es, bx
xor bx, bx
int 0x13
popa


mov bx, text_gr
call print
mov ah, 0x01
mov cx, 0x2607
int 0x10
jmp enter_enter


times 510-($-$$) db 0
dw 0xaa55

text_gr:
db 10,10,10,'Enter enter to run the game :)', 0

text_game_start:
db 'Did you guess it yourself, or was it suggested by someone?',10,13, 'All right, here',39,'s a game for you.',10,13,'Press any key', 0

the_dalek_intro1:
db 10,10,10,10,10,13
times 20 db ' '
db 'THE DALEK 2 v0.1.5', 10
times 12 db 8
db 0
draw_dalek:
db '_n___n_',10
times 8 db 8
db '/       \---||--<',10
times 18 db 8
db '/_________\',10
times 11 db 8
db '_|___|___|_',10
times 11 db 8
db '_|___|___|_',10
times 10 db 8
db '|   |   |',10
times 10 db 8
db '------------',10
times 12 db 8
db '| || || || \',10
times 12 db 8
db '| || || || |\+++++-----<',10
times 24 db 8
db '=============',10
times 13 db 8
db '|  |  |  |  |',10
times 14 db 8
db '(|O | O| O| O|)',10
times 15 db 8
db '|  |   |   |  |',10
times 16 db 8
db '(|O | O | O | O|)',10
times 16 db 8
db '|  |   |   |   |',10
times 18 db 8
db '(|O |  O | O  | O|)',10
times 18 db 8
db '|  |    |    |   |',10
times 19 db 8
db '(|O |  O |  O |  O|)',10
times 20 db 8
db '====================',10,0

the_dalek_intro2:
db 10,10,13, 'Press any key', 0

rule:
db 'You should EXTERMINATE everything exept daleks',0

aim:
db '|',10,8,8,8,'-- --',10,8,8,8,'|',0

aim_pos:
db 5

shoot_trace:
db 0
shoot_draw:
db 70,'=',0
score:
db '0000',0
score_text:
db 'Score: ',0

target:
db 1,10,30
db '###',10,8,8,8,'# #',10,8,8,8,'###',0

enter:
db 'enter',0
enter_enter:
mov bx, enter
enter_enter_loop:
mov ah, 0x0
int 0x16
cmp al, [bx]
jne enter_enter
inc bx
mov al, [bx]
cmp al, 0
jne enter_enter_loop
jmp game_start

sleep:
pusha
mov ah, 0x86
int 0x15
popa
ret

target_update:
pusha
mov al, [target]
cmp al,0
je new_target
mov al, [target+2]
dec al
cmp al, 10
je lose
mov [target+2], al
jmp end_update
new_target:
mov al, 1
mov [target],al
;TODO random
mov al,10
mov [target+1],al
mov al,70
mov [target+2],al

end_update:
popa
ret

shoot_calc:
pusha
mov al, [target+1]
mov ah, [aim_pos]
cmp al, ah
jne calc_end
mov al, 0
mov [target],al


mov al,[score+3]
cmp al, '9'
je add32
inc al
mov [score+3],al
jmp calc_end
add32:
mov al, '0'
mov [score+3],al
mov al, [score+2]
cmp al, '9'
je add21
inc al
mov [score+2], al
jmp calc_end
add21:
mov al, '0'
mov [score+2],al
mov al, [score+1]
cmp al, '9'
je add10
inc al
mov [score+1], al
jmp calc_end
add10:
mov al, '0'
mov [score+1],al
mov al, [score]
cmp al, '9'
je add0
inc al
mov [score], al
jmp calc_end
add0:
mov al,'0'
mov [score],al

calc_end:
popa
ret

game_start:
mov ah, 0x0
mov al, 0x3
int 0x10
mov bx, text_game_start
call print
mov ah,0x0
int 0x16
mov bx, the_dalek_intro1
call print
mov bx, draw_dalek
call print
mov bx, the_dalek_intro2
call print
mov ah,0x0
int 0x16
mov ah, 0x0
mov al,0x3
int 0x10
mov bx, rule
call print
mov ah, 0x01
mov cx, 0x2607
int 0x10
mov ah,0x0
int 0x16

jmp draw

read_key:
mov cx,0
mov dx,3000
call sleep
mov ah, 1
int 0x16
jz no_keys
jmp key_down

game_loop:
jmp read_key
key_down:
cmp al, 's'
je aim_inc
cmp al, 'w'
je aim_dec
cmp al, ' '
je shoot
jmp skip1
aim_inc:
mov al, [aim_pos]
cmp al, 22
je skip1
inc al
mov [aim_pos], al
jmp skip1
aim_dec:
mov al, [aim_pos]
cmp al, 5
je skip1
dec al
mov [aim_pos], al
jmp skip1

shoot:
mov al, [shoot_trace]
cmp al, 0
jne skip1
mov al, 0x1
mov [shoot_trace], al
call shoot_calc
jmp skip1

skip1:

mov ah,0
int 0x16

no_keys:


call target_update
draw:
mov ah, 0x0
mov al,0x3
int 0x10
mov ah, 0x01
mov cx, 0x2607
int 0x10

mov bx, score_text
call print
mov bx, score
call print





mov ah, 0x02
mov bh, 0x0
mov dl, 2
mov dh, [aim_pos]
int 0x10
mov bx, aim
call print

mov ah, 0x02
mov bh, 0x0
mov dh, [target+1]
mov dl, [target+2]
int 0x10
mov bx, target+3
call print

mov al, [shoot_trace]
cmp al, 0
je no_shoot
dec al
mov [shoot_trace],al

mov ah, 0x02
mov bh, 0x0
mov dl, 10
mov dh, [aim_pos]
add dh, 1
int 0x10
mov bx, shoot_draw
call print_c


no_shoot:


mov cx,2
mov dx,0
call sleep


jmp game_loop

lose_text:
db 'You lose!',0;,10,13,'Press any key',0
lose:
mov ah, 0x0
mov al,0x3
int 0x10
mov ah, 0x01
mov cx, 0x2607
int 0x10
mov bx, lose_text
call print
lose_loop:
jmp lose_loop

times 2048-($-$$) db 0
