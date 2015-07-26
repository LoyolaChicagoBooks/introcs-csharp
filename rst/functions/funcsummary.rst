

.. index::
   function; summary of syntax

.. _static-Function-summary:

Static Function Summary
==============================

This chapter has introduced static functions:  those used in procedural programming
as opposed to :ref:`instance-methods` used to 
implement object-oriented programming. 

References in square brackets link to fully discussions of summary items below.

.. index::  
   ( ); function definition


Function definition
-------------------

#. The general syntax for defining a static function is

    | ``static`` **returnTypeOrVoid** **FunctionName** ``(``  formal parameter list ``)``
    | ``{``
    |    statements in the function body...
    | ``}``
       
#. The *formal parameter list* can be empty or contain one or more comma separated 
   *formal parameter* entries.  [:ref:`Function-Parameters`] 
   Each formal parameter entry has the form
 
      **type** **parameterName**
      
#. If the function is going to be called from outside its class, the heading needs
   to start with ``public`` before the ``static``. [:ref:`library-classes`]
   
#. If **returnTypeOrVoid** in the heading is not ``void``, there must be a 
   *return statement* in the function body.  A return statement has the form

    ``return`` *expression* ``;``
    
   where the expression should be of the same type as in **returnTypeOrVoid**.
   Execution of the function terminates immediately when a return statement
   is reached. [:ref:`Returned-Function-Values`] 
   
#. Execution of a program starts at a function with a heading including

     ``static void Main``
   
   Thus far we have only discussed having an empty parameter list in the heading
   of the definition
   of ``Main``, and we defer discussion of :ref:`command-line-param` until
   we have introduced :ref:`one-dim-arrays`. 

#. There are various conventions for putting documentation just above the headings
   of function definitions.  The official format, specified by C# and recognized by
   Xamarin Studio, involves putting the function interface description on 
   consecutive lines
   starting with ``///``.  [:ref:`function-documentation`] 

.. index::  ( ); function call
   
Function Calls
---------------

#.  A function call takes the form

    **FunctionName** ``(``  actual parameter list ``)``
    
    A function call makes the function definition be *executed*.
    
#.  The actual parameter list is a comma separated list of the *same*
    length as the formal parameter list.  Each entry is an expression.
    The entries in an actual parameter list do *not* include type declarations.
    
    Effectively, the function execution starts by assigning to each
    formal parameter variable the corresponding value from 
    evaluating the actual parameter expression.
    In particular, that means the actual parameter values must be allowed
    in an assignment statement for a variable of the formal parameter's type!
    [:ref:`more-func-param`]
    
#.  If the function has return type ``void``, it can only be used syntactically
    as an entire statement (with a semicolon added). After the function
    call completes, execution continues with the next statement.
    
#.  If there is a non-void return type, then the function call is syntactically
    an expression in the statement where is appears.
    The execution of such a function must reach a return statement.  The value
    of the function-call expression is the value of the expression in this
    return statement.
    [:ref:`Returned-Function-Values`]  
    
#.  A function with a return value can also legally be used as a whole statement.
    In this case the return value is lost.  Though legal, this is often an error! 
    [:ref:`not-using-ret-val`]
    
Scope
------

#.  A variable declared inside a function definition is called a *local variable*.
    This declaration may be in either the formal parameter
    list or in the body of the function.  [:ref:`Local-Scope`]
    
#.  A local variable comes into existence after the function is called, and ceases
    to exist after that function call terminates.  A local variable is invisible
    to the rest of the program.  Its *scope* is just within that function.  Its
    lifetime is just through a single
    function call.  Its *value* may be transferred outside of the function scope
    by standard means, principally:  
    
    - If it is the expression in a return statement, its value is
      sent back to the caller.
    - It can be passed as an
      actual parameter to a further function called within its scope.
      
    [:ref:`Local-Scope`]
    
Static Variables
----------------

#.  There may be a declaration prefaced by the word ``static`` that appears 
    *inside* a class and *outside* of any function definition in the class.
    Static variables are visible within each function of the class, and may
    be used by the functions.  [:ref:`Static-Variables`]
    
#.  A common use of a static variable is to give a name to a constant 
    value used in multiple functions in the class.
    [:ref:`Static-Variables`] 
    