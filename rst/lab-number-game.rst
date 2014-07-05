.. index::
   single: labs; string manipulations

.. _lab-number-game:

Number Guessing Game Lab
========================

**Objectives**:  

- Work with functions
- Work with interactive while loops
- Use decisions
- Introduce random values

This lab is inspired by a famous children's game
known as the number-guessing game. We suppose two people are playing.

The rules are:

- Person A chooses a positive integer less than N and keeps it in his or
  her head.

- Person B makes repeated guesses to determine the number. Person A
  must indicate whether the guess is higher or lower.

- Person A must tell the truth.

So as an example:

- George and Andy play the game.

- George chooses a positive number less than 100 (29) and puts it in his
  head.

- Andy guesses 50. George says "Lower". Andy now knows that 
  :math:`1 \leq number < 50`.

- Andy guesses 25. George says "Higher". Andy now knows that 
  :math:`26 \leq number < 50`.

- Andy guesses 30. George says "Lower". Andy now knows that the
  :math:`26 \leq number < 30`.

- Andy starts thinking that he is close to knowing the correct answer. He
  decides to guess 29. Andy guesses the correct number. So George
  says, "Good job! You win."

We are going to elaborate this game in small steps.  You might save
the intermediate versions under new names.

The computer code for the
game is going to be acting like Player A.

Part 1: No Hints; Fixed Secret Number
-------------------------------------------

You will want to use the UI class, so either copy ui.cs into your project, or
(for Xamarin Studio) create a new project in a solution 
in which you already have added the ui library project, and add the ui project 
as a *reference* for the lab project.  
Make sure your program has ``namespace IntroCS;`` to match the UI class.

You are going to play a game, and later may repeat it, so put the code
for playing the number game in a function called ``Game``::

    static void Game()
        
For now your write a ``Main`` function to just call ``Game()``.

In ``Game``:

#. For the simplest versions, which help testing, have the
   program assign a specific
   secret number (like 29), and call it ``secret``.  
   Admittedly, this is not much fun for the player the second time!

#. Prompt the player for a guess.  
   Use ``UI.PromptInt``.
   Every time the player guesses wrong,
   print "Wrong!".  A later version will give clues.  Keep
   prompting for another number until the player guesses correctly.
   (Since you, the programmer, knows the secret number, this need not go
   on forever.)  
   
#.  When the player guesses the right number, print "Correct!  You win!"

Sample play could look like:

    | Guess the number: **55**
    | Wrong!
    | Guess the number: **12**
    | Wrong!
    | Guess the number:  **29**
    | Good job!  You win!
    
You could also make the game stop immediately, 
(since you know the secret number):

    | Guess the number:  **29**
    | Good job!  You win!

Part 2: Add Hints
-------------------------------------------

In ``Game``:  
Instead of just printing "Wrong!" when the player is incorrect,
print "Lower!" or "Higher!"  as appropriate.  For example:

    | Guess the number: **55**
    | Lower!
    | Guess the number: **12**
    | Higher!
    | Guess the number: **25**
    | Higher!
    | Guess the number:  **29**
    | Good job!  You win!

Part 3:  Add a Random Secret Number
-------------------------------------

In ``Game``, make the following alterations and additions:

#. For now set an ``int`` variable ``big`` to 100.  We will make sure 
   the secret number is less than ``big``.

#. Have the Game function print 
   "In this game you guess a positive number less than 100."
   For future use it is best if you have the printing statement
   reference the variable ``big``, rather than the literal ``100``.

.. index:: random number generator

#. Thus far the secret number was fixed in the program.  Now we are
   going to let it vary, by having the game generate a *random* number.
   For your convenience, we are going to give you the C#
   code to compute the random number.  Assuming we want a secret number
   so :math:`1 \leq secret < big`, we can use the code::

      Random r = new Random();
      int secret = r.Next(1, big);

   In case you are wondering, we are creating a *new object* 
   of the *class* ``Random`` which serves as the
   random number generator. We'll cover this in more detail when we
   get to the :ref:`classes` chapter. Here is some illustration using a ``Random``
   object in csharp.  Your answers will not be the same!  ::

      csharp> Random r = new Random();
      csharp> r.Next(1, 100);   
      55
      csharp> r.Next(1, 100); 
      31
      csharp> r.Next(1, 100); 
      79
      csharp> r.Next(2, 5); 
      2
      csharp> r.Next(2, 5); 
      4
      csharp> r.Next(2, 5); 
      3
      csharp> r.Next(2, 5); 
      3

   In general the minimum possible value of the number returned by ``r.Next``
   is the first parameter, and the value returned is always *less* than
   the second parameter, *never equal*.  
   
   You can see that ``r.Next()`` is smart enough to give what appears to
   be a randomly chosen number every time. 

   Example (where ``secret`` ended up as 68):
   
    | Guess a number less than 100!
    | Guess the number: **60**
    | Higher!
    | Guess the number: **72**
    | Lower!
    | Guess the number: **66**
    | Higher!
    | Guess the number: **68**
    | Good job!  You win!
   
   For debugging purposes, you might want to have ``secret`` 
   be printed out right away. 
   (Eliminate that part when everything works!)

Part 4:  Let the Player Set the Range of Values
------------------------------------------------

In ``Game``: 
Instead of declaring ``big`` and  automatically initializing it to 100,
make ``big`` be a parameter, so the heading looks like::
    
        static void Game(int big)

In ``Main``:  

#.  Prompt the player for the limit on the secret number.
    An exchange might look like:
    
        Enter a secret number bound: **10**

#.  Pass the value given by the player to the ``Game`` function 
    (so it will be ``big`` inside ``Game``).  

Hence the program might start with:

    | Enter a secret number bound: **10**
    | In this game you guess a number less than 10!
    | Guess the number: **5**
    | Higher!
    | Guess the number: **7**
    | Lower!
    | Guess the number: **6**
    | Good job!  You win!

Part 5:  Count the Guesses
------------------------------------------------

In ``Game``: When the player finally wins, print the number of guesses
the player made.  For example, for the game sequence shown above,
the last line would become:

    Good job!  You win on guess 3!
   
You need to keep a count, adding 1 with each guess.


Possible Extra Credit Improvements or Variations
--------------------------------------------------------

Should you finish everything early, try the following:

#. **(20% extra credit)**  In ``Main``:

   Use an outer ``while`` loop to allow the game to be played
   repeatedly. Change the prompt for the bound in ``Main`` to:
   
       Enter a secret number bound (or 0 to quit):
       
   Continue to play games until the player enters 0 for the bound.
   
#. **(40% extra credit)**
   In ``Main`` prompt users to see if they want to guess numbers or reverse roles and
   choose
   the secret number.  In the first case, just call the existing Game function.
   In the second case you need a new function, 
   where the user is the one who knows the secret
   number and the computer guesses numbers until the answer
   is obtained. Write and use a new function  ::
   
      static void GameReversed(int big)
      
   Pass it the parameter ``big``, still set in ``Main``.
   The new ``GameReversed`` will tell the user to put a number in
   his/her head, and press return to continue. 
   (You can throw away the string entered - this is just to cause a pause.)
   Then the computer guesses.
   For simplicity let the human enter "L" for lower, "H" for higher, and
   "E" for equal (when the computer wins).
   As you saw in the initial example with George and Andy,
   each hint reduces the range of the possible secret numbers.
   Have the computer guess a *random* number in the *exact* range that 
   remains possible.

   To do this you must note the asymmetry of the parameters for the method
   ``Next``:  suppose ``n = r.Next(low, higher)``, then 
   
       :math:`low \leq number < higher`
    
   The first parameter *may* be returned, but second 
   parameter is *never* returned.
   
   You will need two variables ``low`` and ``higher`` that keep
   bracketing the allowed range.  The simplest thing is to set them so they
   will be the parameters for the following call to ``Next``. 

   That would mean initially ``low``
   is 1 and ``higher`` is equal to ``big``.  
   With each hint you adjust one or the other of ``low`` and ``higher`` so they
   get closer together.
   The game ends after the human enters "E".
   
   Have the computer complain that the human is cheating (and stop the game) 
   if the computer
   guesses the only possible value, and the human does *not* respond with "E".
   
   
   
