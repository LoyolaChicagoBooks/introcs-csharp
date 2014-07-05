Class Instance Examples
========================

.. index:: exercise; getters and setters

More Getters and Setters
-------------------------

As an exercise you could write a simple class Example, with

#. ``int`` instance variable ``n`` and ``double`` instance variable ``d``
#. a simple constructor with parameters to set instance variables 
   ``n`` and ``d``
#. getters and setters for both instance variables (4 methods in all)
#. a ToString that prints a line with both instance variables labeled.

Compare yours to
:repsrc:`example_class/example_class.cs`. 

We include a testing class at the end of this file.  

.. literalinclude:: ../source/examples/example_class/example_class.cs
   :start-after:  test class


Besides the obvious tests, we also use
the fact that an Example object is mutable to play with  :ref:`alias`:  
In the
last few lines of ``Main``, after ``e`` becomes an alias for ``e2``, 
we change
an object under one name, and it affect the alias the same way.
Check this by running the program!

Make sure you can follow the code and the output from running.  


Converting A Static Game To A Game Instance
----------------------------------------------

For a comparison of procedural and object-oriented coding,
consider converting :ref:`lab-number-game` so that a GuessGame
is an object, an instance of the GuessGame class.

While our last example, Contact, is a simple but practical 
use of object-oriented programming, GuessGame is somewhat more artificial.  
We create it hoping that highlighting the differences between procedural 
and object-oriented presentation is informative.  Also, we will see 
with :ref:`interface` that
there are C# language features that require an
object rather than just a function and data.  
In :ref:`igame-interface-exercise` you can use a Game object.

Here is a procedural game version, example file 
:repsrc:`static_version/static_version.cs`

.. literalinclude:: ../source/examples/static_version/static_version.cs
   :start-after:  chunk
   :end-before: chunk

The project also refers to the library class UI, 
with the functions we use for safe
keyboard input.  It is all static methods.  

Is there any reason to make this UI class have its own own instances?

**No**.  There is no state to remember between UI method calls.  
What comes in through
the keyboard goes out through a return value, 
and then you are completely done with it.  
A simple static function works fine each time.  
*Do not get fancy for nothing*.

What state would a game hold?  We might set it up so the user
chooses the size of the range of choices just once, and remember it 
for possibly multiple plays of the GuessGame.  The variable was
``big`` before, we can keep the name.  
If we are going to remember it inside our GuessGame instance, 
then ``big`` needs to become an instance variable, and it will be something
we can set in a constructor.

What actions/methods will this object have?  Only one - playing a GuessGame.
The GuessGame could be played multiple times, and that action, play, 
makes sense as a method, Play, which will look a lot like the current 
static function. 

In the procedural version there are several other important variables:

- Random rand:  That was static before, for good reason: 
  We only need one Random number generator for the whole
  time the program is running, so one static variable makes sense.
- The central number in the procedural Game 
  and our future Play method is ``secret``.
  Should that be an instance variable?  It would work, but it would
  be unhelpful and misleading:  Secret is reset every time the game is played,
  and it has no meaning after a Play function would be finished.  
  There is nothing to
  remember *between* time you Play.  This is the
  perfect place for a local variable *as we have now*.  
  
A common newbie error is to make things
into instance variables, just because you can, when an old-fashioned
local variable is all that you need.  It is good to have variables leave the
programmer's consciousness when they are no longer needed, 
as a local variable does.  
An instance variable lingers on, leaving extra places to make errors.

This introductory discussion could get you going, making a transformation.  
Go ahead and make the changes as far as you can: 
create project GuessGame inside the current solution.
Have a class GuessGame for the GuessGame instance, 
with instance variable ``big`` and method ``Play``.

You still need a static ``Main`` method to first create the GuessGame object.  
You could prompt the user for the value for ``big`` to send to the constructor.  
Once you have an object, you can call *instance method* ``Play``.  
What about parameters? What needs to change?

There is also a video for this section that 
follows all the way through the steps.
A possible final result is in :repsrc:`instance_version/guess_game.cs`.

.. _animal-lab:

Animal Class Lab
------------------

**Objectives**:
Complete a simple (silly) class, with constructor and methods,
including a ``ToString`` method, and a separate testing class.

Make an animal_lab project in your solution, 
and copy in the files from the example
project :repsrc:`animal_lab_stub`.  
Then modify the two files as discussed below.

#. Complete the simple class Animal in your copy of the file 
   :repsrc:`animal.cs <animal_lab_stub/animal.cs>`.  
   The bullets below
   name and describe the instance variables, constructor, 
   and methods you need to write:

   * An Animal has a ``name`` and a ``gut``.  
     In our version the ``gut`` is a List of strings 
     describing the contents, in the order eaten.  
     A newly created Animal gets a ``name`` from a parameter
     passed to the constructor, while the ``gut`` always starts off *empty*.
    
   * An Animal has a ``Greet`` method, so an animal named "Froggy" would say 
     (that is, print) 
        
        Hello, my name is Froggy.
    
   * An Animal can ``Eat`` a string naming the food, 
     adding the food to the ``gut``.
     If Froggy eats "worm" and then "fly", its ``gut`` list contains
     "worm" and "fly".
    
   * An Animal can ``Excrete`` 
     (removing and printing what was *first* in the gut List). 
     Recall the method ``RemoveAt`` in :ref:`listsyntax`.  Print the
     empty string, "", if the ``gut``
     *was already empty*.  Following the
     Froggy example above, Froggy could ``Excrete``, 
     and "worm" would be printed.
     Then its ``gut`` would contain only "fly". 
      
   * A ``ToString`` method: 
     Remember the ``override`` keyword.  Make it return a string in the format
     shown below for Froggy, including the Animal's name: 
      
         "Animal: Froggy"
         
     Try this first, and note the extra credit version below.
         
   * All the methods that print should be void.  
     Which need a parameter, of what type?

#. Complete the file :repsrc:`test_animal.cs <animal_lab_stub/test_animal.cs>` 
   with its class ``TestAnimal`` containing the 
   ``Main`` method, testing the class Animal: 
   Create a couple of Animals and visibly test all the methods, 
   with enough explanation that someone running the test program, 
   but *not* looking at the code of either file, can see that everything works.

#. 20% EXTRA CREDIT:  Elaborate ``ToString`` so if Froggy had "worm", "fly"
   and "bug" in the gut, the string would be:
   
       "Animal: Froggy ate worm, fly and bug"  
       
   with a comma separated list of the gut contents, except use proper English,
   so the last separator
   is " and ", not ", ". 
   If the gut has nothing in it, list the contents as "nothing":
    
       "Animal: Froggy ate nothing"  
       

