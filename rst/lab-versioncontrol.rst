_lab-versioncontrol:

.. index::
   single: labs, hg
   signle: labs, version control

Lab: Version Control
====================

Modern software development requires an early introduction source code
management, also known as version control. While source code management is
frequently touted as being beneficial to a *project team*, it is also of
great value for *individuals* and provides a clear mechanism for tracking,
preserving, and sharing your work.

There are numerous options for version control. In the free/open source
community, a number of solutions have emerged, including some old (CVS,
Subversion) and some new (Mercurial, Git, and Bazaar). We're particularly
fond of the Mercurial system. A key reason for our choice is that there is
an excellent cloud-based solution to host your projects known as Bitbucket
(http://bitbucket.org).

There are other similar solutions to Bitbucket but none at present
provides a completely *free* solution for hosting *private*
repostories, which allow you to keep your work *secret* from others.

Goals
-----

In this lab, we're going to learn:

#. How to create a source code repository.

#. How to add files and folders to a repository and track them.

#. How to make sure certain files and folders are not kept in the repository.

#. How to push your changes to a remote repository (at Bitbucket.org).

#. How to do your work at home and in the lab.

#. How to do your work if you are in another lab on campus (e.g. a 
   Windows or Linux Lab).

#. How to get our notes, examples, and projects (now that that you know how
   to use Mercurial).

Before We Proceed
-----------------

You should know that this lab is designed to be repeated as many times as
needed. You can create as many repositories as you wish, subject to the 
limitations at Bitbucket.org, and may want to create different repositories
for different needs (one for yourself, one for you and your partner in 
pair programming, etc.) This lab assumes you are starting with a repository
for your own work. We'll include a step for how to add a *collaborator*
to the project.

Future labs will talk about additional things you need to know when it comes
to collaboration, so please view this lab as a *beginning* aimed at helping
you to start using version control right away for your own projects.

Steps
=====

Create Bitbucket.org account
----------------------------

We're going to begin by creating a remote repository for our work. The 
advantage of doing so is that we get a *hosted* repository that we can
use to push/pull our work. (Unlike a dangerous stunt, you *want* to be able
to try this at home, too!)

Signing up for a repository at http://bitbucket.org is easy. From the 
landing page, just click on the option for the *Free Plan*. This allows
you to create any number of public/private repositories with support
for up to 5 users. This is all you'll need for your work in this course.

Once you've created your account (and confirmed it, if required) you 
are good to go for the rest of this lab!

Create repository at Bitbucket
------------------------------

Now we'll create a first repository at Bitbucket.org.

Go to ``Repositories -> Create Repository`` (the option is at the bottom
of the list of menu options). You'll see this screen:

   .. image:: images/lab-hg/hgcreaterepository.png
      :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

You'll need to fill in or select the following options:

- Name: A short name for your project. You are encouraged to keep this simple. 
  If you are using this for all of your work in COMP 170 (which is fine) you
  might name the repository after your initials. So if your name is 
  Linus Torvalds, you could give a short name like *LinusTorvaldsCOMP170* or *LTCOMP170*.

- Repository Type: Select Mercurial. Yes, we realize that MonoDevelop supports Git natively,
  but for the reasons mentioned earlier, we have chosen Mercurial. We will allow you to use
  Git on your own if you can figure it out and use it properly. But this lab assumes
  Mercurial.

- Language: You can select anything you like here. We do C# for the most part in this
  class, so we recommend that you select it.

- Description: You can give any description you like. If you are working with a partner
  please list both you and your partner's name in the description.

- Web Site: Optional

- Private checkbox should be checked.

So just go ahead and create your first repository. You can always create more of them later.

Here is an example of a filled out form:

   .. image:: images/lab-hg/hgcreaterepository2.png
      :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

Clone repository from Bitbucket
-------------------------------

If all has gone well, you should now see your new repository on the list of repositories.

For example, the co-author's new repository, ``gkt170``, shows up on the list of repositories 
(the dropdown) as ``gkthiruvathukal/gkt170``.

So you can now go ahead by selecting this newly created repository from the list of repositories.
If all goes well, you should see the following screen:

   .. image:: images/lab-hg/hgrepositoryinfo.png
      :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

Somewhere on this screen, you should see this text::

    Clone this repository (size: 546 bytes): HTTPS / SSH
    hg clone https://yourusername@bitbucket.org/yourusername/yourrepository

Using information we learned earlier in the course, open a terminal (or DOS command shell).
You can do this command (copied and pasted from Bitbucket) in your default home directory::

    hg clone https://yourusername@bitbucket.org/yourusername/yourrepository

This will create a copy of your (currently empty) repository. Once you have this copy, you 
can copy and paste folders and files into your project. You will see some output:: 

    hg clone https://gkthiruvathukal@bitbucket.org/gkthiruvathukal/gkt170
    http authorization required
    realm: Bitbucket.org HTTP
    user: gkthiruvathukal
    password: 
    destination directory: gkt170
    no changes found
    updating to branch default
    0 files updated, 0 files merged, 0 files removed, 0 files unresolved

Again, because the repository at Bitbucket is presently empty, the above output actually
makes sense. There are no files to be updated. We'll learn more about what this output
means later. It is possible to get *unresolved* files when you make changes that introduce
conflicts. We're going to do whatever we can to avoid these for the small projects in 
our course work. However, when working in teams, it will become especially important that
you and your teammate(s) are careful to communicate changes you are making, especially
when changing the same files in a project.

.. warning::
   A version control system doesn't replace the need for human communication and being
   organized. 

Add an .hgignore file to your project
-------------------------------------

The following is an example of a "dot hgignore" file.

.. literalinclude:: ../examples/hgignore.txt


The notion of a "dot" file (filename beginning with a dot) comes from Linux, where


Create an initial structure for your project
--------------------------------------------

We suggest that you follow a scheme similar to what we use when working
with version control. We suggest creating the following folders:

- projects: A folder that will be used to keep your MonoDevelop projects.

- examples: A folder that will be used to keep examples that you are working
  on in class but are not necessarily big enough to be full projects. A good
  example might be something you copied and pasted from the notes.

- labs: A folder that will be used to keep your labs. You could even create
  some folder structure within this folder (e.g. hello, division, strings, 
  etc.)

So let's do it:

#. Change to the checkout directory::

       cd gkt170

   
#. Create directories::

       mkdir projects
       mkdir labs
       mkdir examples

   We will be creating items in each one of these folders during the lab. Until
   we create some actual *files* in these folders, we will not be putting anything
   under version control just yet.


#. Create or copy the *Hello, World* C# program into the labs folder. You already
   know how to do this. If it is in another folder on your computer, you can either
   drag and drop it using your operating systems's file manager or the OS copy 
   command (Linux or OS X ``cp`` or Windows ``copy``).



#. Now let's do a status check::

       $ hg status
       ? labs/hello.cs
       ? labs/hello.exe

#. As you can see, my labs folder contains the code for ``hello.cs`` and the 
   compiled code, ``hello.exe``. In the next section, we'll learn how to "ignore"
   compiled code, which really doesn't belong in the repository, because it is something
   we can *regenerate* from ``hello.cs``, simply by using the C# compiler, ``gmcs``.

#. So let's add ``hello.cs`` to our *copy of* the repository. It is important to note
   at this point that we are working only with a copy of our repository on Bitbucket. 
   This allows us to make any desired changes without being connected to the internet,
   after which we can **push** the changes back to Bitbucket. (More on that later.)

   
Make sure your files are actually in the folders
------------------------------------------------

Let's start by keeping the simplest project, *Hello, World*, in version
control.
