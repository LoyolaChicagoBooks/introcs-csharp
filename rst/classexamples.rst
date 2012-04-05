Class Examples
================================

Converting A Static Game to A Game Instance
----------------------------------------------

For a comparison of procedural and object-oriented coding,
consider converting :ref:`lab-number-game` so that a Game
is an instance.

While our last example, Rational, is in fact a very practical 
use of object-oriented programming, this is somewhat more artificial,
but hopefully informative, particularly with the transformation.
Here is a procedural version, project file 
:file:`Game/GameStatic/Game.cs`

.. literalinclude:: ../projects/Game/GameStatic/Game.cs
   :start-after:  chunk
   :end-before: chunk

The project also holds the class Input, with the functions we use for safe
keyboard input.  It is all static methods.  is there any reason to make this
class have its own own instances?

No.  There is no state to remember between Input method calls.  What comes in through
the keyboard goes out through a return value, and you are done with it.  
A simple function works fine each time.  Do not get fancy for nothing.

What state would a game hold?  We might set it up so the user
chooses the size of the range of choices just once, and remember it 
for possibly multiple plays of the Game.  The variable was
``big`` before, we can keep the name.  
If we are going to remember it inside our Game instance, 
then ``big`` needs to become an instance variable, and it will be something
we can set in a constructor.

What action/methods will this object have?  Only one - playing a Game.
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
programmer's consciousness when they are no longer needed, as a local variable should.  
An instance variable lingers on.
  
Go ahead and make the changes: create project Game inside the current solution.
Have a class Game for the Game instance, with instance variable ``big`` and method
``Play``.

You still need a static main method to first create the Game object.  You could prompt
the user for the value for ``big`` to send to the constructor.  Once you have an object, 
you can call *instance method* ``Play``.  What about parameters? What needs to change?

.. _animal-lab:

Animal Class Lab
------------------

**Objectives**:
Write from scratch a simple (silly) class, with constructor and methods,
including a ToString Method, and a separte testing class.


#. Create a simple class Animal:

	- An Animal has a name and a gut.  In our version the gut is a List of strings 
	  describing the contents, in the order eaten.  
	  A newly created Animal gets a name
	  passed as a parameter to the constructor, while the gut starts off *empty*.
	
	- An Animal has a Greet method, so an animal "Froggy" would say (that is, print) 
		
		 Hello, my name is Froggy.
	
	- An Animal can Eat a string naming the food, adding the food to the gut.
	
	- An Animal can Excrete (removing and printing what was *first* in the gut List). 
	  Recall the method ``RemoveAt``.
	  
	- A ToString method (remember the override keyword).  For example, it would return the
	  string for Froggy: 
	  
		 "Animal: Froggy"
		 
	- All the methods that print should be void.  Which need parameter, or what type?

#. Write a class with a Main method, testing Animal: 
   create a couple of Animals and visibly test all the code.


Planning A Class Structure
-------------------------------

We are going to build up to a game for you to write.  Here is 
an idea for a skeleton of a text (adventure?) game.  It does not
have much in it yet, but it can be considered in terms of classes.
Classes with instances correspond to nouns you would be using, 
particularly nons used in more than one place with differeent data being remembered.
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

Think and discuss how to organize things first.

The different parts of a multi-class project interact through their public methods.
Remember the two roles of writer and consumer.  The consumer needs good documentation
of how to use (not implement) these methods.  These methods that allow the
interaction between classes provide the *interface* between classes.  Unfortunately 
"interface" is used in more than one way.  Here it means publicly specified ways
for different parts to interact.

As you think how to break this game into parts, also think how the parts interact.

In the projects in :file:`CSProj/CSProj1` is code that generated the exchange above.

The code uses many of the topics discussed so far in these notes.

We will add some features from interfaces and discuss the revsion in 
:file:`CSProj/CSProj` (no 1).  You *might* use this as a basis of a project....
