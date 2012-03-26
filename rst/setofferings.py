#!/usr/bin/env python3

'''include anh specific stuff for sphinx build or not
Behaves one way if anh is passed as the user, other way if not.
'''

import sys

def fixOfferings(s, anhMode):
    iOfferings = s.find('offerings')
    hasOfferings = iOfferings >= 0
    iContext = s.find('context')
    iData = s.find('data')
    if iContext < 0 or iData < 0:
        print ('Bad index file missing context or data')
        return s
    
    if anhMode and hasOfferings:
        s = s[:iOfferings] + s[iContext:]
        print("Removing offerings")
    elif not anhMode and not hasOfferings:
        s = (s[:iContext] +
             s[iContext:iData].replace('context', 'offerings') + #keeps indent
             s[iContext:])
        print("Adding offerings")
    return s

def main():
    args = sys.argv[1:]
    if not args:
        print('''ERROR: usage: setofferings.py user [no]
        user is anh (or not); 'no' reverses the user.''')
    user = args[0]
    noFlag = len(args) > 1 and args[1].lower().startswith('n')
    anhMode = (user == 'anh') ^ noFlag

    with open('index.rst') as inf:
        s = inf.read()

    sNew = fixOfferings(s, anhMode)
    if s != sNew:
        with open('index.rst', 'w') as outf:
            outf.write(sNew)

main()
