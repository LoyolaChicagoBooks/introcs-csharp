Motivation for This Book
=========================

This is really a preface, but the otherwise very capable Sphinx publishing environment 
that we use is not set up for a separate preface.

Pedagogy
---------

Our first aim is to provide a good introduction and 
conceptual framework for more computer science, not an encyclopedic coverage of C#.  
C# will not be most students' only language, or necessarily the most used.  
Designing and creating algorithms in a particular language is an important skill, 
requiring ongoing effort, so most of the text is still centered on C#.

C# is an object-oriented language.  There is the ongoing argument about when to introduce 
details of object-oriented programming.  We last taught Java, objects first.  Students
dutifully followed our lead.  Later, we saw quick programs that students wanted 
to write for themselves, 
that were layered with totally unnecessary and distracting instances of objects.

We have seen less problem with the opposite order, which we use:
start off with more procedural programming, then introduce the use of
instances of existing classes of objects, and then move to designing
classes with instance variables, constructors, and instance methods,
and see where they are truly useful.  If you prefer, 
after the chapter on functions you can read the first couple
of sections in :ref:`Classes`, that 
cover defining your own simple objects.

We tend to introduce examples first, and then the general syntax, 
and then more examples and exercises. Later examples 
on a subject are sometimes essentially 
links to documented code that is both directly visible on the web and
in the separate download of all of the example source code. 

There are review questions at the end of most chapters.  
The review questions may seem to be in a strange order: Often we invite students
to consider a general overarching theme in an early question.  In case that
was too much to bite off, later questions often explicitly address a specific
point that would have been an implicit part of an earlier general question.
Sometimes a later more pointed question even gives an answer to part of 
an earlier question.

Labs are intended as early practice on a subject, with generally small 
bits requested at a time.  They are usually included in the main body 
of the book soon after the needed
background is introduced.  
There are also larger assignments as some of the appendix sections.

C# and Mono
------------

We have taught introductory programming for many years, 
through a progression of programming languages.  Our last language was Java,
still the language of the AP test, which drives so many introductory texts.

We had C# in mind:  It is a more modern language.  Its designers got to reflect
on the glitches with Java, and address them effectively.  

The key problem with C# used to be that it was totally a Microsoft language for Windows.
Many of our students have their own machines: many are OS-X machines from Apple;
some are Linux.
We did not want to cut those students off.  
Nor did we want to limit students to thinking of
a computer as a Windows machine.  Meanwhile the open source implementation
of C#, Mono, has been maturing, along with its tool chains.  

While many open-source tools have hackers jumping in to eliminate bugs, and maybe
providing enough documentation for a professional, documentation for a 
beginner is often lacking.  This book contributes there, partly in the
documentation for Mono's lovely interactive environment csharp, and also 
for the integrated development environment, Xamarin Studio.  
We show beginners how to start using the Xamarin Studio environment,
with its large array of features (not all needed by the
beginner), and introduce more features as needed.

We aim to end up with a book that provides a solid conceptual framework
for beginning computer scientists in the context of 
the clean, well-established modern language,  C#,
using multi-platform free and open-source 
tools, with clear documentation.

We hope that you find this to be a winning combination.
