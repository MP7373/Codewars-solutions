#https://www.codewars.com/kata/556b85b433fb5e899200003f/train/python
def mixed_fraction(s):
    x_and_y = s.split('/')
    x = int(x_and_y[0])
    y = int(x_and_y[1])
    if abs(x) / abs(y) < 1 and x * y < 0:
        i = 2
        while i * i <= x or i * i <= y:
            if x % i == 0 and y % i == 0:
                x = x / i
                y = y / i
                i = 2
            else:
                i = i + 1
        return '-' + str(int(abs(x))) + '/' + str(int(abs(y)))
    else:
        a = int(x / y)
        if a > 0:
            a = str(a) + ' '
            sign = ''
            b = abs(x % y)
        elif a == 0:
            a = ''
            sign = ''
            b = abs(x % y)
        else:
            a = str(abs(a)) + ' '
            sign = '-'
            b = abs(-x % y)
        c = abs(y)
        i = 2
        while i * i <= b or i * i <= c:
            if b % i == 0 and c % i == 0:
                b = b / i
                c = c / i
                i = 2
            else:
                i = i + 1
        if a == '' and b == 0:
            return '0'
        elif b == 0:
            return sign + a.strip()
        else:
            return sign + a + str(int(b)) + '/' + str(int(c))