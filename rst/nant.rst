NAnt and Automatic Compilation 
==============================

In a previous lab, we covered the basics of compiling and running programs using the Mono Compiler. For the most part, the programs we do in an introductory computer science class are simple. They comprise a single source file as opposed to the more common real-world case of *multiple* source files. Even so, for our course, we provide a number of utilities--a term that comes from infrastructure that we rely upon, such as electricity, natural gas, etc.--that help you to do various tasks that are somewhat tedious in the C# language. One example of this is the UI (user interface) class that helps you to read in various type of input, including numerical and text.

To make it possible to use our code while writing your own, we introduce NAnt, which is an automatic compilation system for .Net programs. NAnt is a program that accepts a *build* file as its input and uses this file to figure out how to compile your program. The *build* file is written in a language called XML (Extensible Markup Language), which is similar to the HTML language that you use to create web documents. The key difference between HTML and XML is the ability to create user-defined tags. For more information about this
language, see http://markuplanguages.courses.thiruvathukal.com.

An Really Simple Example NAnt Script
------------------------------------

Let's begin by taking a look at an example NAnt build script, which we'll use to compile the Hello, World
program that we have studied extensively:

.. literalinclude:: ../examples/hello+nant/hello.build
   :language: xml
   :linenos:

The basic structure of a *build* file is simple. We'll begin with a high-level explanation and then drill
into a bit more details. Then we'll look at a more advanced example toward the end of this section.

- Line 1 is the XML prologue. You need to make sure this line is present to indicate that this document is
encoded in XML version 1.0. Don't change it, and don't spend too much time thinking about what it means. 
You'll be seeing a lot more of XML in the future (beyond this class, that is).

- Line 2 is a required element of every *build* file. It is used to provide the basic info about your project
and what should be done to build it. In this example, the name is "Hello World" and the default target to 
build (when someone types nant at the command line) is "build". What this means is that the target named build (in line 12) will be the first thing that is processed when someone just types nant. 

- So Line 12 contains the "build" target, which uses the "csc" (compiler) task to compile the hello.cs program. Line 6 contains a rule that will remove all of the products that are built during compilation. That is, it will remove hello.exe and the .mdb and .pdb files (if present), which are used for symbolic debugging (another concept we discuss later).

Again, this is a quick explanation, and not all details have been presented. Before we go into all of those details, let's take a look at how we can *use* these files.

You are encouraged at this time to have downloaded all of the example programs. There should be a folder named ``examples/hello+nant``.

Building the example with NAnt
------------------------------

The following transcript shows a user (gkt) running nant to compile the Hello, World program. In this session,
the file Hello.build is present in the same folder/directory as hello.cs.

.. literalinclude:: ../examples/hello+nant/nant-build.txt
   :language: txt

When nant is run, you can observe that the Hello.build file is being used to copile the program. That's because NAnt *tells you* so by indicating the Buildfile it is using. Even though we did not use Hello.build anywhere on the command line, NAnt decided to look for it by finding *any* filename that ends in .build.

Once NAnt locates the build file, it reads it to determine that there is a target, build, that needs to
be executed. The line starting with ``[csc]`` indicates that the compiler is compiling 1 file (which we know is hello.cs, being the only .cs file in the folder) to hello.exe.

The most important thing to see in the output is the phrase, BUILD SUCCEEDED. This indicates that the program compiled successfully. If you don't see this message, it means that you need to go and correct the errors in
your program.

For completeness, we show the output of ls (dir on Windows) that clearly demonstrates that the resulting 
hello.exe file was created successfully. Because our compilation task is designed to create files needed for
symbolic debugging, you can seee that hello.exe.mdb is also present.

Removing the Build Products
---------------------------

An important part of developing programs in the real world is to not keep anything around permanently that could be built again later. This might sound a bit ironic, considering that when you purchase a program for your computer, the only thing you get (unless it is free/open source software) is the executable files, not 
the source code. 

But there is another reason you want to build your programs from scratch. You would want to begin by removing the executable code just in case you made a change to your C# code that somehow causes it not to build properly.
When might such a situation occur? Oh, perhaps it would happen around the time you need to submit your program to your instructor. By removing all of the build products and recompiling everything to make sure it fully works, you can rest assured that your program is ready to be submitted.

The following shows how to invoke the clean target to remove all of the stuff that we could easily rebuild from our source code.

.. literalinclude:: ../examples/hello+nant/nant-clean.txt
   :language: txt

In this case, we typed "nant clean" instead of "nant", because the default target is "build" (when we just type "nant"). You can observe that the clean rule is being executed and there are two lines beginning with the word ``[delete]`` that delete the files that are present, hello.exe and hello.exe.mdb. NAnt is smart enough do its work even if the .exe files are not present. That is, the delete task should be thought of as "delete if present".

So that's all there is to NAnt, at least if you are building simple programs. For COMP 170, we provide a 
*generic* build script in the ``examples`` folder that you can use for just about all of your work, except
when you get to the more advanced class project, where you might need to add some code to the build 
target. Luckily, we have already gone through and done much of the work for you, but you may still find yourself needing to make modifications to our build files.

Here's our generic build file:

.. literalinclude:: ../examples/hello+nant/Generic.build
   :language: xml
   :linenos:

(George is still working on this part of the write-up.)

This will eventually become a page about NAnt. It is not linked to the
table of contents and hasn't even been started. 

These are some notes from the original README.nant file.

How to build examples manually.

nant -D:program=birthday1

To clean any example you no longer want, do this:

nant -D:program=birthday1 clean

The resulting executable/debug data goes to the "bin" subdirectory

If on Linux/OS X, I have two convenience scripts. Someone can feel free to
create a .bat version for Windows.

sh build.sh birthday1
sh clean.sh birthday1


