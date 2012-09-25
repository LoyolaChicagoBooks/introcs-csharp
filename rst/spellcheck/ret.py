import re

examples = '''ThisIsNotIt
thisIsItReally
twoWords
this_Is_Not
aOKOKisAok
notOK
and_
_and
and__b
a_and_b
two_words'''.split()

p1 = r'[a-z]+[A-Z]([a-z]*[A-Z])*[a-z]+[1-9]*'
p2 = r"^([A-Za-z]\w+[A-Z]+\w+)"
p3 = r'[a-z]+_([a-z]+_)*[a-z]+[1-9]*'

for p in [p1, p2, p3]:
    pattern = re.compile(p)
    print('\nUsing', p)
    for e in examples:
        print(e, bool(pattern.match(e)))
