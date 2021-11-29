.. index:: string; method
   single: . ; object field reference

Some Instance Methods and the Length Property
=================================================

Strings are a special type in C#. We have
used string literals as parameters to functions and we have used the 
special concatenation operator ``+``.
Thus far we have not emphasized the use of objects, or even noted 
what is an object.  In fact strings are objects.  Like other objects,
strings have a general notation for functions that are specially tied to the 
particular type of object.  These functions are called *instance methods*.
They always act on an object of the particular class, but a reference to the
object is not placed inside the parameter list, but *before* the method name and
a dot as in::
 
   csharp> string s = "hello";
   csharp> s.ToUpper();
   "HELLO"

``ToUpper`` (the method converting to upper case) 
does a particular action that makes sense
with strings.  It takes ``s`` 
(the string object reference before the dot in this example)
and returns a *new* string in upper case, based on ``s``.  Since this action
depends only on the string itself, no further parameters are necessary,
and the parentheses after the method name are empty.  The general method syntax is

    *object-reference*\ ``.``\ **methodName** ``(``\ *further-parameters* ``)``

More string methods are listed below, some with further parameters.

.. index:: property
   class; property
   
Data can also be associated with object *properties*.  
A property of a string is its ``Length`` (an ``int``).  References to property values
use dot notation but do not have a parameter list in parentheses at the end::

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
in your programs they must be
preceded by a reference to a string, followed by a dot, as shown in 
all the  examples.  The reference to *this* string can be
a variable name, a literal, or any expression evaluating to a string.

.. _string-methods-length:

Summary of String Length and Some Instance Methods
----------------------------------------------------

``int IndexOf(string target)``
    Returns the index of the beginning of the first occurrence of the 
    string ``target`` 
    in **this** string object. Returns -1 if ``target`` not found. Examples:: 
    
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
    
        csharp> string name = "Sheryl Crow";                         
        csharp> name.Substring(3,5);
        "ryl C"  
        
    Java programmers:  Note the second parameter is *not* the same as in Java. 

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

.. index:: immutable

..  warning::
    All of these methods that return a string return a *new* string.  No string method
    alters the original string.  Strings are *immutable*:  
    They are objects that cannot be changed
    after they are first produced.  This is a common source of errors.
    
::

    csharp> string s = "Hello";
    csharp> s.ToUpper()
    "HELLO"
    csharp> s
    "Hello"
    csharp> s = s.ToUpper();
    csharp> s
    "HELLO"    

See that you need an explicit assignment if you *want* the variable associated
with the original string to change.

Further string methods are introduced in :ref:`more-string-methods`.

Time to reflect, thinking back to :ref:`learn-solve`.  
Without forcing all the code details on yourself, 
how can you concisely say what powers you have with strings so far?  
Remember that kernel.

With strings you can: 
Index characters, find a part; extract a part; convert case; determine length.  
These may not be evocative phrases for you.  Find your own. 

When we get to loops, we will find this is useful.

Here is a brief example of a function using several of these methods,

:repsrc:`parenthesized/parenthesized.cs`: 
 
.. literalinclude:: ../../source/examples/parenthesized/parenthesized.cs
   :linenos:
 
It is a silly assumption, but until we get to :ref:`If-Statements`, 
we will have to assume there *is*
a parenthesized expression in the parameter string.


String Methods Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

a.  What is printed by this fragment?  ::

        string w = "quickly";
        Console.WriteLine(w.Length);
        Console.WriteLine(w[w.Length-2]);
        Console.WriteLine(w.Substring(3, 2));
        Console.WriteLine(w.Substring(2));
        Console.WriteLine(w.IndexOf("ti"));
        Console.WriteLine(w.IndexOf("ick"));
        int k = w.IndexOf("c");
        Console.WriteLine("{0} {1} {2} {3}", 
           k, w[k], w[k-3], w.Substring(k));

#.  What is printed by this fragment?  ::

        string s = "HELLO!", t = s.ToLower();
        Console.WriteLine(s+t);

Play with csharp:  Declare other strings and make up
string expressions with these methods 
for which you predict the value and then test.


