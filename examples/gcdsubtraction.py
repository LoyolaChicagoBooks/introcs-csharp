import sys

def gcdsubtraction(a, b):

   while a != b:
      print "convergence? a = %d, b = %d" % (a, b)
      while a > b:
        c = a - b
        a = c
        print "c = %d" % c
      print "new a? a = %d, b = %d" % (a, b)
      while b > a:
        c = b - a
        b = c
        print "c = %d" % c
      print "new b? a = %d, b = %d" % (a, b)

   # Just like the regular gcd(a, 0) = a
   return a

a = int(sys.argv[1])
b = int(sys.argv[2])
print "gcd = ", gcdsubtraction(a, b)
