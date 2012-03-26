Class Examples
================================

Converting Static Game to Game Instance
----------------------------------------

For a comparison of procedural and object-oriented coding,
consider converting :ref:`lab-number-game` so that a Game
is an instance.

While our last example, Rational, is in fact a very practical 
use of object-oriented programming, this is somewhat more artificial,
but hopefully informative, particularly with the transformation.
Here is a procedural version, project file 
:file:`Game\StaticGame\GuessGame.cs`

.. literalinclude:: ../projects//Game/GameStatic/Game.cs
   :start-after:  chunk
   :end-before: chunk

The project also holds the class Input, with the functions we use for safe
keyboard input.  It is all static methods.  is there any reason to make this
class have its own own instances?

No.  There is no state to remember between Input method calls.  What comes in through
the keyboard goes out through a return value, and you are done with it.  
A simple function works fine each time.  Do not get fancy for nothing.

What state would a game hold?  We might set it up so the user
chooses size of the range of choices just once, and remember it 
for possibly multiple plays of the Game.  The variable was
``big`` before, we can keep the name.  
If we are going to remember it inside our Game instance, 
then ``big`` needs to become an instance variable, and it will be something
we can set in a constructor.

What actions will this object take?  Only one - playing a Game.
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
