.. index:: syntax templates
   reading syntax templates

.. _Reading-CSharp-Syntax:

Reading C# Syntax Templates
===========================


When new C# syntax is introduced, this book usually gives both
specific examples and general syntax templates. In these templates,
the typeface shows the role of each part:

===================  ===================================================
Typeface             Meaning
===================  ===================================================
``Typewriter font``  Text to be written exactly as shown
**Bold**             A place where you can use an arbitrary
                     identifier. 
*Emphasized*         A place where you can use an arbitrary
                     expression (which might be a single variable name). 
Normal text          A description of what goes in that position,
                     without giving explicit syntax
===================  ===================================================

Parts that are not written exactly as shown are named descriptively,
based on how they are used in the syntax.

As a start, here is the general syntax for declarations and assignment
statements:


.. index:: statement; declaration
   declaration statement

Declaration Syntax Options
---------------------------

    **type** **variableName** ``;``

or with initialization:

    **type** **variableName** ``=`` *initialValue* ``;``

or there can be a list of variables of the same type, for instance a list
of three variables:

    **type** **variableName1** ``,`` **variableName2** ``,`` **variableName3** ``;``

Some or all of the variables in the list could also have initializers.

Space is allocated for each variable named, according to its type.  Where there is
an initializer, an initial value is set for the variable.


.. index:: assignment statement
   statement; assignment

Assignment Syntax
------------------

    **variableName** ``=`` *expression* ``;``

The *expression* is evaluated before its value is assigned to **variableName**.
