Development Tools
=================

About Software Development Kits (SDKs)
--------------------------------------

A software development kit (SDK) is a set of tools for developing in a
particular programming language (in our class, C#). Developing in a
language means everything from compiling to running and (when things
go wrong) to debugging programs. 

The Microsoft SDK is the proprietary implementation of .Net. It runs
only on Windows and is the primary development framework for all
things Microsoft.

The Mono Project SDK <http://mono-project.com> is the free/open source
equivalent implementation of the Microsoft SDK. 
It runs on all major platforms (including Windows) and is needed in situations 
where you want to develop .Net applications on non-Windows platforms.

As an interesting aside, the company whose developers lead the work on
the Mono SDK are working on commercial tools that allow you to
develop/run applications written in .Net on Apple iOS and Android
mobile devices (phones and tablets).

Editing and Building Tools
--------------------------

Early programs were written with rudimentary text editors, 
more primitive than Windows Notepad.  Gradually tools got better.
Now there are editors that are highly optimized for editing code.

After code is edited, it has to be converted into an executable program.
That may involve several files and libraries and other dependencies.
Streamlining and automating this process was a big deal.  There
are a variety of building tools that can be used with, or built into
an SDK:  make, ant, and now NAnt for .net.

Many developers use an a la carte approach, using their favorite editor along
with their favorite building tool.  In these notes we will discuss
the editor :ref`jEdit`, and the build tool *NAnt*.
 
About Integrated Development Environments (IDE)
-----------------------------------------------

There are also all-in-one tools that combine an editor and build tools.
These are also used by many developers.

There are two major IDEs for .Net development, which we explain briefly below:

- Visual Studio is the Microsoft IDE that interfaces directly to the
  Microsoft SDK.

- MonoDevelop is the free/open source IDE for developing applications
  using the Mono SDK on Windows and all other platforms (in
  particular, Linux and OS X).

In addition, there is another Windows-specific IDE, SharpDevelop, that
inspired the creation of MonoDevelop. It is still actively maintained
and provides a somewhat "lighter weight" alternative to Visual Studio
for Windows users. Like MonoDevelop, it is aimed at developers who
would prefer a more free/open source "friendly" version.

Our Approach
------------

In the interest of providing a consistent experience for our students,
we will be using the multi-platform Mono (the SDK), which comes with the build tool NAnt.
You can use a variety of editors, but we will introduce :ref:`jEdit` as a
free, convenient, multi-platform alternative.

MonoDevelop could be used, but while its defaults may be OK for very complex projects, 
they are highly constraining for projects at this level.

Our notes assume for the most part that you are working with Mono and NAnt.  The
editor is less critical, though we will discuss jEdit.

Mono has an extra advantage in the tool csharp, which has a rough analog 
in Microsoft's tools but in a somewhat
limited form. 

As there is significant evolution of both the Microsoft
and Mono *toolchains*--a fancy word we want you to know and a more
elegant way of saying SDK--we'll issue updates to these notes.


Installing Mono
---------------

Because the Mono Project web page is known to change frequently, these
instructions are designed to be as generic as possible. If you have
any questions, you should contact the instructors immediately or seek
tutoring help.


OS X
----

#. Go to <http://mono-project.com>.

#. Look for the Mono downloads link. You want to get the latest *stable*
   version of Mono for OS X. For this class, you need version 2.10 or
   later.

#. You may see a link to download *Runtime* or *SDK*. Make sure you select SDK.

#. For OS X, the SDK is distributed as a DMG disk image. You'll need
   to download this image and double-click it. Open the image and run
   the installer. Administrative privileges are required to run the
   installer, so if you do not know this information, please stop
   here.   

Here is how to do a quick sanity check of your Mono setup:

#. Go to Applications -> Utilities and launch the Terminal
   application. (Terminal is how you get to a command-line shell in OS X.)

#. You'll see a prompt that looks like this 
   ``computername:folder user$``. 
   This means that Terminal is ready for input.

#. Type ``which csharp`` and hit enter/return. You should see
   ``/usr/bin/csharp`` as output. ``csharp`` is the C# interpreter.

#. Type ``which dmcs`` and hit enter/return. You should see
   ``/usr/bin/dmcs`` as output.  ``dmcs`` is one of the interfaces to
   the C# compiler.

Optional Mono-develop Installation
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#. Make sure Mono is installed first. 

#. Now go to <http://mono-develop.com>.

#. As with Mono, we need to look for the downloads link. 
   You should download the *stable* version.

#. As with Mono, you will see a DMG file, 
   which you should download and double-click to mount on your desktop.

#. This time, you will see an App for MonoDevelop, 
   which you can drag and drop into the Applications folder.

#. If the preceding steps were successful, you can launch
   MonoDevelop by double-clicking the icon in your Applications
   folder. (You won't know what to do with it yet, but at least you can
   verify that it launches correctly and then use Command-Q to exit.)

Windows
-------

#. Go to <http://mono-project.com>.

#. Look for the Mono downloads link. You want to get the latest
   *stable* version of Mono for Windows. For this class, you need version
   2.10 or later.

#. You may see a link to download *Runtime* or *SDK*. Make sure you select SDK.

#. For Windows, there is only one option to download the SDK. It is a
   self-extracting executable, so you will need to double click it to
   install. For Vista and 7 users, you may need to check your taskbar to
   see whether the installer is being held up by Microsoft's enhanced
   security, UAM, that makes sure you really want to install something
   you downloaded from the internet.

Here is how to do a quick sanity check of your Mono setup:

#. Open the Start Menu and type "mono" in the text field at the bottom.  
   You should see a short list places "mono" appears.
   
#. Click on the choice that says "Mono 2.10... Command prompt".  
   If it comes up, you are all set.  
   Close the window, or save it for later use....
   You can also find the program in the Start Menu manually,
   finding the Mono folder, expanding it, and clicking on]
   the Mono Command Prompt.

Optional Mono-develop Installation
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#. Make sure Mono is installed first. 

#. Now go to <http://mono-develop.com>.

#. As with Mono, we need to look for the downloads link. You should
   download the *stable* version.

#. As with Mono, you will see a self-extracting installer, 
   which you should run as before.

#. If the preceding steps were successful, you can launch
   MonoDevelop by double-clicking the icon in your Applications
   folder. (You won't know what to do with it yet, but at least you can
   verify that it launches correctly and then close the window.
   Ctrl-Q is a shortcut.)


Linux
-----

We only provide instructions for Debian-based Linux distributions such
as Ubuntu.

#. Using the command-line ``apt-get`` tool, you can install everything
   that you need using ``apt-get install monodevelop``. This should be
   run as the **root** user (using the ``sudo`` command).  If you
   do not want monodevelop, it is enough to use
   ``apt-get install mono``.

#. You can test the sanity of your setup by following the instructions
   under OS X.

MonoDevelop releases on Linux tend to lag behind the official stable
release. 

This page,
https://launchpad.net/~keks9n/+archive/monodevelop-latest, 

describes
how to update your MonoDevelop setup if it is not version 2.8 or later
as we'll need for this course.

We wish to stress that Linux is recommended for students who already
have a bit of programming experience under their belts. It can take a
significant amount of energy to get a Linux setup up and running and
to tweak it to your liking. While it has gotten ever so much easier
since the 1990s when it first appeared, we encourage you to set it up
perhaps a bit later in the semester or consider running it using
virtualization software (on Mac or Windows) such as VirtualBox or
VMware.
