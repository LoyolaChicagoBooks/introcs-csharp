.. index:: command line

.. _commandline:

Command Line Introduction
==========================

We will be directing you to use a command window or terminal to compile and run
C# programs.

Reasons to use the command line:

- The command line precedes the graphical user interface (GUI) used in
  modern operating systems and provides a simpler interface for input and output
  that is very flexible and powerful for *knowledgeable* users.

  + Input comes from the keyboard as typed characters (no mouse processing).
    Commands are only processed once you press :kbd:`Enter`.

  + Output goes to the monitor as textual information (no window processing).

  + In C# these input/output mechanisms are called Console processing.

  + Input from and output to files is done in a very similar way, simplifying learning.

- Many software development organizations use command line processing
  to automate creating, compiling (“building”), and running or executing
  software programs.

  + Command line “scripts” can be created to automate routine tasks.

  + Command line scripts are similar to C# and other computer programs.

  + Serious software developers should be familiar with the command line.

Accessing the command line (often called a *command shell*):

- On Windows, to have easy access to Mono tools,  
  press the Windows key (lower left or lower right on the
  keyboard) and type Mono, then select the 
  Mono Command Prompt and press Enter.
  
  Alternately, if you do *not need Mono tools for sure*, the general way to 
  get a command window is to press the Windows key
  and R (lower or upper case) together, then type *cmd* and
  press the Enter or Return key – this brings up the basic command
  processing program, cmd.

- On a Mac just open a Terminal window – this is fine for the Mono SDK
  commands.
  
Mac OSX, Linux and other Unix variants work basically the same once
you get to a terminal, so we will only distinguish Windows and Mac OS-X.

.. index::
   double:  command line; paths

.. _file-and-directory-paths:

File and Directory Paths
------------------------

In a command shell there is always a *current working directory*, usually
shown in the prompt for a the next command.  
When you open a Mono Command Prompt or Terminal window you will see
a prompt that tells you what folder or directory the command shell has
started in: In Windows 7 this is typically C:\\Windows\\System32, and on
a Mac it is typically /Users/*yourLogin*.  

.. index:
   double: command line; dir
   double: command line; ls
   
Files in the current working directory can to referred to by their simple names,
e.g., *myfile.txt*.  You can list all the files in the directory with the simple
command ``dir`` (short for directory) in Windows or ``ls`` (short for list) on a Mac.

You will see below that you can change the current
directory with the *cd* command.

Referring to files not in the current directory is more complicated.  
Files and  directories are located in the hierarchy of directories in the
file system.  On a Mac, the file system is unified in 
one hierarchy. On Windows there may be several drives, and you need to start a
path reference with a drive, like C:, if it is not the current drive.

Files are generally referred to by a chain of directories before
the final name of the file desired. Elements of the directory chain are separated
by operating system specific punctuation:  In Windows the separator is backslash, \\,
and on a Mac it is (forward) slash, /.  For example on a Mac the path 
 
   /Users/anh 
   
starts with a /, meaning the *root* or top directory in the hierarchy, and Users is
a subdirectory, and anh is a subdirectory of Users (in this case the home directory
for the user with login anh).  
It is similar with Windows, except there may be a drive in the beginning,
and the separator is a \\, so

   C:\\Windows\\System32

is on C: drive; Windows is a subdirectory of the root directory \\, and System 32 is
a subdirectory of Windows.

The starting directory in Windows is unfortunate.  You are likely to want to operate
out of your home directory (where the Mac users start automatically).

For Windows 7 or 8 users enter the command below (substituting your login ID):

.. code-block:: none
   
   cd C:\Users\yourLoginId
   
The cd is short for "Change Directory", changing the current directory.

.. warning::

   Windows only: 
   The cd command does not work the way you are likely to think about it on
   a Windows system with more than one drive (like C: and flash drive E: that you have
   plugged in).  Windows remembers a separate current directory for each
   separate drive.  It also *separately* remembers a *current drive*.  
   *You do not change the current drive with the cd command.*  
   The command to change the current drive is just the name of the
   drive with a colon after it.  For example the command
   
   .. code-block:: none
       
       E:
   
   sets the current drive to E:, and the active directory is the
   current directory on E:.
   
   However, if the current drive is C:, and you enter the command
   
   .. code-block:: none
       
       cd E:\comp170
      
   then you change the current directory on E:, but *the current drive remains C:*.
      

Since there is always a current directory, it makes sense to allow a path to be *relative*
to the current directory.  In that case do not start with the slash that would
indicate the root directory.  For example, if you are in you home directory,

   ``dir Downloads`` (Windows) or ``ls Downloads`` (Mac) would list the 
   subdirectory of the current directory, Downloads.
   
If the Downloads directory contained a file, ``myFile.txt``, you could refer to it 
in commands as ``Downloads\myFile.txt`` or  ``Downloads/myFile.txt`` on a Mac.

Referring to files in the current directory just by their plain file name is
actually an example of using relative paths.

With relative paths, you sometimes want to move up the directory hierarchy:  ..
(two periods) refers to the directory one level up the chain.  

For example, if the examples directory has subdirectories hello and arrays, 
and the current directory is hello, then  .. refers to examples and 
..\\arrays or ../arrays on a Mac refers to the arrays directory.

Occasionally you need to
refer explicitly to the current directory:  it is referred to as "." (a single
period).

Suppose you don’t know the path to your *hello* directory on Windows, but can 
you can find it in an Windows Explorer window (right clicking on Start); 
here’s how to
provide that path to the *cd* command:

- Depending on the setup of your options, in the address bar you may *not* see a clear
  path with a drive and backslashes.  In that case generally clicking to the right of any
  directory in the path converts the view to the version we use on the
  command line.
- When you see a full absolute path, you can just note it and manually copy it,
  or select it all and copy it, and follow the instructions in :ref:`copypaste` to later
  paste in the command window.
- In any case click in the Mono Command Prompt window, type *cd* and a space, then
  type or paste the path.
- Of course, you can also go the other way – if you see the current
  directory name in the Windows prompt, type that into an Explorer address
  bar to see its contents in a GUI window

On a Mac there is an easier shortcut:
  
- Type *cd* and a space to start the command in the terminal
- Locate the directory you want in the Finder (not opening the directory).
- Drag the directory icon to the terminal.  The path gets pasted! Press return.

Common Commands
----------------

The command shell is now waiting for you to type in a *command* (a
short name that the shell recognizes) followed by 0 or more *parameters*
separated by spaces (and Enter).  
Note that if a parameter contains spaces you must surround the
parameter value with matching single or double quotes – you’ll see an
example later.

We are going to mention some of the simplest uses of basic commands.  More
advanced documentation would include more options.

Some commands are common between the Windows and Mac shells:

dir or ls
  to list all the files a in the current directory or a named directory.
  
.. index:
   double: command line; cd

cd 
  stands for change directory – you can use this
  command to change the current working directory to a different one.

  You can use this command to change to directories where your C#
  program source files are located, if different from the initial
  directory.

  On Windows, suppose you created a directory C:\\COMP170\\hello; to
  change to that, type *cd C:\\COMP170\\hello* and press Enter – the shell
  prompt will change to show this new directory location and programs like
  *gmcs* and *mono* will be able to “see” (access) files there, directly
  by name.  If the Comp170 directory was you current directory, it would
  be shorter to use relative paths and just ``cd hello``.

  On a Mac you can also use either an absolute or a relative path with ``cd``.

  If you included a space in one or more of the directory names, for
  example C:\\COMP 170\\hello (a space between COMP and 170) you should
  enclose that part(s) in quotes like so: *cd C:\\"COMP 170"\\hello*

  Mac Note: if you type just *cd* and press Enter you will change back to
  your home directory.  There is also a shorthand name for your home
  directory in command paths:  tilde (~), often shifted backquote.

.. index:
   double: command line; mkdir

mkdir
  stands for make directory –
  you can use *mkdir* to create a new empty directory in the current
  directory.

  For example, on a Mac with current directory /Users/*YourLogin*,
  type *mkdir hello* and press Enter – this will create a new directory
  /Users/*yourLogin*/hello if it did not exist before; you can now create
  a C# source file in that directory and enter *cd hello* in the command shell.
  
  An optional Windows abbreviation is *md*.

.. index:
   double: command line; rmdir

rmdir
    removes an *empty* directory that you give as parameter, e.g.,
    
       rmdir hello

Then, with Mono installed (and for Windows, with a Mono command window), the
programs associated with Mono can be used:

gmcs
  compiles one or more listed C# source files without using MonoDevelop.

csharp
  is the interactive C# statement testing program.
  
Other useful commands window commands with different names for Windows and Mac,
listed by generic function, with general Windows syntax first and Mac second, and then
often examples in the same order:

.. index:
   double: command line; display text file
   double: command line; type
   double: command line; cat

Display the contents of a text file in the command window. Name origin:  a more complicated
use of cat is to con\ **cat**\ enate files. 

  | type *textFileName*
  | cat *textFileName*
  
  | type my_program.cs
  | cat my_program.cs

.. index:
   double: command line; copy file
   double: command line; cp

Make a copy of a file.  Caution: If the second file already exists, 
you wipe out the original contents!

  | copy *originalFile*  *copyName*
  | cp *originalFile*  *copyName*
  
  | copy prog1.cs prog2.cs
  | cp prog1.cs prog2.cs
  

.. index:
   double: command line; delete a file
   double: command line; del
   double: command line; cat
 
Erase or remove a file:

  | erase *fileToKill*
  | rm *fileToKill*
  
  | erase poorAttempt.cs
  | rm poorAttempt.cs


Another Windows equivalent is ``del`` (short for delete).

.. index:
   double: command line; help
   double: command line; man

Help on a command:

  | help *commandName*;
  | *commandName* --help
  
Note the double dash above: This 
sometimes works for concise help on a Mac while you can generally get
immensely detailed help overload on a Mac from

   man *commandName*

.. index:
   double: command line; script
   
Scripts
-------

This is not a subject of this course, but commands can be combined into
script files.  

Scripting languages are in fact whole new specialized programming languages, 
that include many of the types of
programming statements found in C#.

.. index:
   double: command line; copy text
   double: command line; paste

.. _copypaste:

Copy and Paste
---------------

Copying or pasting with a Mac is is the same with a terminal as in other editing:  
Use the same Apple Command key with C or P, and you can select with the mouse. 

In Windows it is more complicated to use a command window:  
You can paste into the current command line by *right*
clicking on the Command Window Title bar, and select edit and then paste.  

By default
a Windows command window is not sensitive to the mouse.  
You can change so that it is sensitive
for select and copy:  Right click in the title bar, select defaults, and make sure
the check boxes under edit options are *all* checked.  
(The last two are explained in the next section.)
Click OK.  Then you can select with 
mouse and press Enter for the selection to be remembered in the copy buffer.

.. index::
   double: command line; shortcuts
   double: command line; file completion
   double: command line; history

Command Line Shortcuts
-----------------------

Both Windows and Mac (with the right options selected, 
like the Windows check boxes in the last section), allow you to reduce typing:

You can bring back a previous command for the history of commands that are automatically
remembered: Use the up and down arrows.  This makes it very easy to run the same command
again, or to make slight edits.

Both Windows and OS-X can see what files are in any directory being referred to.
If you just start to type a file or folder name and then press the Tab key, both
Windows and  OS-X will do *file completion* 
to complete the name if there is no ambiguity.  If there is ambiguity,
they work differently:  

- Windows will cycle through all the options as you keep 
  pressing Tab.  
- On the first tab OS-X will do nothing but give a sound if there is 
  ambiguity, but the second tab will list all the options.  Then you need to type enough
  more to disambiguate the meaning.
