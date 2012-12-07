.. index:: precedence

.. _precedence:

Precedence of Operators
==========================

Earlier lines have higher precedence.  
Only operators used in these notes are included:

..  code-block:: none

    obj.field  f(x)  a[i]  n++  n--  new
    +  -  ! (Type)x (Unary operators)   
    * / % 
    + - (binary)
    < > <= >=
    == !=
    &&
    ||
    =  *=  /=  %=  +=  -=  
    
Grouping parentheses are encouraged with less common combinations, even if
not strictly necessary.
