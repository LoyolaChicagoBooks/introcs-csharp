.. index::  class; plan classes and methods
   plan problem split into classes
   
.. _plan-classes:

Planning A Class Structure
==============================

The Console input/output interchange below illustrates 
an idea for a skeleton of a text (adventure?) game.  
It could be the basis of a later group project. It does not
have much in it yet, but it can be planned in terms of classes.
Classes with instances correspond to nouns you would be using, 
particularly nouns used in more than one place with different 
state data being remembered.
Verbs associated with nouns you use tend to be methods.  
Think how you might break this down, looking at what is happening
in the sequence below. 
 
The parts appearing after the '>' prompt are entries by the user.
Other lines are computer responses:

..  code-block:: none

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

As you think how to break this game into parts (classes), 
also think how the parts interact (public methods).
This is a good place for the start of a class discussion.

If the plan is to discuss it in class, *wait* before looking at 
the code that generated the exchange above, in the 
project folder :repsrc:`cs_project1`.

The code uses many of the topics discussed so far in this book.

We will add some features from another meaning of :ref:`Interface`,
and discuss the revision in project
:repsrc:`csproject_stub` (no 1).  You *might* use this version 
as a basis of a project.