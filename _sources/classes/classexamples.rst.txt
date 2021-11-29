.. index:: class; instance examples

.. _class-instance-examples:

Class Instance Examples
========================

.. index:: exercise; getters and setters

.. _more-getters-and-setters:

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

.. literalinclude:: ../../examples/introcs/example_class/example_class.cs
   :start-after:  test class


Besides the obvious tests, we also use
the fact that an Example object is mutable to play with  :ref:`alias`:  
In the
last few lines of ``Main``, after ``e`` becomes an alias for ``e2``, 
we change
an object under one name, and it affect the alias the same way.
Check this by running the program!

Make sure you can follow the code and the output from running.  

.. index:: Averager Example


.. _beyond-getters-and-setters:
  
.. rubric:: Beyond Getters and Setters

Thus far we have had very simple classes with instance variables and
getter and setter methods, and maybe a ToString method.  
These classes were designed to introduce the basic syntax for
classes with instances.  The classes have just been containers for data
that we can read back, and change if there are setter methods - pretty
boring and limited.  Many objects have more extensive behaviors, so we will
take a small step and imagine a somewhat more complicated  ``Averager`` class:

* A new ``Averager`` starts with no data acknowledged.
* Be able to enter data values one at a time (method ``AddDatum``).  
  We will use ``double`` values.
* At any point be able to return the average of the numbers entered so far
  (method ``GetAverage``).  
  The average is the sum of all the values divided by number of values.
  With ``double`` values we assume a ``double`` average.
  This does not make sense if there
  are no values so far, but with double type we can use the value
  ``NaN`` (Not a Number) in this case.
* Be able to return the number of data elements entered so far 
  (method ``GetDataCount``)
* Be able to clear the ``Averager``, going back to no data elements
  considered yet, like in a new ``Averager`` (method ``Clear``)
* It is good to have a ``ToString`` method.  We choose to have
  it label the number of data items and the average of the items.

The object starts from a fixed
state (no data) so we do not need any constructor parameters.

We can imagine a demonstration class ``AveragerDemo`` with a ``Main`` method
containing

.. literalinclude:: ../../examples/introcs/averager/averager_demo.cs
   :start-after:  chunk
   :end-before: chunk

It should print

..  code-block:: none

    New Averager: items: 0; average: NaN
    Next datum 5.1
    average 5.1 with 1 data values
    Next datum -7.3
    average -1.1 with 2 data values
    Next datum 11
    average 2.93333333333333 with 3 data values
    Next datum 3.7
    average 3.125 with 4 data values
    After clearing:
    average NaN with 0 data values

Now that we have a clear idea of the proposed outward behavior, we
can consider how to implement the ``Averager`` class.

We could store a list of all the data values entered in any instance,
requiring a large amount of memory for a long list. However, this
functionality was built into early calculators, with very limited memory.
How can we do it without remembering the whole list?  
Consider a concrete example:

If I have entered numbers 2.1, 4.5 and 5.4, and want the average, it is

    :math:`(2.1+4.5+5.4)/3=12.0/3=4.0`
    
If I want to include a further number 5.0, the average becomes

    :math:`(2.1+4.5+5.4+5.0)/4=17.0/4=4.25`
    
Note the relationship to the previous average expression:

    :math:`=((2.1+4.5+5.4)+5.0)/4=(12.0+5.0)/(3+1)`

In the numerator we have added the latest value to the previous sum, 
and in the denominator the count of data items is increased by one.  
All we need to remember to
go on to include the next item is the sum of values so far and the 
number of values so far.  We can just have instance variables
``sum`` and ``dataCount``.

You might think how to create this class....

The full ``Averager`` code follows:

.. literalinclude:: ../../examples/introcs/averager/averager.cs

Several things to note:

* We show that a constructor, like an instance method, can include a call
  to a further instance method.  Though we illustrate this idea, the 
  constructor code is
  actually unneeded.  See the :ref:`unneeded-constructor-code-exercise` below.
* We have methods that are not ToString or mere getters or setters of instance
  variables.  The logic of the class requires more. 
* The ``GetAverage``
  method does return data obtained by reading instance variable, but it does
  a calculation using the instance variables first.  See
  :ref:`alternate-internal-state-exercise`.

The code for both classes is in project :repsrc:`averager`.

Statistics Exercise
~~~~~~~~~~~~~~~~~~~~~~~

Modify the project :repsrc:`averager` so the ``Averager`` class is
converted to ``Statistics``.  Besides having methods to calculate the count
of data items and average, also calculate the standard deviation with
a method ``StandardDeviation``.  
It turns out that the only other instance variable needed is
the sum of the squares of the data items, call it ``sumOfSqr``. 
Before calculating the standard deviation, suppose we
assign the current average to  a local variable ``avg``.   
Then the handiest form of expression for the standard deviation is  ::

    Math.Sqrt((sumOfSqr - avg*avg)/dataCount)

Modify the demonstration program to show the standard deviation, too.

.. _unneeded-constructor-code-exercise:

Unneeded Constructor Code Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Recall that objects are always initialized. Each instance variable
has a default value assigned before a constructor is even run.  
The default value for numeric instance variables is 0, so the
call to ``Clear`` in the constructor could be left out, leaving the
body of the constructor empty!  Try commenting that line out
and test that the behavior of demo program is the same.

Emphasizing the fact that you are thinking about the
initial values of instance variables is not a bad idea.  Hence 
a common practice is to
explicitly assign even the default values in the constructor, as
we did initially with the call to ``Clear`` inside the constructor.

If no constructor definition is explicitly provided at all,
the compiler implicitly creates one with no parameters and an empty body.  
This means that the entire constructor in ``Averager`` could be omitted.
Comment the whole constructor out and check.

There is a defensive programming 
reason to provide even the do-nothing constructor explicitly:
If you use the implicit constructor and then decide to add a constructor 
with parameters, the implicit constructor is no longer defined by the compiler,
so any remaining call to it in your code becomes an error.

.. _alternate-internal-state-exercise:

Alternate Internal State Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The way we represent the internal state for an ``Averager`` is the
best probably, but if it turns out that the ``GetAverage`` method
is called a lot more often than a method that changes the state, 
we could avoid repeated division by saving the average as an
instance variable.  We could keep that *instead of* ``sum`` 
(and still keep ``dataCount``).  We can manage to 
keep the same public interface to the methods.  With these
alternate instance variables how would you change 
the implementation code and not change the method headings or meanings? 
If we keep the assumption that the average of 0 
items is
``double.Nan``, you will need to treat adding the first datum as
a special case.  The code is simpler if we change the outward assumptions
enough to consider the average of 0 items
to be 0.  Try it either way.

In the version with NaN you can avoid testing for NaN, 
but if you choose to test for
NaN, you need the boolean ``Double.IsNaN`` function, because the expression
``double.NaN == double.NaN`` is *false*!

.. index:: class; convert static game to instance

Converting A Static Game To A Game Instance
----------------------------------------------

For a comparison of procedural and object-oriented coding,
consider converting :ref:`lab-number-game` so that a GuessGame
is an object, an instance of the GuessGame class.

While our earlier example, Contact, is a simple but practical 
use of object-oriented programming, GuessGame is somewhat more artificial.  
We create it hoping that highlighting the differences between procedural 
and object-oriented presentation is informative.  Also, we will see 
with :ref:`interface` that
there are C# language features that require an
object rather than just a function and data.  
In :ref:`igame-interface-exercise` you can use a Game object.

Here is a procedural game version, example file 
:repsrc:`static_version/static_version.cs`

.. literalinclude:: ../../examples/introcs/static_version/static_version.cs
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
What about parameters? What needs to change from the procedural version?

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
       

.. index:: class; user class as instance
   example; clock

.. _clock:

Clock Example
----------------------------------------------

Consider the logic for a digital 24 hour clock object,
type ``Clock``, that shows hours and minutes,
so 03:45 would be three forty-five.
Note that there is no AM or PM:  The hours go from 00, starting at midnight,
through hour 23, the 11PM hour, so 23:59 would be a minute before midnight,
and 13:00 would be 1PM. 

Assume there is some attached circuit to signal when a new minute starts.

This class could have just a few methods:  ``Tick``, 
called when a new minute is signaled,
and ``GetTimeString`` to return the time in the format illustrated above,
and ``SetTime`` specifying new values for the hours and minutes.  
We can start
from a constructor that just sets the clock's time to midnight.  

We can imagine a demonstration class ``ClockDemo`` with a ``Main`` method
containing

.. literalinclude:: ../../examples/introcs/clock/clock_demo.cs
   :start-after:  chunk
   :end-before: chunk

It should print

..  code-block:: none

    Midnight 00:00
    Before midnight 23:58
    Tick 23:59
    Tick 00:00
    Tick 00:01
    Tick 00:02


A ``Clock`` object will need instance variables.  
One obvious approach would be to have ``int``
instance variables for the hours and minutes. Both can be set and can advance
and will need ot be read.

These actions are common to both the hours and minutes, 
so we might think how we can avoid writing some things twice. 
There is one main difference:  The minutes roll over at 60 
while the hours roll over at 24.  Though the limits are different, 
they are both numbers, so we can store the limit for each, 60 or 24.
Then the same code could be used to advance each one, just using a different value
for the rollover limit.  

How would we neatly code this in a way that reuses code?  The most significant
thing to notice is that dealing with minutes involves data (the current count
and the limit 60) and associated actions:  being set, advanced and read.  
The same is true for the hours.
The combination of *data and tightly associated actions*, particularly used
in more than one situation, 
suggests a new class of objects, say ``RolloverCounter``.

Notice the shift in this approach:  The instance variables for hours and minutes
would become instances of the ``RolloverCounter`` class.  A ``RolloverCounter``
should know how to advance itself.  Hence the logic for advancing a counter, 
sometimes rolling it over, would not be directly in the ``Clock`` class,
but in the ``RolloverCounter`` class.  

So let's think more about what we would want in the ``RolloverCounter`` class.
What instance variables?  Of course we have the current count, 
and since we want the same class to work for both minutes and hours, we
also need to have the rollover limit. They are both integers.  

The limit should just be set once for a particular counter, 
presumably when the object is created.  For simplicity 
we can just assume the count is 0 when a ``RolloverCounter``
is first created.  Of course we must have a method to let the count
advance, rolling over back to 0 when the limit it reached.  

Throw in a getter and a setter for the count and we can have the following
class:

.. literalinclude:: ../../examples/introcs/clock/rollover_counter.cs

Note how concise the ``Advance`` method is!  With the remainder operation,
we do not need an ``if`` statement.  
Check examples by hand if this seems strange.

.. index:: format; 0-pad
   zero pad format
   overloading; constructors

Finally we introduce the ``Clock`` class itself.  
We display the entire code first, and follow it with comments about a number
of new features.

.. literalinclude:: ../../examples/introcs/clock/clock.cs

#.  First the principal reason for this example:  We illustrate 
    writing a class where the instance variables are objects of a different
    user-defined type.  Because the instance variables ``hours`` and 
    ``minutes`` are objects, we must initialize them
    using the ``new`` syntax.
#.  Skip over the *second* constructor for now, and see the ``SetTime`` method:
    We call the appropriate method to update the individual
    ``RolloverCounter`` instances.
#.  Now go back to the second constructor.  This is not really necessary:
    With the first constructor the calling code could just have one more 
    ``SetTime`` line any time you want to
    to create a clock with a time other than midnight.  
    We can make a case for
    this being so common, that we want to do it in just one line,
    with a constructor that sets a specified time.  
    However, the main excuse was really to illustrate that
    constructors can be *overloaded*, like methods:  You can have separate 
    constructors with distinct signatures.  
    In this case versions with no parameters vs. two ``int`` parameters.
#.  The ``Tick`` method has a bit of logic to it:  while the minutes always
    advance, the hours only advance when the minutes roll over to 0.
#.  Finally the ``GetTimeString`` method illustrates a new integer string 
    formatting mode:  The D2 format specifier applies to an integer, and displays it
    as a minimum of 2 digits, padding on the left with 0's as necessary.
    This is just what we want here.  In general the 2 could be replaced by another
    literal integer, so D6 would force at least 6 digits:  With the D6 format
    specifier 12 would be formatted as 000012, 
    and the longer 1234567 would add no extra 0's: still 1234567.

The code for all the classes is in project :repsrc:`clock`.

Admittedly, with this exact functionality and such a concise line to
advance a count, it would actually have shorter to have done everything 
inside the ``Clock`` class, with no ``RolloverCounter``, but we were looking
for a simple illustration of combining user-defined types this way, 
and a ``RolloverCounter`` is a clear unified
concept that can be used in other situations.  See an upcoming exercise.

Alternate Clock Constructor Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Make a small change to :repsrc:`clock/clock_demo.cs`, so the second
constructor is tested.

Clock With Seconds Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Modify the project :repsrc:`clock`, assuming the Tick is for each second, and
the time also show the seconds, like 55 seconds before midnight would be
23:59:05.

.. index:: model-view-controller pattern

Twelve Hour Time Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Modify the project :repsrc:`clock` so a ``GetTimeString12`` method returns
the 12 hour time with AM or PM, like 11:05PM or 3:45AM. (The hours do
not have a leading 0 in this format.) 
This could be done modifying a lot of things:
keeping the actual hours and minutes that you will display 
and remembering AM or PM (with the hours 
being more complicated, not starting at 0).  We suggest something else instead:

This is a good place to note a very useful pattern for programming, called
*model-view-controller*.  The *model* is the way chosen to store the state internally.
The *controller* has the logic to modify the model as it needs to evolve.  
A *view* of a part of
the model is something shown to the user that 
does not need to be in the exact same form as the model itself:  
A view just needs to be something that can be *easily calculated* 
from the model, and presumably is desired by the user.

In this case a simple (and already coded!) way to store and control 
the time model data
is the minutes and up to 23 hours that do happen to directly correspond 
to the 24 hour clock view. 

The main control is to advance the time, 
and with just two 0-based counts we have the
very simple remainder formulas.

So the suggestion is to keep the *internal* data the same way as before.  
Just in the method to create the desire 12-hour view have the logic to do the 
*conversion* of the internal 24-hour model data.

You could leave in the method to provide the time in the
24 hour format, giving the ``Clock`` class user the option to use either view
of the shared model data.
To be symmetrical in the naming, 
you might change the original name ``GetTimeString`` to 
``GetTimeString24``.






