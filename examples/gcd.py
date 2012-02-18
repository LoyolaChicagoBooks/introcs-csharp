import sys

def gcd(a, b):
    if b == 0:
        print "gcd(%d, %d) = %d" % (a, b, a)
        return a
    else:
        print "gcd(%d, %d) = gcd(%d, %d \\bmod %d) = gcd(%d, %d)" % (a, b, b, a, b, b, a % b)
        return gcd(b, a % b)


x = sys.argv[1]
y = sys.argv[2]

if __name__ == '__main__':
    gcd( int(x), int(y) )
    
    
