Class Examples
================================

Getters and Setters
--------------------

Our class Rational in :repsrc:`rational_nunit/rational.cs` is a
practical utility class.  We used it as a first example to avoid being artificial,
and illustrate many points.  One choice we made for it to be practical, is to have
``Rational`` objects be immutable.  Though we constructed Rationals and used them,
there was no public code that modified a Rational.  We discussed :ref:`getters`.
For mutable objects, another basic kind of method is a *setter*, 
that sets an attribute of the object's state, changing it from what it was before.

This time we have a nonsensical but very simple class to illustrate the use of
both getters and setters, example 
:repsrc:`example_class/example_class.cs`:

.. literalinclude:: ../source/examples/example_class/example_class.cs

Make sure you can follow the code and the output from running.

Converting A Static Game to A Game Instance
----------------------------------------------

For a comparison of procedural and object-oriented coding,
consider converting :ref:`lab-number-game` so that a Game
is an instance.

While our last example, Rational, is in fact a very practical 
use of object-oriented programming, this is somewhat more artificial,
but hopefully informative, particularly with the transformation.
Here is a procedural version, example file 
:repstr:`static_version/static_version.cs`

.. literalinclude:: ../source/examples/static_version/static_version.cs
   :start-after:  chunk
   :end-before: chunk

The project also refers to the library class UI, with the functions we use for safe
keyboard input.  It is all static methods.  Is there any reason to make this
class have its own own instances?

**No**.  There is no state to remember between UI method calls.  What comes in through
the keyboard goes out through a return value, and you are done with it.  
A simple static function works fine each time.  *Do not get fancy for nothing*.

What state would a game hold?  We might set it up so the user
chooses the size of the range of choices just once, and remember it 
for possibly multiple plays of the Game.  The variable was
``big`` before, we can keep the name.  
If we are going to remember it inside our Game instance, 
then ``big`` needs to become an instance variable, and it will be something
we can set in a constructor.

What actions/methods will this object have?  Only one - playing a Game.
The Game could be played multiple times, and that action, play, 
makes sense as a method, Play, which will look a lot like the current 
static function. 


In the procedural version there are several other important variables:

- Random rand:  That was static before, for good reason: 
  We only need one Random number generator for the whole
  time the program is running, so one static variable makes sense.
- The central number in the procedural Game and our future Play method is ``secret``.
  Should that be an instance variable?  It would work, but it would
  be unhelpful and misleading:  Secret is reset every time the game is played,
  and it has no meaning after a Play function would be finished.  There is nothing to
  remember *between* time you Play.  This is the
  perfect place for a local variable *as we have now*.  
  
A common newbie error is to make things
into instance variables, just because you can, when an old-fashioned
local variable is all that you need.  It is good to have variables leave the
programmer's consciousness when they are no longer needed, as a local variable does.  
An instance variable lingers on, leaving extra places to make errors.
  
Go ahead and make the changes: create project Game inside the current solution.
Have a class Game for the Game instance, with instance variable ``big`` and method
``Play``.

You still need a static ``Main`` method to first create the Game object.  You could prompt
the user for the value for ``big`` to send to the constructor.  Once you have an object, 
you can call *instance method* ``Play``.  What about parameters? What needs to change?

.. _animal-lab:

Animal Class Lab
------------------

**Objectives**:
Complete a simple (silly) class, with constructor and methods,
including a ``ToString`` method, and a separate testing class.

Copy the folder :repsrc:`animal_lab_stub` to a folder of yours, and modify the
files as discussed below.

#. Complete the simple class Animal in your copy of the file 
   :repsrc:`animal.cs <animal_lab_stub/animal.cs>`.  
   The bullets below
   name and describe the methods you need to write, after the constructor:

	- An Animal has a ``name`` and a ``gut``.  
	  In our version the ``gut`` is a List of strings 
	  describing the contents, in the order eaten.  
	  A newly created Animal gets a ``name`` from a parameter
	  passed to the constructor, while the ``gut`` starts off *empty*.
	
	- An Animal has a ``Greet`` method, so an animal "Froggy" would say (that is, print) 
		
		 Hello, my name is Froggy.
	
	- An Animal can ``Eat`` a string naming the food, adding the food to the ``gut``.
	  If Froggy eats "worm" and then "fly", its ``gut`` list contains
	  "worm" and "fly".
	
	- An Animal can ``Excrete`` (removing and printing what was *first* in the gut List). 
	  Recall the method ``RemoveAt`` in :ref:`listsyntax`.  Print "" if the ``gut``
	  was already empty.  Following the
	  Froggy example above, Froggy could ``Excrete``, and "worm" would be printed.
	  Then its ``gut`` would contain only "fly". 
	  
	- A ``ToString`` method: 
	  Remember the ``override`` keyword.  For example, it would return the
	  string for Froggy: 
	  
		 "Animal: Froggy"
		 
	- All the methods that print should be void.  Which need a parameter, of what type?

#. Complete the file :repsrc:`test_animal.cs <animal_lab_stub/test_animal.cs>` 
   with its class ``TestAnimal`` containing the 
   ``Main`` method, testing the class Animal: 
   Create a couple of Animals and visibly test all the methods, 
   with enough explanation that someone running the test program, 
   but *not* looking at the code of either file, can see that everything works.


Planning A Class Structure
-------------------------------

We are going to build up to a game for you to write.  Here is 
an idea for a skeleton of a text (adventure?) game.  It does not
have much in it yet, but it can be planned in terms of classes.
Classes with instances correspond to nouns you would be using, 
particularly nouns used in more than one place with different 
state data being remembered.
Verbs associated with nouns you use tend to be methods.  Think how you might break 
this down.  The parts appearing after the '>' prompt are entries by the user.
Other lines are computer responses::

	Welcome to Loyola!
	This is a pretty boring game, unless you modify it.
	Type 'help' if you need help.
	
	You are outside the main entrance of the university that prepares people for
	extraordinary lives.  It would help to be prepared now....
	Exits: east south west 
	> help
	You are lost. You are alone.
	You wander around at the university.
								 
	Your command words are:
	   help go quit 
	
	Enter
		help command
	for help on the command.
	> help go
	Enter
		go direction
	to exit the current place in the specified direction.
	The direction should be in the list of exits for the current place.
	> go west
	You are in the campus pub.
	Exits: east 
	> go east
	You are outside the main entrance of the university that prepares people for
	extraordinary lives.  It would help to be prepared now....
	Exits: east south west 
	> go south
	You are in a computing lab.
	Exits: north east 
	> go east
	You are in the computing admin office.
	Exits: west 
	> bye 
	I don't know what you mean...
	> quit
	Do you really want to quit? yes
	Thank you for playing.  Good bye.

Think and discuss how to organize things first....

The different parts of a multi-class project interact through their public methods.
Remember the two roles of writer and consumer.  The consumer needs good documentation
of how to use (not implement) these methods.  These methods that allow the
interaction between classes provide the *interface* between classes.  Unfortunately 
"interface" is used in more than one way.  Here it means publicly specified ways
for different parts to interact.

As you think how to break this game into parts, also think how the parts interact.

The code that generated the exchange above is the 
project folder :repsrc:`csproject1`.

The code uses many of the topics discussed so far in this book.

We will add some features from another meaning of :ref:`Interface`,
and discuss the revision in project
:repsrc:`csproject_stub` (no 1).  You *might* use this as a basis of a project....
