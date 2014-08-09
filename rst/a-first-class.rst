.. index::  class; Contact
   Contact class 
   
.. _class:

A First Example of Class Instances: Contact 
============================================

Making a Datatype
--------------------

C# comes with lots of built-in datatypes, but not
everything we might want to use.  We start with a very simple example of
building your own new type of object:  Contact information for a person 
involves several pieces of data, and they are all unified by the fact
that they are for one person, so we would like to store them together
as a unit.  For simplicity, let us just consider the contact information to be
name, phone number, and email address.

You could always keep three independent string variables, 
but conceptually the main idea is *the* contact.  It just happens
to have parts.  

In order to treat a contact as  *one* entity, we create a ``class``, 
``Contact``. 
This way we can have a single
variable refer to a ``Contact`` object.

Later we will see an example, for rational
numbers, :ref:`rational`, 
where the parts are more tightly integrated, but that is more
complicated, so we defer it.

We have already considered built-in types with internal state, like a ``List``:   
Each ``List`` can contain different data, and the internal data can be changed.
 
The idea of creating a new type of object opens new ground for managing data.  
Thus far we have stored data as local variables, and we have called functions,
with two ways to get information in and out of functions:

#. In through parameters and out through returned data.
#. Directly via the user: in through the keyboard and out to the screen.

We have stored and passed around built-in types of object using this model.  

We have alternatives for storing and accessing data in the methods within
a new class we write.  
Now we have the idea of an object that has *internal* state
(like a contact with a name, phone, and email).  We shall see that
this state is *not* 
stored in local variables and does *not* need to be passed through parameters for 
methods *within* the class.  
Pay careful attention as we introduce this new location for data and the new ways
of interacting with it.

This is quite a shift.
*Do not take it lightly.*  

.. index:: OOP; constructor
   constructor
   new as operator
   operator; new 

We can create a new object with the ``new`` syntax.
We can give parameters defining the initial state of the new object.  
In our example the obvious thing to do is supply parameters giving
values for the three parts of the object state, so we can plan that ::

   Contact c = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@luc.edu");

would create a new Contact storing the data.

Like with built-in types, we can have the natural operations on the
type as *methods*.  For instance we can 

* look up individual pieces of the contact data with methods 
  ``GetName``, ``GetPhone`` and ``GetEmail``
* print it all out together, labeled, with method ``Print``.

Thinking ahead to what we would like for our Contact objects, here is
the testing code of :repsrc:`contact1/test_contact1.cs`:

.. literalinclude:: ../source/examples/contact1/test_contact1.cs

When running this testing code, we would like the results:

..  code-block:: none

    Marie's full name: Marie Ortiz
    Her phone number: 773-508-7890
    Her email: mortiz2@luc.edu
    
    Full contact info for Otto:
    Name:  Otto Heinz
    Phone: 773-508-9999
    Email: oheinz@luc.edu
	
We are using the same object oriented notation that we have for many other classes:
*Calls to instance methods are always attached to a specific object.*
That has always been
the object of

   *object*\ ``.``\ *method*\ ``(``  ... ``)``
   
So far we have been thinking and illustrating how we would like objects in this
Contact class to look like and behave from the *outside*.  We could be
describing another library class.  Now, for the first time, 
we start to delve inside,
to the code and concepts needed to make this happen.
We start with the most basic parts.  First we need a ``class``:

Class Syntax
--------------

Our code is nested inside ::

    public class Contact
    {
    
       // ... fields, constructor, code for Contact omitted
    
    }   
       
This is the same sort of wrapper we have used for our Main programs!  
*Before*, everything inside was
labeled ``static``.  Now we see what happens with the ``static`` keyword 
*omitted*....

.. index:: OOP; instance variable
   instance variable
   variable; instance
   private; instance variable
   
Instance Variables
----------------------

A Contact has a name, phone number and email address.  We must remember that data. 
Each individual Contact that we use will have its own 
name, phone number and email address.

We have used some static variables before in classes, with the keyword ``static``, 
where there is just one copy for the whole class.  If we omit the ``static`` we get
an *instance variable*, that is the particular data for an *individual* Contact.  
This is our new place to store data:

We declare these *in* the class and *outside* any method declaration. 
(This is in the same place as we would store :ref:`Static-Variables`).

They are *fields* of the class.  As we will
discuss more in terms of safety and security, 
we add the word "private" at the beginning::

    public class Contact
    {
       private string name;
       private string phone;
       private string email;
       
       // ... constructor, code for Contact omitted
    
    }   

You also see that we are lazy in this example,
and abbreviate the longer descriptions fullName, phoneNumber and
emailAddress.  

It is important to distinguish *instance* variables of a class 
and *local* variables.
A local variable is only accessible inside the one method where it was declared,
and is destroyed at the end of the method.  
However the class fields  ``name``, ``phone`` and ``email`` are remembered by C# 
as long as the Contact object is in use.  
This is a totally new situation.  We repeat:

.. note::
   *Instance* variable have a completely different lifetime and scope 
   from *local* variables.
   An object and its instance variables, 
   persist from the time a new object is created
   with ``new`` for as long as the object
   remains referenced in the program.
   
We need to get values into our field variables.  
They describe the state of our Contact.

We have *used* constructors for built-in types.  
Now for the first time we *create* one.

.. index:: OOP; constructor
   constructor

Constructors
----------------

The constructor is a slight variation on a regular method:  
Its name is the same as the
kind of object constructed, so here it is the class name, Contact. 
It has *no return type* (and *no* ``static``).  Implicitly you
are creating the kind of object named, a **Contact** in this case.
The constructor can have parameters like a regular method.  We will certainly
want to give a state to our new object.
That means giving values to its fields.  Recall we are want to
store this state in instance variables ``name``, ``phone`` and ``email``:  

.. literalinclude:: ../source/examples/contact1/contact1.cs
   :start-after: constructor 
   :end-before: getter

While the local variables in the formal parameters 
disappear after the constructor terminates,
we want the data to live on as the state of the object.
In order to remember state after the constructor terminates, 
we must *make sure the information gets into the instance variables* 
for the object.
This is the basic operation of most constructors:  Copy desired formal
parameters in to initialize the state in the fields.  That is all our simple
code above does.

Note that ``name``, ``phone`` and ``email`` are *not* declared as 
local variables.  They refer to the *instance* variables, but we are *not* using 
full object notation: an object reference and a
dot, followed by the field.  

So far always we have always been referring to a built-in type of object
defined in a different class, like ``arrayObject.Length``.  
The constructor is *creating* an object,
and the use of the bare instance variable names is understood to be giving 
values to the instance variables in this Contact object 
that is being constructed.
Inside a constructor 
and also inside an instance method 
(discussed below)
C# allows this shorthand notation without ``someObject.``.

.. index::  OOP; instance method
   instance method
   private; helping function
   method

.. _instance-methods:

Instance Methods
--------------------

The instance variable names and method names 
used without an object reference and dot refer to the 
*current* instance.  Whenever a constructor or non-static method in the class is called,
there is *always* a current object:

#.  In a constructor, referring to the object being created.  In execution, 
    a static method like ``Main`` must create the first object.
#.  When some instance method ``methodName`` is called with explicit dot notation, 
    ``someObject.methodName()``, 
    then it is acting on the current object ``someObject``.  In any program's
    execution the first call to an instance method must either be in this explicit
    form or from within a constructor for a new object.
#.  If that constructor or instance method calls a
    further instance method inside the same class, without using dot notation, 
    then the further method has the *same* current object....  
    We will see examples of this as we go along.

Again, this means that in execution, whenever an instance method is called,
there *is* a *current specific object*.  This is the object associated 
with any instance variable or method referred to in that method,
if there is not an explicit prefix in the ``someObject.`` form.  This will
take practice to get used to.

.. index:: OOP; getter
   getter method 

.. _getters:

Getters
--------

In instance methods
you have an extra way of getting 
data in and out of the method:  Reading or setting instance variables.  
(As we have just pointed out, in execution there will always be a current object 
with its specific state.)
The simplest methods do nothing but reading or setting instance variables.  
We start with those:

The ``private`` in front
of the field declarations was important to keep code outside the
class from messing with the values.  On the other hand we do want
others to be able to *inspect* the name, phone and email,
so how do we do that?  Use **public methods**. 

Since the fields are accessible anywhere *inside* the class's instance methods, 
and public methods can be used from *outside* the class, we can simply code

.. literalinclude:: ../source/examples/contact1/contact1.cs
   :start-after: getter
   :end-before: labels

These methods allow one-way communication of the name, phone and email 
values out from the object.
These are examples
of a simple category of methods:  A *getter* simply returns the value of a part
of the object's state, without changing the object at all.  

Note again that there is no ``static`` in the method heading.  
The field value for the *current* Contact is returned.

A standard convention that we are following:
Have getter methods names start with "Get", 
followed by the name of the data to be returned. 

In this first simple version of Contact we add one further method, to
print all the contact information with labels.

.. literalinclude:: ../source/examples/contact1/contact1.cs
   :start-after: labels
   :end-before: chunk

Again, we use the instance variable names, plugging them into a format string.  
Remember the ``@`` syntax
for multiline strings from :ref:`Strings2`.

You can see and see the entire Contact class 
in :repsrc:`contact1/contact1.cs`.

This is our first complete class defining a new type of object.  
Look carefully to get used to the features introduced, before we add
more ideas:

.. index:: example; Contact version 2

.. index:: OOP; this
   this instance 


This Object
-------------

We will be making an elaboration on the Contact class from here on.  We introduce
new parts individually, but the whole code is in 
:repsrc:`contact2/contact2.cs`.

The current object is *implicit* inside a constructor or instance method definition,
but it can be referred to *explicitly*.  It is called ``this``.  
In a constructor or instance method, ``this`` is automatically a legal
local variable to reference.  
You usually do not need to 
use it explicitly, but you could.   For example the current ``Contact`` object's
``name`` field could be referred to as either ``this.name`` or the shorter plain ``name``.
In our next version of the Contact class we will see several places where 
an explicit ``this`` is useful.

In the first version of the constructor, repeated here,

.. literalinclude:: ../source/examples/contact1/contact1.cs
   :start-after: constructor 
   :end-before: getter

we used different names for the instance variables and the formal
parameter names that we used to initialize the instance variables.  We
chose reasonable names, but we are adding extra names that we are not going
to use later, and it can be confusing.  The most obvious names for the formal
parameters that will initialize the instance variables are the *same* names.

If we are not careful, there is a problem with that.  An instance variable,
however named, and a local variable are not the same.  This is 
nonsensical::

      public Contact(string name, string phone, string email) 
      {
         name = name; // ????
         ...

Logically we want this pseudo-code in the constructor:

       instance variable ``name``  ``=`` local variable ``name`` 

We have to disambiguate the two uses.  The compiler always looks for
*local* variable identifiers *first*, so plain ``name`` will refer to the local 
variable ``name`` declared in the formal parameter list.  
This local variable identifier  *hides* the matching instance variable
identifier.  We have to do something else to refer to the instance variable.
The explicit ``this`` object comes to the rescue:  ``this.name`` refers to 
a part of this object.  It must refer to the 
instance variable, not the local variable.  Our alternate constructor is:

.. literalinclude:: ../source/examples/contact2/contact2.cs
   :start-after: constructor 
   :end-before: getter

Setters
---------

The original version of Contact makes a Contact object be
*immutable*:  Once it is created with the constructor, there is no way
to change its internal state.  The only assignments to the private
instance variables are the ones in the constructor.  In real life
people can change their email address.  We might like to allow that
with our Contact objects.  Users can read the data in a Contact with the 
*getter* methods.  Now we need *setter* methods.  The naming conventions
are similar:  start with "Set".  In this case we must supply the new data,
so setter methods need a parameter:

.. literalinclude:: ../source/examples/contact2/contact2.cs
   :start-after: setter methods
   :end-before: chunk

In ``SetPhone``, like in our original constructor, we illustrate using a
*new* name for the parameter that sets the instance variable.  For 
comparison we use the alternate identifier matching approach in the 
other setter:

.. literalinclude:: ../source/examples/contact2/contact2.cs
   :start-after: SetEmail
   :end-before: chunk

Now we can alter the contents of a Contact::

     Contact c1 = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@luc.edu");
     c1.SetEmail ("maria.ortiz@gmail.com");
     c1.SetPhone("555-555-5555");
     c1.Print(); 

would print

..  code-block:: none

    Name:  Marie Ortiz
    Phone: 555-555-5555
    Email: maria.ortiz@gmail.com


.. index::
   single:  ToString
   single:  override


ToString Override
---------------------

We created the ``Print`` method for a Contact, and it is helpful to
assemble all the data for display *and* print it.   The issue there is that
the method does two *separate* clear things:  combining the string data
and printing it.  You might want the same string but put in a file or 
used some other way.  Our ``Print`` method will not help.  

A good design decision is to separate the different actions:  the first is
to generate the 3-line string showing the full state of the object.  Once
we have this string, we can easily print it or write it to a file or ....
Hence we want a method to generate a descriptive string.

Think more generally about string representations:  
All the built-in types can be concatenated into strings with the '+' operator,
or displayed with ``Console.Write``.  
We would like that behavior with our custom types, too.  How can the compiler
know how to handle types that were *not invented* when the compiler was written?

The answer is to have common features among all objects.  
Any object has a ``ToString``
method, and that method is used implicitly when an object is used with
string concatenation, and also for ``Write``.
The default version supplied by the system is not very useful for an object 
that it knows nothing about!  You need to define your own version, 
one that knows how you have defined
your type, with its own specific instance variables. 
You need to have that version used *in place of* the default:
You need to *override* the default.  To emphasize the *change*
in meaning, the word ``override`` *must* be in the heading:

.. literalinclude:: ../source/examples/contact2/contact2.cs
   :start-after: ToString chunk
   :end-before: chunk

See what the method does:  it uses the object state to create and
*return* a single string representation of the object.  

For any kind of new object that you create and want to be able to implicitly convert to
a string, you need a ``ToString`` method with the *exact* same heading 
as the ``ToString`` for a Contact.    

A more complete discussion of ``override`` 
would lead us into class hierarchies and 
inheritance, which we are not emphasizing in this book.

We still might like to have a convenience method ``Print``.  It now can 
be written much more easily, using our latest ``ToString``.  

We want one instance method,
``Print`` to call another instance method ``ToString`` for the *same* object.
How does this work?  It is like when instance method ``GetName`` 
refers to an instance variable
``name`` without using dot notation.  Then ``name`` is assumed to refer to
this object associated with the call to ``GetName``.  We can change our
``Print`` definition to::

      public void Print()  
      {
         Console.WriteLine(ToString()); 
      }

Here ``ToString()`` is a method called without dot notation explicitly 
attaching it to an object.
As with instance variables, it is implicitly attached to this object, the one
attached to the call to ``Print``.
 
Again, the whole code for the elaborated Contact is in example
:repsrc:`contact2/contact2.cs`.

New testing code is in :repsrc:`contact2/test_contact2.cs`.  Run the project
and check that it does what you would expect.  There are several new 
features illustrated in the testing code:

.. literalinclude:: ../source/examples/contact2/test_contact2.cs
   :start-after: main chunk
   :end-before: chunk

Contact is now a type we can use with other types.  ``Main`` ends creating
a ``List<Contact>`` and an array of Contacts, and processes Contacts in the
``List`` with a ``foreach`` loop.

We mentioned that this particular signature in the
``ToString`` heading means that the system recognizes it in string
concatenation and in substitutions into a ``Write`` or ``WriteLine`` 
format string.  Find both in ``Main``.

The ``ToString`` override also means that the body of our ``Print`` 
definition in the Contact class could have been
even shorter, using the object ``this``::

      public void Print() 
      {
         Console.WriteLine(this); 
      }

When we ``Console.WriteLine`` this current object, which is not
already a string, there is an automatic call to ``ToString``.

.. index:: redeclaring instance variables error
   compiler error; before error in text
   instance variable; redeclaring error


.. _local-variables-hiding-instance-variables:

Local Variables Hiding Instance Variables
------------------------------------------

A common error is for students to try to declare the instance variables twice,
once in the regular instance variable declarations, 
*outside of any constructor or method* and then again *inside* a 
constructor, like::

      public Contact(string fullName, string phoneNumber, string emailAddress) 
      {
         string name = fullName;      // LOGICAL ERROR!
         string phone = phoneNumber;  // LOGICAL ERROR!
         string email = emailAddress; // LOGICAL ERROR
      }

This is deadly.  It is worse than redeclaring a local variable, which at least will 
trigger a compiler error.

..  warning::

    Instance variable *only* get declared outside of all
    functions and constructors.  Same-name 
    local variable declarations hide the
    instance variables, but *compile just fine*.  The local variables disappear
    after the constructor ends, leaving the instance variables 
    *without* your desired initialization. Instead the hidden instance variables 
    just get the default initialization, ``null`` for an object
    or 0 for a number.
    
There is a related strange compiler error.
Generally when you get a compiler error, the error is at or *before* the location the
error is referenced, but with local variables covering instance variables, 
the real cause can come later in the text of the method.  Below, when you first
refer to ``r`` in ``Badnames``, it appears to be correctly referring to the
instance variable ``r``::

    class ForwardError
    {
        private int r = 3;
        
        // ...
        
        void BadNames(int a, int b)
        {
            int n = a*r + b; // legal in text *just* to here; instance field r
            //...
            int r = a % b; // r declaration makes *earlier* line wrong
            //...
        }
    
The compiler scans through *all* of ``BadNames``, and sees the ``r`` declared locally
in its scope.
The error may be marked on the earlier line, where the compiler then assumes 
``r`` is the later declared local ``int`` variable, not the instance variable.
The error it sees is a local variable used before declaration. 

This is based on a real student example.  
This example points to a second issue: using variable names that 
that are too short and not descriptive of the variable meaning.

