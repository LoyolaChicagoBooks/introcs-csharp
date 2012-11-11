.. index::
   double: syntax template; typography

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


.. index:: declaration statement

Declaration Syntax Options
---------------------------

    **type** **variableName** ``;``

or with initialization:

    **type** **variableName** ``=`` *initialValue* ``;``

or both forms can be included in a list for the same type, for instance a list
of three variables:

    **type** **variableName1** ``,`` **variableName2** ``,`` **variableName3** ``;``


.. index:: assignment statement

Assignment Syntax
------------------

**variableName** ``=`` *expression* ``;``

