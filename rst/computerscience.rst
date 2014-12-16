.. index:: computer science

.. _computer_science:

Computer Science, Broadly
================================= 

We intend this book as an introduction to computer science, with a focus on 
creating problem solutions in the C# programming language.  
We should not jump in too quickly.  You can get lost in our details and
miss an idea of the much larger breadth of computer science.  

.. index:: information processing

Information Processing
------------------------

Computer Science is the study and practice of information processing.  
This can take many forms.  Many forms appear in electronic computers, 
but information processing takes place in many other contexts, too:

In the early days of electronic computers, 
the information was largely numerical, calculating mathematical functions.

Later analyzing textual information 
has become much more important, for instance:
What can you tell about the severity of the current flu outbreak by
analyzing the phrasing in Google searches? 

Images are analyzed:  What can a satellite image tell you about the
distribution of drought?  

Sounds:  how do you convert verbal speech accurately
into written sentences?

DNA holds information that our bodies process into proteins.

Our brain chemicals and
electronic signals process information.  There is  rich interplay
between cognitive scientists and computer scientists modeling 
problem solving in the brain with *neural nets* on a computer, 
sometimes to better understand brains and 
sometimes to
better solve problems on an electronic computer.

Economic systems are becoming better understood in terms of the 
flow of information.

The *computer* doing computations and processing can be a familiar *electronic* 
computer, but it can be genes or brain chemicals, 
or a whole society as its economy adapts.

.. index:: algorithms

Algorithms
------------

Algorithms are at the heart of traditional problem solving .  An *algorithm*
is a clearly expressed sequence of steps leading to a result in a 
finite amount of time.  

A recipe for baking a pound cake is an algorithm.  

Such an algorithm has useful concepts that we use later in computer
programming:

* A named sub-problem: your recipe may include the instruction
  "Beat 4 eggs."  The recipe probably says no more about it, but this is
  *shorthand*, a name for a simpler sequence of steps, an
  algorithm like:
  
  .. code-block:: none
  
     Beating Any Number of Eggs
     ---------------------------    
     1. Get a bowl large enough for the eggs.
     2. For each egg:
        a. Crack its shell on the edge of the bowl.
        b. Add the contents of the shell to the bowl.
     3. Mix the eggs with a whisk.
     4. Continue with step 3 until you cannot 
        distinguish the white and yolks.

* Parameters: The egg beating instructions work, in general, for any number
  of eggs.  To use these instructions for a *particular* pound cake, 
  you must supply a specific value to use to make the general instructions
  become clear.  The pound cake recipe that uses
  the egg beating instructions, uses the number **4** as the actual data.
  
* Repetition: The instructions for cracking an egg are not *written* repeatedly,
  for every egg.  The instruction is stated once, and we are told how 
  long to go on: for each egg in step 2.  Step 4 says
  when to stop repeating step 3.

.. index:: data representation
   Jaquard loom
   Pascaline

.. _data-representation:

Data Representation
---------------------

A recipe represents data by words that get processed by a human reader.
Machines have used different representations.  One of the earliest
adding machines, the Pascaline, 
http://en.wikipedia.org/wiki/Pascal's_calculator,
represented numbers by the angle of 
rotation of interlocked gears.  
An abacus uses the positions of groups of sliding beads to represent digits.
The Jacquard loom, 
http://en.wikipedia.org/wiki/Jacquard_weaving, 
used cards with each row of holes punched in them
indicating which warp threads are raised and which lowered when a cross
thread is woven in.  

.. index:: bit
   byte
   binary number system
   base 2

In modern electronic computers the most basic bit of data 
(actually called a *bit*) is held by two-state switches, often 
in the form of a higher voltage vs. a grounded state.  The symbolic representation
is often 0 vs. 1.  This symbolism comes from the representation of integers 
in *binary notation*, also called *base 2*:  
It is a place value system, but where each place
in a numeral is a 0 or a 1 and represents a power of two, so 1101 in binary 
can be viewed in our decimal system as
:math:`(1)2^3+(1)2^2+(0)2^1+(1)2^0=8+4+0+1=13`.

Computer hardware can only handle a limited number of bits at a time, 
and memory space is limited, so usually integers are stored in a limited
space, like 8, 16, 32 or 64 bits.  
We illustrate with the smallest, 8 bits, called a *byte*.  Since
each bit has two possible states, 8 bits have :math:`2^8=256` possible states.
Directly considered as binary numerals, they represent 0 through 
:math:`2^8-1=255`.

We also want to represent negative numbers, and have about half of the available
codes for them.  An 8-bit signed integer in *twos complement* notation
represents 0 through :math:`2^7-1` 
just as the unsigned numbers do.  These are all the 8-bit codes with a leading 0.
A negative number :math:`n` in the range :math:`-2^7=-128` through -1, 
is represented by what would be 
the unsigned notation for :math:`n+2^8`.  These will be all the 
8-bit codes with a leading 1.
For example -3 is represented like unsigned 256 - 3 = 253: 11111101 in binary.

.. index:: mantissa and exponent

Limited precision approximation of real numbers are stored in something like
scientific notation, except in binary,  roughly :math:`\pm(m)2^e`,
with a sign, mantissa m and exponent e. Both e and m have
fixed numbers of bits, so the limited options for the 
mantissa restricts the *precision* of the numbers, and the limited options
for the exponent restricts the *range*. Data on these limits for 
different sized numeric codes is in :ref:`value-types`.  

Once you have numbers, all sorts of other kinds of data can be encoded:  
Characters
like on your keyboard each have a numerical code associated with each one.  For
example the unicode for the letter A is 65.  Images are often 
represented as a sequence of colored pixels.  Since the human eye is only 
sensitive to three specific colors, red, green, and blue, 
a pixel is represented by a numerical intensity
for each of the three colors.

.. index:: instruction representation
   machine language
   assembler
   interpreter
   architecture
   

Instruction Representation
----------------------------

Besides the data, instructions need a representation too, and an agent to
interpret them.  In the earliest electronic computers the two-state switches
were relays or later vacuum tubes, and the machine was *manually rewired* when a 
new set of instructions/program was needed.  It was a great advance in the 1940's
when the instructions also became symbolic, 
represented by binary codes that the computer 
could recognize and act on,
http://en.wikipedia.org/wiki/Von_Neumann_architecture.
This code is called *machine language*.
With machine language the instructions became a form of data that could be stored
in computer memory.  We distinguish the *hardware* on which programs are run
from the stored programs, the *software*.  The *architecture* of the
hardware determines the form and capacities of the machine language, so 
machines with a different hardware architecture are likely to have distinct
machine languages.

Biologists have a fair idea of how protein sequence data is encoded in DNA,
but they are still working on how the DNA instructions are encoded 
controlling which proteins should be made when.

In this book we will not be writing instructions shown as 
sequences of 0's and 1's!  
Some of the earliest programs were to help programmers 
work with more human-friendly tools, and an early one
was an *assembler*, a program that took easier to understand instructions
and automatically translated them into machine language.  An example 
assembler instruction would be like

.. code-block:: none

   MOV 13, X
    
to move the value 13 to a storage location identified by the name X.

Machine instructions are very elementary, so programming
was still tedious, and code could not be reused on a 
machine with a different architecture.  

The next big step past assembler was the advent of
*high level* languages, with instructions more like normal mathematical or 
English expressions.  Examples are Fortran (1954) and Cobol (1959).  
A Fortran statement for calculating a slope like

.. code-block:: none

   S=(Y-V)/(X-U)

might require seven or or more machine code instructions. 

To use a Fortran program required three steps: write it (onto punch cards
originally), compile it to machine code, and execute the machine code.
The compiler would still be architecture specific, but the compiler for
an architecture would only need to be written once, and then any number of
programs could be compiled and run.

A later variant for executing a high-level language is
an *interpreter*.  An interpreter translates the high-level language
into machine code, and immediately executes it, not storing the
machine code for later
use, so every time a statement in the code is executed again,
the translation needs to be redone.  Interpreters are also 
machine-specific.

Some later languages like Java and C# use a hybrid approach: A compiler, 
that can run on any machine, does most of the work by 
translating the high-level language program
into a low-level *virtual machine*
language called a *bytecode*.  This is not the machine language for any real machine, 
but the bytecode is simple 
enough that writing an interpreter for it is very easy.  
Again the interpreter for the bytecode must be machine-specific.  
In this approach:

Program source => COMPILER => bytecode => INTERPRETER => execution

.. index:: program development cycle

Program Development Cycle
---------------------------

The easiest way to check your understanding of small new pieces of C# is to write
a highly specified small program that will be sure to test the new ideas.
That is totally unlike the real world of programming.  Here is a more realistic
sequence:

#. Clients have a problem that they want solved.
#. They connect with software developers.
#. The clients discuss the needs of their users.
#. The software developers work with them to make sure they
   understand the desired deliverables, and work through the
   design decisions and their tradeoffs.
#. Software developers start building and testing and showing off the
   core pieces of the software, and build on out.
#. The clients may not have a full idea of what they want and the 
   software developers may not have a full idea of what is feasible, and
   seeing the latest version leads both sides to have a clearer vision.
   Then the previous process steps are repeated, iteratively refining
   the product.
#. After a production version is out, there may be later versions and error
   fixes, again cycling back to the earlier steps.
 
Note that very important parts of this process are not centered on coding, 
but on communicating clearly with a possibly non-technical client.
Communication skills are critical.  

.. index:: computer science; key concepts

Key Computer Science Areas
-----------------------------

Most of the introduction so far has been about key concepts that underlie 
basic programming. Most of the parts so far about electronic computers 
could have been written decades ago.  Much has emerged since then,

*  the Internet 
*  the development of economical multi-processor machines 
   distributing computation into many parallel parts
*  the massive explosion of the amount of information to be stored
   from diverse parts of life
*  the coming *Internet of things*, where sensors are coming to all
   sorts of previously "dumb" parts of the world, that now can be tracked
   by GPS and reacted to in real time.
*  Computers are now embedded in all sorts of devices:  toasters, thermostats,....
   Automobiles of today have more computing power embedded in various devices 
   than early mainframe computers. 
   
We conclude with a brief discussion of some of the other organizing
principles of
computer science.

Communication
    As the world is criss-crossed with media transmitting gigabytes of
    data per second, how do we keep the communication reliable and secure?

Coordination 
    With multiple networked entities, how do we 
    enhance cooperation, so more work is done in parallel?

Recollection 
   As the amount of data stored skyrockets, how do we effectively store
   and efficiently retrieve information?

Evaluation
    How do we predict the performance and plan the necessary capacity 
    for computer systems?  The most spectacular recent public failure 
    in this area was the rollout of the federal Affordable Care
    website.

Design 
    How do we design better/faster/cheaper/reliable hardware and software systems?
    What new programming languages will be more expressive, lead to fewer
    time-consuming errors, or be useful in proving that a major program never
    makes a mistake?  Errors in programs controlling machines delivering
    radiation for cancer treatment have had errors and led to patient death.
    
    Hardware changes can be evolutionary or revolutionary:
    Instead of electric circuits can we use light, quantum particles, DNA...?
    
Computation and Automation
    What can we compute and automate?  Some useful
    sounding problems have been proven to be unsolvable.  What are the limits?

.. index:: Denning - Peter
   Miles - Rob
   C# Yellow Book

A detailed discussion of these principles and the breadth of
importance of computer science can be found at
http://denninginstitute.com/pjd/GP/GP-site/welcome.html.  

For an alternate general introduction to programming and the context of C# in particular,
there is another free online source, 
Rob Miles'  
C# Yellow Book, available at
http://www.csharpcourse.com.
Note that it is written specifically for Microsoft Windows use, using 
Visual Studio software development environment, which works only on Windows machines,
and costs a lot if you are not a student.

The :ref:`lab-edit-compile-run` will introduce an alternative to the 
Microsoft environment: Xamarin Studio and Mono, which are free, 
open-source software projects that make C# available for multiple platforms:  
Windows, Mac, or Linux machines.  With a substantial fraction of students having their own
machine that does  *not* run Windows, this flexibility is important.
