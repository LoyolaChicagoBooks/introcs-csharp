#!/usr/bin/env python3

'''
toggle conf.py so it comments out toggleline or not
'''

toggleline = r"html_theme_options = {'collapsiblesidebar' : True}"

def toggleComment():

    with open('conf.py') as f:
        s = f.read()
    commented = '#' + toggleline
    if commented in s:
       s = s.replace(commented, toggleline)
    else:
       s = s.replace(toggleline, commented)        
    with open('conf.py', 'w') as f:
        f.write(s)
        
toggleComment()
