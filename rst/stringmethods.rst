.. index::
   double: string; method

Some Instance Methods and the Length Property
=================================================

Thus far we have not emphasized the use of objects, or even noted 
what is an object.  Strings are a special type in C#. We have
used string literals as parameters to functions and we have used the 
special concatenation operator ``+``.
In fact strings are objects.  Like other objects,
strings have a general notation for functions that are specially tied to the 
particular type of object.  These functions are called *instance methods*.
They always act on an object of the particular class, but a reference to the
object is not placed inside the parameter list, but *before* the method name and
a dot as in::
 
   csharp> string s = "hello";
   csharp> s.ToUpper();
   "HELLO"

``ToUpper`` (converting to upper case) is particular action that makes sense
with strings.  It take s (the string object reference before the dot in this example)
and returns a new string (in upper case).  Since this action
depends only on the string itself, no further parameters are necessary,
and the parentheses after the method name are empty.  The general method syntax is

    *object-reference*\ ``.``\ **methodName** ``(``\ *further-parameters* ``)``

More string methods are listed below, some with further parameters.

.. skip?  
   
   We will see many types of objects that are *mutable*: the data inside the
   object can be changed.  This brings up many issues that will not arise with strings,
   because strings are "immutable." Once a string object is
   assigned a value, that particular object cannot be changed in any
   way, though many of the methods we look at will create *new* related strings.

   Although string assignment technically behaves differently than
   assigning to an ``int`` or a ``char``, We assign strings like we would data of a primitive type, like 
   an ``int`` or ``char``.


Data can also be associated with object *properties*.  
A property of a string is its length (an int).  References to property values
use dot notation but do not have a parameter list at the end::

    csharp> string s = "Hello";
    csharp> s.Length;
    5
    csharp> "".Length;
    0

Be careful: Though 5 is the length of ``s`` in the example above, 
the last character in ``s`` is ``s[4]``.  Using ``s[5]`` would generate
an ``IndexOutOfRangeException``.

String objects have associated string methods which can be used to
manipulate string values. 
There are an enormous number of string methods, but here are just a few
of the most common ones to get you started. The
string object to which the method is being applied is referred to as
**this** string in the descriptions.  After the methods, 
the length property is also listed.
In the heading *this* object is not shown explicitly, so be careful
when applying these methods and the length property: In actual use
they must be
preceeded by a reference to a string, followed by a dot, as shown in 
all the  examples.  The reference to *this* string can be
a variable name, a literal, or any expression evaluating to a string.

.. ugly!

   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | **String METHOD or PROPERTY**            | **DESCRIPTION**                                                                                                                                 | **EXAMPLE**                                                |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``int IndexOf(string string2)``          | returns the index of the begining of the first occurrence of the string ``string2`` in this string object. Returns -1 if ``string2`` not found. | ``string greeting = "Bonjour", word = "jou";``             |
   |                                          |                                                                                                                                                 |  ``greeting.IndexOf(word)`` returns 3.                     |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``string substring(int start)``          | returns the substring of this string object starting from index ``start`` through to the end of the string object.                              | ``string name = "Sheryl Crow";``                           |
   |                                          |                                                                                                                                                 |  ``name.Substring(7)`` returns the string ``"Crow"``       |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``string substring(int start, int len)`` | returns the substring of this string object starting from index ``start``, including a total of ``len`` characters                              | ``string name = "Sheryl Crow";``                           |
   |                                          |                                                                                                                                                 |  ``name.Substring(3,5)`` returns the string ``"ryl C"``    |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``string ToUpper()``                     | return this string converted to upper case.                                                                                                     | ``"Hi Jane!".ToUpper()`` returns the string ``"HI JANE!"`` |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``string ToLower()``                     | return this string converted to lower case.                                                                                                     | ``"Hi Jane!".ToLower()`` returns the string ``"hi jane!"`` |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+
   | ``int length``                           | refers to the length of this string object                                                                                                      | ``string greeting = "Bonjour";``                           |
   | (property)                               |                                                                                                                                                 |  ``greeting.Length( )`` returns the value 7.               |
   +------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------+------------------------------------------------------------+

.. _string-methods-length:

Summary of String Length and Some Instance Methods
----------------------------------------------------

``int IndexOf(string target)``
    Returns the index of the begining of the first occurrence of the 
    string ``target`` 
    in **this** string object. Returns -1 if ``target`` not found. Example:: 
    
        csharp> string greeting = "Bonjour", part = "jo";      
        csharp> greeting.IndexOf(part);
        3                     
        csharp> greeting.IndexOf("jot");
        -1

``string Substring(int start)``
    Returns the substring of **this** string object starting from index ``start`` 
    through to the end of the string object.  Example:
    
    ::    
    
        csharp> string name = "Sheryl Crow";                          
        csharp> name.Substring(7);
        "Crow"      

``string Substring(int start, int len)`` 
    Returns the substring of **this** string object starting from index ``start``, 
    including a total of ``len`` characters.  Example:
    
    ::   
    
        csharp> string name = "Sheryl Crow";``                         
        csharp> name.Substring(3,5);
        "ryl C"   

``string ToUpper()``   
    Return a string like **this** string, except all in upper case.  Example:: 
    
      csharp> "Hi Jane!".ToUpper(); 
      "HI JANE!"

``string ToLower()``
    Return a string like **this** string, except all in lower case.  Example:: 
    
        csharp> "Hi Jane!".ToLower();
        "hi jane!" 

``int Length``                           
    Property referring to the length of **this** string object. Example::
    
        csharp> string greeting = "Bonjour"; 
        csharp> greeting.Length;  //no parentheses
        7       

Further string methods are introduced in :ref:`more-string-methods`.


Testing Strings For Equality
------------------------------

Strings can be tested for equality like numbers,
with ``==``: *two* equal signs, not the *one* equal sign used for assignment.
The case of letters matters::

    csharp> string s = "Hello"; // initial value assigned
    csharp> string t = "HELLO";
    csharp> s == t;  // equality test
    false
    csharp> s.ToUpper() == t;
    true
    csharp> string u = "High".Substring(0,2); // assign
    csharp> u == "Hi"; // equality test
    true
    csharp> u == "High";
    false

Hence string expressions can be used in ``if`` statements.