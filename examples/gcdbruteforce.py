import sys

def gcd(a, b):
   n = max(a, b)
   g = i = 1
   while i <= n:
      if a % i == 0 and b % i == 0:
         g = i
      i = i + 1
   return g

a = int(sys.argv[1])
b = int(sys.argv[2])

print "gcd(%d, %d) = %d" % (a, b, gcd(a, b))

