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
- See what is missing!  In place of each method 
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
CommandMapper, and the the CommandMapper constructor creates the Dictionary
used to look up the Response that goes with each command word.  Here is the whole code for 
ResponseMapper, taking advantage of the Dictionary in other methods, too.

.. literalinclude:: ../projects/CSProj/CSProj/CommandMapper.cs

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

Cohesion, Coupling, and Separation of Concerns
-----------------------------------------------

There are three important ideas in organizing your code into
classes and methods:

*Cohesion* of code is how focused a portion of code is on a unified purpose.
This applies to both individual methods and to a class.  The higher 
the cohesion, the easier it is for you to understand a method or
a class.  Also a cohesive method is easy to reuse in combination 
with other cohesive methods.  A method that does several things
is not useful to you if you only want to do one of the things later.

*Separation of concerns* allows most things related to a class to take place in the
class where they are easy to track, separated from other classes.  
Data most used by one class should probably reside in that class.
Cohesion is related to separation of concerns:  The data and methods most used
by one class should probably reside in that class, so you do not need to go 
looking elsewhere for important parts.  

Some methods are totally related to the connection between classes, and there may not be
a clear candidate for a class to maximize the separation of concerns.  One thing to 
look at is the number of references to different classes.  It is likely that the most
referred to class is the one where the method should reside.

*Coupling* is the connections between classes.  If there were no connections
to a class, no public interface, 
it would be useless except all by itself.  The must be some coupling between classes,
where one class uses another, but with increased cohesion and strong
separation of concerns you are likely to be able to have 
looser coupling.  Limiting coupling makes it easier to follow 
your code.  There is less jumping around.

Aim for strong cohesion, clear separation of concerns, and loose coupling.  Together 
they make your code clearer, easier to modify, and easier to debug.

IGame Interface Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

On a much smaller scale than the project, this exercise offers you
experience 
writing classes implementing and using an interface

1. Copy project :file:`IGame/IGame` to your space or to a different name.

2. Look at the IGame interface in :file:`IGame.cs`. Then look at :file:`AdditionGame.cs`, 
   that implements the interface. See how a new ``AdditionGame`` can be added to list of
   ``IGame``\ 's. Run :file:`PlayGames.cs`. Randomly choosing a game when there is
   only one to choose from is pretty silly, but it gives you a start on a
   more elaborate list of games.  The ``PopRandom`` method is a good general
   model for choosing, removing, and returning a random element.

3. Write several very simple classes implementing the IGame interface,
   and modify Main in PlayGames.cs to create and add a new game of each
   type. (Test adding one at a time.)
   
   One such game to create with little more work would be a variation on
   instance based Guessing Game discussed earlier.  You need to make slight
   modifications.  You could make Play return the opposite of the number of guesses, 
   so more guesses does generate a worse score.
