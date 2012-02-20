
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
(http://bitbucket.org). There are other similar solutions to Bitbucket but
none at present provides a completely *free* solution for hosting *private*
repostories, which allow you to keep your work *secret* from others.

Goals
-----

In this lab, we're going to learn:

#. How to create a source code repository.

#. How to add files and folders to a repository and track them.

#. How to make sure certain files and folders are not kept in the repository.
   Typically, we do not want any files in the repository that can be 
   created from a source file. For example, if you have a file Hello.cs,
   it can be used to create Hello.exe, so there is no need to put the 
   file Hello.exe in the repository.

#. How to push your changes to a remote repository (at Bitbucket.org)

#. How to do your work at home and in the lab.

#. How to do your work if you are in another lab on campus (e.g. a 
   Windows or Linux Lab).

#. (For the WTC section students) How to access your code remotely 
   via SSH.


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
We're going to begin by creating a repository based on some previous work
you have done. Because this is our first effort, you are encouraged to 
work with a copy of your previous work.


Create repository at Bitbucket
------------------------------

Clone repository from Bitbucket
-------------------------------

Add an .hgignore file to your project
-------------------------------------

.. literalinclude:: ../examples/hgignore.txt

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


Make sure your files are actually in the folders
------------------------------------------------

Let's start by keeping the simplest project, *Hello, World*, in version
control.
