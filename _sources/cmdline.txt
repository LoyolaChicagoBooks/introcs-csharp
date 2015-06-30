.. index:: command line

.. _commandline:

Command Line Introduction
==========================

Sometimes we will be directing you to use a command window or terminal to 
compile and run
C# programs. [#RYacobellis]_

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

The most direct way to access the command line (often called a *command shell*):

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

.. index:: command line; paths
   paths on command line  

.. _navigating-directories:

Navigating Directories
---------------------------

First make sure you are familiar with :ref:`path-strings`.

In a command shell there is always a *current working directory*, usually
shown in the prompt for the next command.  
When you open a Mono Command Prompt or Terminal window you will see
a prompt that tells you what folder or directory the command shell has
started in: If you directly open a terminal as in the previous section,
in Windows this is typically C:\\Windows\\System32, and on
a Mac it is typically /Users/*yourLogin*.  

Particularly on windows, this is an annoying folder.  There are several ways 
to get to a better location.

If you can get to a parent folder of a folder that you want in a Windows Explorer window 
(by right clicking on Start) or Mac Finder, there are shortcuts to opening a terminal
with the current directory being one shown in the graphical window:

Windows
   #. Note: this approach does *not* give your a Mono command prompt.
   #. In Windows explorer navigate to the parent folder, 
      showing the folder you want as a subfolder.
   #. Hold down the shift key and *right* click on the desired folder.  
      A popup menu appears.
   #. Click on "Open a Command Window here".

Mac
   #. In the Finder navigate to the parent folder, 
      showing the folder you want as a subfolder.
   #. Hold down the control key and click on the desired folder.  
      A popup menu appears.
   #. Click on the bottom item Services, to get a submenu.
   #. In the submenu click on "New Terminal at Folder" (likely the bottom entry).
   


.. index:: command line; dir and ls
   dir on Windows command line 
   ls on Mac command line
   
Files in the current working directory can to referred to by their simple names,
e.g., *myfile.txt*.  You can list all the files in the directory with the simple
command ``dir`` (short for directory) in Windows or ``ls`` (short for list) on a Mac.

You need to refer to files not in the current directory via a relative or absolute
path name.

After starting in one folder, you may well want to change the current folder 
without opening a new terminal window.  This is particularly true if you
start with a Windows Mono command prompt.
You will see below that you can change the current
directory with the *cd* command.

On a Mac, the file system is unified in 
one hierarchy. On Windows there may be several drives, and you need to start a
path reference with a drive, like C:, if it is not the current drive.

When you run cmd or start a Mono command prompt in Windows, 
you are likely to want to get to
your home directory (where the Mac users start automatically).

Windows 7 or 8 users enter the command below (substituting your login ID)
to get to your home directory:

.. code-block:: none
   
   cd C:\Users\yourLoginId
   
The cd is short for "Change Directory", changing the current directory.

.. index:: drive change on Windows

.. _drive-change:

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
      
We described above how you can use a Windows Explorer/Finder folder to
open a *new* terminal.   
If you just want to change 
directory in an existing terminal, there is also a shortcut to copy a long 
folder name, given a Windows Explorer/Finder folder:

Windows   

- Depending on the setup of your options, in the address bar you may *not* see a clear
  path with a drive and backslashes.  In that case generally clicking to the right of any
  directory in the path converts the view to the version we use on the
  command line.
- When you see a full absolute path, you can just note it and manually copy it,
  or else select it all and copy it 
  and follow the instructions in :ref:`copypaste` to later
  paste in the command window.
- In any case click in the terminal window, type *cd* and a space, then
  type or paste the path.
- Of course, you can also go the other way – if you see the current
  directory name in the Windows prompt, type that into an Explorer address
  bar to see its contents in a GUI window.

On a Mac there is an easier shortcut:
  
- Type *cd* and a space to start the command in the terminal
- Locate the directory you want as a subfolder in the Finder 
  (not opening the directory).
- Drag the directory icon to the terminal.  The path gets pasted! Press return.

Common Commands
----------------

The command shell waits for you to type in a *command* (a
short name that the shell recognizes) followed by 0 or more *parameters*
separated by spaces (and Enter).  
Note that if a parameter contains spaces you must surround the
parameter value with matching single or double quotes – you’ll see an
example later.

We are going to mention some of the simplest uses of basic commands.  More
advanced documentation would include more options.

Some commands are common between the Windows and Mac shells:

dir (Windows) or ls (Mac)
  to list all the files a in the current directory or a named directory.
  
.. index:: command line; cd
   cd on command line
   change directory on command line 

cd 
  stands for *Change Directory* – you can use this
  command to change the current working directory to a different one.

  You can use this command to change to directories where your C#
  program source files are located, if different from the initial
  directory.

  On Windows, suppose you created a directory C:\\COMP170\\hello; to
  change to that, type *cd C:\\COMP170\\hello* and press Enter – the shell
  prompt will change to show this new directory location and programs like
  *mcs* and *mono* will be able to access files there, directly
  by name.  If the Comp170 directory was you current directory, it would
  be shorter to use relative paths and just ``cd hello``.  Remember if
  you want a different Windows drive, you must first use a 
  :ref:`drive change command <drive-change>`.

  On a Mac you can also use either an absolute or a relative path with ``cd``.

  If you included a space in one or more of the directory names, for
  example C:\\COMP 170\\hello (a space between COMP and 170) you should
  enclose that part(s) in quotes like so: *cd C:\\"COMP 170"\\hello*

  Mac Note: if you type just *cd* and press Enter you will change back to
  your home directory.  There is also a shorthand name for your home
  directory in command paths:  tilde (~), often shifted backquote on the
  keyboard. Sorry,
  no such thing with Windows.

.. index:: command line; mkdir
   mkdir on command line

mkdir
  stands for make directory –
  you can use *mkdir* to create a new empty directory in the current
  directory.

  For example, on a Mac with current directory /Users/*YourLogin*,
  type *mkdir hello* and press Enter – this will create a new directory
  /Users/*yourLogin*/hello if it did not exist before; you can now create
  a C# source file in that directory and enter *cd hello* in the command shell.
  
  An optional Windows abbreviation is *md*.

.. index:: command line; rmdir
   rmdir on command line

rmdir
    removes an *empty* directory that you give as parameter, e.g.,
    
       rmdir hello

With Mono installed (and for Windows, with a Mono command window), the
programs associated with Mono can be used:

.. index:: command line; mcs
   mcs compile on command line
   compile on command line mcs
   
mcs
  compiles one or more listed C# source files without using Xamarin Studio.

csharp
  is the interactive C# statement testing program.
  
Other useful commands, with different names for Windows and Mac,
are listed next by generic function, 
with general Windows syntax first and Mac second, and then
often examples in the same order:

.. index:: command line; display text file
   type on Windows command line 
   cat on Mac command line 

Display the contents of a text file in the command window. The Unix/Mac
name origin:  a more complicated
use of cat is to con\ **cat**\ enate files. 

  | type *textFileName*
  | cat *textFileName*
  
  | type my_program.cs
  | cat my_program.cs

.. index:: command line; copy file
   copy on Windows command line 
   cp on Mac command line 
   

Make a copy of a file.  Caution: If the second file already exists, 
you wipe out the original contents!

  | copy *originalFile*  *copyName*
  | cp *originalFile*  *copyName*
  
  | copy prog.cs prog_bak.cs
  | cp prog.cs prog_bak.cs
  

.. index:: command line; delete a file
   erase on Windows command line 
   rm on Mac command line 

Erase or remove a file:

  | erase *fileToKill*
  | rm *fileToKill*
  
  | erase poorAttempt.cs
  | rm poorAttempt.cs


Another Windows equivalent is ``del`` (short for delete).

.. index:: command line; help
   help on command line 
   man on Mac command line 

Help on a command:

  | help *commandName*;
  | *commandName* --help
  
Note the double dash above: This 
sometimes works for concise help on a Mac while you can generally get
immensely detailed help overload on a Mac from

   man *commandName*

.. index:: command line; script
   script on command line 
   
Scripts
-------

This is not a subject of this course, but commands can be combined into
script files.  

Scripting languages are in fact whole new specialized programming languages, 
that include many of the types of
programming statements found in C#.

.. index:: command line; copy and paste text
   copy text on command line
   paste text on command line 

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

.. index:: command line; shortcuts
   shortcuts on command line 
   file completion on command line
   history on command line

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


.. [#RYacobellis]

   Thanks to Dr. Robert Yacobellis for elaborations to this section.