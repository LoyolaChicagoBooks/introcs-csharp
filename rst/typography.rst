.. index:: syntax template typography
   typography of syntax templates

.. _Syntax-Template-Typography:

Syntax Template Typography
==============================


When new C# syntax is introduced, the usual approach will be to
give both specific examples and general templates. In general
templates for C# syntax the typeface indicates the the category
of each part:

===================  ===================================================
Typeface             Meaning
===================  ===================================================
``Typewriter font``  Text to be written *verbatim*
**Bold**             A place where you can use an arbitrary
                     identifier. 
*Emphasized*         A place where you can use an arbitrary
                     expression (which might be a single variable name). 
Normal text          A description of what goes in that position,
                     without giving explicit syntax
===================  ===================================================

An attempt is made with the parts that are not verbatim to be
descriptive of the use expected.

As a start we can give some general syntax for declarations and assignment statements:


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