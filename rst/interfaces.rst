.. _Interface:

Interfaces
######################


.. add interface subparts   

   .. toctree::
      :maxdepth: 3

Fractions Revisited
=====================

C# has a built-in method to sort a List.  ``List`` is a
generic type, however, so how does C# know how to do 
comparisons for all different types?  Is this
specially programmed in for built-in types, or
can it be extended to user-defined types?

In fact it can be extended to user defined types,
such as our Rational.
To sort objects, you only need to be able to do one
thing: indicate which object comes before another.
We can do that.  The CompareTo method
already does that.  If Rational r1 is less than
Rational r2, then  ::

    r1.CompareTo(r2) < 0
    
The single CompareTo method is very versatile:  Just by varying
the comparison with 0, you vary the corresponding 
comparison of Rationals:

  | ``r1.CompareTo(r2) < 0`` means r1 < r2
  | ``r1.CompareTo(r2) <= 0`` means r1 <= r2
  | ``r1.CompareTo(r2) > 0`` means r1  > r2
  | ``r1.CompareTo(r2) >= 0`` means r1 >= r2
  | ``r1.CompareTo(r2) == 0`` means r1 is equal to r2
  | ``r1.CompareTo(r2) != 0`` means r1 is not equal to r2
  
None of the other mehtods for Rationals make any difference for
sorting:  Just this one method is needed.  Of course the
comparison of strings or doubles are done with 
totalluy idfferent implementations, but they have methods
with the same name, CompareTo, and with the same abstract
meaning.  Still C# is strongly typed and we are talking about
totally different types.

An *interface* allows us to group diverse classes under one
interface type.  An interface just focuses on the commonality of behavior
in one or more methods among the different classes.  In this case we are only concerned 
with one method, CompareTo.  We want it to be able to compare to another
object of the same type.  

C# defines an interface ``IComparable<T>``.  A type T can satisfy this interface if
if has a public instance method with signature::

	   public int CompareTo(T other);

There is one more step before we can use a library method to sort:  Although this is the
name that C# requires to be able to satisfy the ``Icomparable<T>`` interface, it does not
automatically assume that is your intention.  You must explicitly say you want your class
to be considered to satisfy this interface.  For instance for Rational, we need to change
the class heading to::

   public class Rational : IComparable<Rational>

In general one or more interface names can be listed after the class name and a  colon,
and before the opening brace of the class body.  This particular interface is defined in
System.Collections.Generic, so we ned to be using that namespace.

Project :file:`Interfaces/Rational` has the modified Rational and a :file:`Main.cs`
to test this with a list of Rationals.  This program:
   
.. literalinclude:: ../projects/Interfaces/Rational/Main.cs

which prints:

   | 11/3 2/5 2/3 1/3 
   | 1/3 2/5 2/3 11/3 

CSProj Revisited
==================

The CSProj1 skeleton was set up with the different commands
set up in different classes, keeping related things together.

On the other hand they had high level structure in common.  
Similar names were consciously used for methods:

- Each command needed to Execute 
- Each command needed to have Help for the user.

The corresponding names made it somewhat easier to follow 
the part of the Game constructor 
with the additions to the ``helpDetails`` Dictionary.
Also there is repetitive logic in 
the crucial ``proccessCommand`` method.

In a game with more possible commands, the code
would only get more repetitious!
You would like to think of having a loop to go through
repetitious code.  

A major use of a C# interface will allow this all to work.\
inneat loops.
For the first time we define our own interface, and 
use that interface as a type in a declaration.

While we are at this we can refactor our code further:  
classes that give a response to a command all obviously have their
Execute and Help methods.  They also have a command word 
to call them.  We can further encapsulate
all data for the response by having the classes themselves 
be able to announce the command that calls them.  
We add a string property CommandWord to each of them. 

We will add an extra convenience feature of C# here.
Thus far we have used private instance variables and public
getter methods.  We get use a public instance varaible declaration
with a similar effect as in::

          public string CommandName {get; private set;}

The extra syntax in braces says that users in a another class 
may freely *get* (read) the variable, but setting the variable is
still *private*: it may only be done inside the class.  This is more
concise than using a geter method:  No getter needs to be declared,
and referencint the data is shorter too, since it is a property,
no method parentheses are needed.  

Note the unusual syntax: the declaration does
not end with a semicolon.  The only semicolons are inside the braces.
You will not be required to code with this notation, but it sure is neater than
using a getter method!

Now we can define our own interface taking all of these common features
together.  Since each is a response to a command, we will call our interface
Response:

.. literalinclude:: ../projects/CSProj/CSProj/Response.cs

Things to note:

- The heading has the reserved word ``interface`` instead of class.  
- All the common method headings and the property declaration
  are listed.  
_ See what is missing!  In place of each method 
  body is just a semicolon.  
- Everything in an interface is public.
  The part of the property about private access is merely omitted.

We are going to need a collection if we want to simplify the code with
loops.  We could use code like the following, assuming we already declared
the objects helper, goer, and quitter::

    Response[] resp = {helper, goer, quitter};
    
See how we use Response as a declaration type!  Each of the objects in the declaration list *is*
in fact a Response.  

Now that we can process
with this collection and foreach loops, we do not need the object names we gave at all:
We can just put new objects in the initialization sequence!

Now that we can think of these different objects as being of the same type, we can see 
the processCommand logic, with its repetitive ``if`` statement syntax is just trying
to match a command word with the proper Response, so a Dictionary is what makes sense!

In fact all the logic for combining the various Responses in now moved into
ResponseMapper, and the the ResponseMapper constructor creates the Dictionary
used to look up the Response that goes with each command word.  Here is the whole code for 
ResponseMapper, taking advantage of the Dictionary in other methods, too.

.. literalinclude:: ../projects/CSProj/CSProj/ResponseMapper.cs

There is even more to recommend this setup:  The old setup had references in multiple places 
to various details about the collection of Responses.  That made it harder to follow and
definitely harder to update if you want to add an new command.  
Now after writing the new class to respond to a new command,  the *only* thing you
need to do is add a new instance of that class to the array initializer in the
CommandMapper constructor!

The revised MonoDevelop project is :file:`CSProj/CSProj` (no 1 this time).

See how the Game class is simplified, too.

Talking about adding commands - these classes could be the basis of a game project for
a small group.  Have any ideas? 

Interface Lab
================

.. todo::
   Interface lab
   
Final Project Assignment
========================

.. todo::
   Final Project
