#!/usr/bin/env python3

import sys, os

def main(cssfile):
    
    if '/united/' not in cssfile: return  # version used!
    badDD = 'dd{margin-left:0}'
    goodDD = 'dd{margin-left:20px}'
    with open(cssfile) as css:
        s = css.read()   
    if not badDD in s:
        print('target string not found', badDD)
    s=s.replace(badDD, goodDD)
        
    with open(cssfile, 'w') as f:
        f.write(s)
    print('css fix done in ' + cssfile)

if __name__ == '__main__':
    main(sys.argv[1])
