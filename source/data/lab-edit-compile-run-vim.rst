.. index:: Vim
   labs; Vim
   command line
   dotnet command

.. _lab-edit-compile-run-vim:

Lab: Editing, Compiling, and Running with Vim
=============================================

This lab shows how to create, edit, compile, and run a small C# console
program using only a terminal, Vim, and the .NET command-line tools.  The same
basic workflow also works with another terminal editor such as ``emacs``:
edit the source file, save it, build it, and run it.

Prerequisites
-------------

Install the .NET SDK before starting.  It provides the ``dotnet`` command used
to create, build, and run C# projects.

Microsoft's `.NET command-line interface documentation <https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet>`_
describes the ``dotnet`` command and its subcommands, including ``dotnet new``,
``dotnet build``, and ``dotnet run``.

Check your installation:

.. code-block:: none

   dotnet --version

You should see a version number.  If you get a "command not found" message,
install the .NET SDK or fix your terminal path before continuing.

Create a Project
----------------

Choose a folder where you want to keep your course work.  In a terminal, move
to that folder and create a new console project:

.. code-block:: none

   mkdir hello-vim
   cd hello-vim
   dotnet new console --use-program-main

The ``--use-program-main`` option creates a program with an explicit class and
``Main`` method.  That matches the style introduced in this book.

Edit the Program with Vim
-------------------------

Open the source file:

.. code-block:: none

   vim Program.cs

Vim starts in *normal mode*.  In normal mode, keys are commands.  To type text,
press ``i`` to enter *insert mode*.

For this lab, replace the whole file with:

.. code-block:: csharp

   using System;

   class Hello
   {
      static void Main()
      {
         Console.WriteLine("Hello, world!");
      }
   }

One simple way to replace the generated file is:

#. Press ``gg`` to go to the first line.
#. Press ``dG`` to delete from the current line through the end of the file.
#. Press ``i`` to enter insert mode.
#. Type or paste the program above.
#. Press the Escape key to return to normal mode.
#. Type ``:wq`` and press Enter to save and quit.

If you make a mistake and want to quit without saving, press Escape, type
``:q!``, and press Enter.

Build the Program
-----------------

Back at the terminal prompt, build the project:

.. code-block:: none

   dotnet build

If the build succeeds, you should see a message ending with something like:

.. code-block:: none

   Build succeeded.

If the build fails, read the first compiler error carefully.  Reopen the file
with ``vim Program.cs`` and check for common mistakes: missing semicolons,
mismatched braces, misspelled names, or quotes that do not match.

Run the Program
---------------

Run the project:

.. code-block:: none

   dotnet run

You should see:

.. code-block:: none

   Hello, world!

The regular cycle is:

#. Edit: ``vim Program.cs``
#. Save and quit: Escape, then ``:wq``
#. Build: ``dotnet build``
#. Run: ``dotnet run``

For small programs, you may often go directly from editing to ``dotnet run``.
The ``dotnet run`` command builds first if the source code has changed.

Useful Vim Commands
-------------------

These commands are enough for early labs:

================  ===============================================
Command           Meaning
================  ===============================================
``i``             Enter insert mode before the cursor
Escape            Return to normal mode
``:w``            Save the file
``:q``            Quit
``:wq``           Save and quit
``:q!``           Quit without saving
``dd``            Delete the current line
``u``             Undo
``/text``         Search forward for ``text``
================  ===============================================

Exercise
--------

Modify the program so that it prints two separate lines.  Build and run it.
Then intentionally remove one closing brace, build again, and read the compiler
error.  Restore the brace and verify that the program runs.
