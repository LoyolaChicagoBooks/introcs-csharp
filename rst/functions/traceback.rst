.. index:: tracebacks
   debugging; tracebacks

.. _tracebacks:

Tracebacks
====================

Various things cause an *Exception* and make a program bomb out in the middle.  
For debugging purposes it is very useful top know exactly where this happens.
Xamarin Studio gives feedback, but it takes some understanding to extract
the useful information.

This program below, :repsrc:`traceback/traceback.cs` takes user input and is designed to bomb out with
bad input in both an obvious and in a subtle way.  

.. literalinclude:: ../../source/examples/traceback/traceback.cs

The remainder part works fine if the user enters integers other than 0, 
but it will blow up if the user enters 0 for the divisor.

The program was also consciously designed so that there are nested function calls:
For example ``Main`` calls ``DoRemainder`` (in two places) which calls ``Remainder``.

You can run it, first entering reasonable numbers like 13 and 5.  Then at the  
request for two more numbers try
entering 3 and 0.  You get an error *traceback* something like the following. 
There are several very long lines.  I have added numbers to reference different ones:

#. Unhandled Exception:
#. System.DivideByZeroException: Attempted to divide by zero.
#. at IntroCS.Traceback.Remainder (Int32 n, Int32 m) [0x0000b] in 
   *pathToMySolution*/examples/traceback/traceback.cs:26 
#. at IntroCS.Traceback.DoRemainder () [0x00019] in 
   *pathToMySolution*/examples/traceback/traceback.cs:19 
#. at IntroCS.Traceback.Main () [0x00006] in 
   *pathToMySolution*/examples/traceback/traceback.cs:10 
#. [ERROR] ... 


Unhelpfully it repeats about the same data twice, so I chopped off the part after "[ERROR]".

Let us look at this a line at a time:

#. It says the Exception is "unhandled":  
   There are ways to handle exceptions from *within* a program, 
   but that is beyond the scope of this course.
#. Exception types are classes, so it gives the full
   name of the class, including the namespace.  Also there is a short English description:
   pretty clear here.
#. So where did the error occur?  The first line starting with "at ..." shows the full 
   name (including namespace and class) of the function
   in which the error occured.  
   There can be multiple source files coming from multiple places, 
   so it also includes the full path name to the sourcefile - quite a mouthful on my
   computer, so I left out the full path to my Xamarin solution, calling it
   *pathToMySolution*. Do not let
   your eyes glaze over yet, because at the 
   very end comes the most important information: ":26".  The error
   was triggered in line **26**.  No surprise here: 
   the line where the division for the remainder takes place.
   The divide by zero exception is directly triggered by the hardware, and this did happen in
   the last line of the ``Remainder`` function.
#. Just saying the line where an error occured is not as much information as you would like generally:  
   The function could be called from many places.  The remaining "at ..." lines give the whole
   *chain* of function calls in reverse time order, all the way up to the outer call, in ``Main``.  
   See the ":19" at the end of this long line:  
   Check that the call to Remainder did come from line 19 in ``DoRemainder``.
#. There could be more intermediate function calls in general.  In this case, however, 
   we have come to the last "at ..." line shows the call from ``Main``.  We made the first call to
   ``DoRemainder`` so it had non-zero parameters and worked fine, and the problem came in the
   second call, from what line? 10.

In summary, look at the general description of the error in the second line, and then follow the
chain of functions in which the error appeared by look at the line numbers after the colons at the *ends*
of the long "at ..." lines.

In this case, we passed bad data to a function in the program source.  
Now let us look at what happens in we pass bad data to a C# library function:

Run the program again giving non-zero integers twice, to successfully pass the DoRemainder calls.

The next prompt is for a string.  Enter a short word like "hi".  You should see output with
hi" and then "hihi".  This looks like a silly but simple sequence showing any string twice.

Not so fast.  The DoSTwice function gets called again, asking for another string.  
Try the *exact* string "set {5}".  All hell breaks loose in a torrent!  The traceback output is way longer.
We will cut out some again, number lines, and explain:

#. Unhandled Exception:
#. System.FormatException: Index (zero based) must be greater than or equal to zero 
   and less than the size of the argument list.
#. at System.Text.StringBuilder.AppendFormat ... 
#. at System.String.Format ... 
#. at System.IO.TextWriter.WriteLine ... 
#. at System.IO.TextWriter+SyncTextWriter.WriteLine ... 
#. at (wrapper synchronized) System.IO.TextWriter ...
#. at System.Console.WriteLine ... 
#. at IntroCS.Traceback.ShowTwice (System.String s) [0x00001] in 
   *pathToMySolution*/examples/traceback/traceback.cs:38 
#. at IntroCS.Traceback.DoSTwice () [0x0000d] in 
   *pathToMySolution*/examples/traceback/traceback.cs:33 
#. at IntroCS.Traceback.Main () [0x00006] in *pathToMySolution*/examples/traceback/traceback.cs:10 

Discussion:

* In traceback line #2, we see it is a formating exception, 
  and the part afterward indicates a problem with the indexing.
* In lines #3-8, notice that all the classes start with System....  
  They are library classes:  I would strongly doubt the error was in the C# library system code.  Presumably
  the program passed some bad data to the System functions, which then went through a long chain before
  actually triggering the Exception!
* The System call closest to the class inside the program is at #8:  ``WriteLine`` - certainly used,
  and does involve formatting.
* The functions actually in the program are in #9-11.  The innermost call is in #9 ``ShowTwice``.  
  Now it makes sense to look at the line numbers: 38 - that is the more complcated call to ``WriteLine``.
* You can follow the calls up:  ``ShowTwice`` called from line 33 in ``DoSTwice``.
* The outermost call is from ``Main``.  We cannot explain the line number here for sure.  
  It is either from a bug in Xamarin 
  or it may be that the compiler does some optimization that messes up line numbers slightly - be warned, this does happen.

So to understand, we need to look at the data actually passed to Console.WriteLine in program line 38.
If you used the data that I gave, ``s`` is ``"set {5}"``  and the expressions in the parameters evaluate to
``Console.WriteLine("string: set {5} \nTwice: {0}", "set {5}set{5}")``.  If you now look back at the description of the error, it talks about a bad index, and you see that the ``"{5}"`` embedded in the
*format string* is interpreted to be looking for a parameter with index 5, and there is none.

This particular example is a cautionary tale about
embedding an arbitrary string in a format string.  Format strings actually form an embedded language
inside of C#, which is interpreted at runtime, not compile time.

It turns out that there are major security issues with such embeddings in other circumstances.  For example 
embedding unfiltered user text in SQL queries is a major source of network intrusion.  This is still true after many years, though the exploit,
*SQL injection*, is well known! 

Line numbers are not tremendous help if the error line has a very involved calculation.  If you find an error on such a line, it pays to split it up and have a number of separate assignment statements (on different lines), and then see what part triggers the error.

.. index:: debugging; print statements

Other Debugging
----------------

Though we did use the error traceback for finding errors in ``traceback.cs``, we also threw in
the most basic way of tracing errors:  we have several print statements that just indicate where the execution is.  Can you find them?  Print statements are particularly useful to put in key places
when the program does *not* bomb out, but just produces the wrong answer.  
They can indicate location and current, possibly wrong values.  
You do want to remove the print statements before the final version!  Still they can be very handy during development.

They are also useful with involved statements.  You can split up a complicated statement, 
making multiple assignments
for important pieces, and print out the intermediate results.

Interpret the traceback for another error
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

What other kind of runtime error could be forced in the ``traceback.cs`` program?  The program uses
``UIF`` which in not bulletproof if you enter a response that is not planned for (unlike the UI class
coming later).

Cause a runtime exception running ``traceback.cs``, triggered in a call to a UIF function.  
Look carefully at the error traceback, and make sure you thoroughly understand it.




