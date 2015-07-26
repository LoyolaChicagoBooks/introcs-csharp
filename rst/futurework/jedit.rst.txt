.. index::
   double: editor; jEdit
   
.. _jedit:

jEdit
===========

C# programs are just plain text files, so you can write C# programs 
with any editor that can produce such files.

There are many modern editors that know about the syntax of particular programming
languages.  This allows color highlighting, automatic indentation, 
and sometimes fancier features.  These extra features can be a great help in
editing.

We choose to note an editor, *jEdit*, for several reasons: 

- free and available for all common platforms  
- basic menu/mouse operation similar to common editors, for an easy start
- comes knowing specializations for C# syntax
- fancier handy features can be learned as you get more experience
- customizations can be saved elsewhere from your home directory 
  (useful in Loyola Windows labs)
  
Downloads for Windows and Mac are available at http://www.jedit.org/.  On the downloads 
page, choose the Windows Installer or the Mac OS X package under "Stable Version", 
and follow the default installation path.

Ubuntu Linux users can install it from their standard app installer.

.. warning::
   If you are in a Loyola Windows Lab, jEdit is already installed, but 
   *do not start it from the start menu*.  Instead copy
   labJEdit.cmd from the examples folder to your
   permanent P: drive.  Double click on *that* file to start jEdit.
   This will make sure that any personal setting you make in the program
   are retained for you on P: drive for the next time you log on 
   *and use labJEdit.cmd again*.  If you are on your personal machine, you do not
   need to worry about this.
    
Http://www.jedit.org/ includes full documentation, 
but much of it is for advanced features 
unlikely to be used in a programming introduction,  
and the advanced feature descriptions are mixed in with the basics,
so a brief, basic introduction is given below.

The menus have all the common options of other editing environments:  

- :menuselection:`File`: new, open, save, save as, close
- :menuselection:`Edit`: undo, redo, cut, copy, paste, select all
- :menuselection:`Search->Find` (includes replace)

As you get experience, the mouse commands are more efficiently 
executed via keyboard shortcuts that are shown after many menu items.
The left half of the icon heading row are also mapped to common commands. 

Some conventions are slightly different than many other editors:

- :menuselection:`File->Save Copy As...`
  saves a copy to a specified location, 
  but (unlike :menuselection:`Save As...`) 
  does *not* change the name of the file 
  being worked on in the editor.
- Look at the Redo keyboard shortcut - it is not the usual one.
- :menuselection:`Search->Find` can do both find and replace.
- There is not the common direct correspondence between open files and visible
  editing regions.
  
The last point needs some further explanation:

Files/Buffers/Views
--------------------

JEdit has windows, like other common programs, and you can show files in several
(possibly overlapping) windows if you like.  JEdit also allows a single window to be split 
into several *views*, splitting a larger previous view either horizontally or
vertically. See the icons at the top of the window
showing a screen with a horizontal or vertical split, or
go to View->Splitting and see more elaborate options.  

Each view has a heading line naming the file shown below.

In many editors, there is always one visible area showing you part of any file 
that you are working on.  With jEdit, being in memory is independent 
of the number of places the file is displayed (0, 1, or more places).  If you click on
the heading of a view you see a list of all the open files, and you can 
select a different one to display, replacing the previous one in that view.

When you split a view, you get the original file displayed in both smaller
views. 

It is sometimes convenient to keep two views of a large file, but more commonly
you will want to replace one of the duplicate views by opening a new file or
clicking on the heading and switching to another current file in memory.

One view can be split into a left and right view.  Between the headings of two views
is a small icon
pointing both left and right.  Clicking this undoes the corresponding split.  Similarly,
when a view has been split into top and bottom parts,
there is an icon pointing up and down just above the bottom view .  
Unfortunately neither of these little icons have a
tool tip reminding you of their use.

In the icon row at the top, there is also an icon just to 
the left of the splitting icons that collapses all views in a window into one.

If yo use :menuselection:`File->Close` or its keyboard shortcut, 
you completely remove the file from
jEdit.

C# Specific Features
--------------------


If you are in a Loyola Windows Lab, make sure you started
jEdit as instructed above, or the following steps will not
stick!

There are very nice features for C#.  
They involve some choices that you can set globally,
affecting every C# file you *later* open:

#. Go to :menuselection:`Utilities->Global Options...` and pop up the Options dialog.
#. In the left column under "jEdit" select "Editing".
#. Set the field for "Tab Width" to 3.
#. Set the field for "Indent Width" to 3.
#. Beneath that line are three check boxes.  The top one, "Soft ... Tabs", 
   should be checked but not the other two.
#. Further down the list, click in the field for "Default Edit Mode".
   You get a drop-down list.  Select c#.
#. Click OK.

Now when you start a new file or open an existing C# file, jEdit behaves
differently.

Basic display:

- You should see keywords and comments in special colors.
- String literals and multiline string literals should have their own colors.
- When you have your cursor directly after a delimiter character 
  ``{}()[]``, a box appears around the matching delimiter.
  
It is easy to forget the terminal quote on a literal, and
that mistake may not be associated with good error messages.  The literal coloration
makes this error easy to spot and fix!

Basic Editing:

- When you press the Return key:

  * after an open brace, the indentation should increase by 3 spaces
  * after a single close brace, it should move the brace to line up properly
  * in other situations, the previous indentation should be maintained.

- When you press the tab key, 

  * if the cursor is before the first nonblank character of a line, 
    with nothing selected, you indent the line.
  * if parts of more than one line are selected, you should indent each of
    these lines further.

- When you press Shift-Tab, the reverse happens, unindenting.

This means proper indentation is mostly kept for you automatically,
and you rarely need to adjust it by hand.  When you do need to adjust
it by hand, you often want to shift a whole block of code at once,
and tab and shift-tab on a block are very handy. 

As you'll come to learn in programming, different communities have
different conventions. The folks who make another open source C# tool,
known as SharpDevelop (not used in this class but an awesome project)
have their own style guide that is particularly well written. See
http://www.icsharpcode.net/technotes/sharpdevelopcodingstyle03.pdf.

Fancier editing tools:

- When you select parts of one or more lines, and click 
  :menuselection:`Edit->Source->Line Comment`,
  all of the lines selected are commented out with ``//``.
- If you start typing a keyword or a previously defined variable and click 
  :menuselection:`Edit->Complete Word`, (or more likely its keyboard shortcut),
  the word is automatically completed, if possible, or else you get options shown.

The complete word feature encourages meaningful (and maybe long) identifiers,
since you never need to enter a whole long identifier more than once!

Try these things out!

.. warning::
   If you use a different editor or fail to set the soft tabs in jEdit, you can
   get into trouble if your files get opened in a different environment.
   (For instance your grader may be in a different environment.)  If you allow
   real tab characters in your file, a different display program may interpret
   the number of spaces per tab differently, and the indentation may make no sense,
   and your program may be hard to read (**and lose points**). 
   The soft tabs mean that jEdit always
   inserts the **proper** number of real spaces when you tab or indent.  This is never
   ambiguous.  
   
Other program editors also have options to use spaces instead of 
real tabs.  Also you can convert a file in jEdit, removing the tabs, 
by selecting the whole program and using
:menuselection:`Edit->Indent->Tabs to Spaces`.


Other Useful Free Text Editors
------------------------------

#. Emacs is available in the Loyola labs.  It is an extremely popular
   among software professionals, with earlier versions that goes back a number of
   decades.  It can be used
   as an all-in-one environment
   with many powerful tools, but it has *quite* a leaning curve.

   - Emacs `Windows download <http://ftp.gnu.org/gnu/emacs/windows/emacs-24.1-bin-i386.zip>`_
   - `Mac variation Aquamacs <http://aquamacs.org/download-release.shtml>`_
   - The GNU Emacs Tutorial is http://www.gnu.org/software/emacs/tour/
   - University of Chicago Libraries Emacs Tutorial,
     http://www2.lib.uchicago.edu/keith/tcl-course/emacs-tutorial.html

#. Vim,  http://www.vim.org/docs.php, is another popular editor 
   with a long history.
   There are graphical versions for Linux, Mac, and Windows.

#. Gedit, http://gedit.org, is a very nice editor that comes with most
   Linux/Gnome distributions. Although it allegedly runs on Windows and OS X, we
   have not had a chance to test it and cannot recommend it at this time.
