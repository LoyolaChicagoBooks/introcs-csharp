#!/usr/bin/env python3

import sys
startFar = 0
startMissing = 0
endFar = 0

def fixTitlePage(s):
    #fix release, author

    with open('conf.py') as py:  # Python 2.6, not 3
        conf = py.read()

    start = "release = '"
    b = conf.index(start) + len(start)
    p = conf.index("'", b)
    ver = conf[b:p]
    print('ver =', ver)
    
    b = s.index(r'\release')
    p = s.index(r'\newcommand', b)
    print('>>>>>>>>>>old release\n' + s[b:p])

    s = (s[:b] +
         r'\release{' + ver +r'''} 
\authors{Drs. Andrew N. Harrington and George Thiruvathukal, Loyola University Chicago}
'''
         + s[p:])
    return s

def removeExtraContents(s):  ## not needed any more
    # remove repeat of stuff in index page in html
    b = s.index('Python 3.1 Version')
    p = s.index(r'\chapter', b)
##    print('>>>>>>>>old index page stuff\n' + s[b:p])

    s = s[:b] +  s[p:]
    return s

def removeSearch(s):
    '''remove final ch: index and search'''
    b = s.rfind(r'\chapter')
    p = s.rfind(r'\renewcommand')
    print('ending junked\n' + s[b:p])

    s = s[:b] +  s[p:]
    return s


def main(name):
##    input('\n !!!!! Starting fix in Python, Press return to continue....:  ')
    with open(name) as f:
        s = f.read()
    s0 = s
##    s = s.replace('↤', '$\\leftarrow$').replace('≠', '$\\neq$')
##    s = s.replace('≤', '$\\leq$').replace('≥', '$\\geq$')
##    s = fixTitlePage(s)
##    s = removeExtraContents(s)
    s = removeSearch(s)
    with open(name+'OLD', 'w') as f:
        f.write(s0)
    with open(name, 'w') as f:
        f.write(s)

if __name__ == '__main__':
    main(sys.argv[1])
