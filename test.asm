.data
string: .asciiz "0123456789abcdef"

.text
la $s1 string
addi $s1 $s1 1
lw $s2 0($s1)