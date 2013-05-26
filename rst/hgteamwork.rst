.. index:: Mercurial
   version control

.. _hg-and-teamwork:

Mercurial and Teamwork
=========================

As this course has a team project, this lecture is about how to work as
a team and make effective use of the version control system, Mercurial,
that we have been using throughout the semester. While the focus is on
the use of Mercurial, the principles we are introducing here can be
adapted to other situations (and alternate version control systems).


Planning and Communication
-----------------------------

Two of the most important aspects when it comes to teamwork are planning
and communication. In the real world, planning is often referred to as
*project management*. And communication often takes the form of regular
team *meetings*. 

In later courses (e.g. software engineering) there is greater emphasis
placed on thinking more broadly about software process. We're not going
to cover SE in depth here but want you to be aware that software process
is an important topic. Planning and communication are always supporting
ingredients of a *good* software process.

At the level of actual programming, when two folks are working on the
same project, it is important to think about how you can organize your
work so each person on the team can get something done. As we've been
learning throughout the semester, the C# language gives us a way to
organize our code using projects (with Xamarin Studio). Within a project
we can organize it as a collection of files, each of which maintains
part of the solution to a problem.  These parts are typically organized
using classes within a namespace and methods.

So the key to working together--and apart--is to spend some time, initially,
planning out the essential organization of a project and the files within
it. Much like writing a term paper, you can create classes and methods 
that are needed--without writing the actual *body* of the methods--and then
commit your code to the repository. Then each member of the team can work
on parts of the code and test them independently. Then you can sit together
again as a pair to integrate the work you've done independently.

It's easier said than done, but this is intended as a suggestion for 
how to collaborate.

In any event, the above suggests that you actually need to
*communicate* if you want to get anything done. You should start by
discussing what needs to be done and work in *real time* to do what
has been described above.  Then you start coding. As you are coding,
you are going to realize that as well as you planned the work to be
done, you "forgot" or "misunderstood" some aspect. When this happens,
you and your partner(s) need to communicate.

In the modern era of software development, we are richly blessed with
synchronous communication methods such as instant messaging, texting,
group chat, and other forms of synchronous collaboration. When you and
your partner(s) are working on the project, we highly encourage you to
keep a chat window open (Google Talk, AIM, Yahoo, IRC, whatever) and
use it to communicate any issues as they arise.


Typical Scenario
------------------

In general, when working with Mercurial, you will find yourself using the
following commands in roughly this order:

- ``hg incoming``: look for incoming changes that were either made by
  yourself or your partner(s). We say "by yourself" because it is clearly
  possible that you are working on another computer somewhere else (laptop,
  home computer) and pushed some changes. So it is a good habit to see
  whether "anything has changed" since the last time you looked, even if
  you looked recently.

- ``hg pull``: If there are incoming changes showing up as incoming, then
  you should in fact pull them in. This will stage the changes locally 
  but they will not be incorporated until you type ``hg update``.

- ``hg update``: Absorbs all changes that were pulled from your remote
  repository. This operation has the potential to *overwrite* changes you
  are currently making, so you should make sure that the incoming changes
  that you observed above are sensible. For example, if you are editing
  a file named ``examples/MyProject/my_project.cs`` and the incoming log 
  suggests that the same file has been modified, you're likely to end up
  with a conflict when performing the update. (We'll cover conflict 
  resolution shortly.)

- ``hg add``: Whenever you add files to your folder, if you want them to
  be in the repository, you always need to *add* them. It is very easy to
  forget to do so. The ``hg status`` command can be used to figure out
  files that *might* need to be added.

- ``hg status``: This command will become one of your best friends. You 
  This typically tells you what has happened since you started your work
  in this directory (and since the last commit/push cycle). You especially 
  want to keep on the lookout for the following:

  - ``?``: This means that a file is *untracked* in the repository. If you
    see a file with the ``?`` status that is important, you'll want
    to add it using ``hg add`` as explained above.

  - ``M``: This means that a file has been *modified*.

  - ``A``: This means that a file has been *added*.

- ``hg commit``: In general, you should commit all changes to your 
  repository, especially before you leave the lab for the day. It is important
  to note that committing is a *local* operation and does not affect the
  remote repository (at bitbucket.org) until a corresponding push has
  been done.

- ``hg push``: Almost immediately after a commit, it makes sense to do a 
  push, especially if you are in the lab and will be continuing your work
  on other computers. In addition, as you've observed with previous homework,
  it is the only way to ensure that you can view the code on BitBucket (our
  hosting site for Mercurial projects).


Conflict Avoidance
----------------------

Inevitably, when you are working on project, you are likely to end up
in a situation where you and your partner(s) make changes that
conflict with one another. In many cases, the version control software
can automatically merge the changes. Here are just a few examples of
where it is possible to do so:

- You make changes to different files.

- You make additions to the repository.

- You make changes to a common file that do not overlap. An example of
  this might be where you have two functions in your program and both
  you and your partner are careful not to modify them.

In general, we encourage you to coordinate your efforts, especially
when you are doing something like the third situation.

Where you get into trouble is when there are changes to a common file
that conflict with one another. When this happens, you have two
choices in practice:

- use ``hg merge`` and ``hg resolve`` to merge your changes.

- make a copy of the conflicting files (e.g. Copy ``hello.cs`` to
  ``hello.cs-backup`` and use ``hg update --clean`` (changing your
  copy to match the current version in the remote repository) to just
  accept the latest versions of all files from the repository.

In our experience, the first option is tricky. You are given the
option to perform the merge anyway or use a merge tool to select the
changes of interest (and decide between them).

The second option basically results in two copies of the file. You can
open up your editor to compare the files side-by-side or use a tool
like ``diff`` on Unix or a Mac, which gives a side-by-side comparison::

   diff -y hello.cs my_hello.cs

(You will need to expand the width of your console window to see clearly!)

This tool is not built into Windows.  In the Windows lab, you can use the
much less visually helpful  ::

   fc hello.cs my_hello.cs

to show differing segments from each file.
You can also download difference display tools for Windows that are more 
visually helpful.  One of many choices is at http://winmerge.org.

E-mail Notifications
----------------------

One of the best ways to avoid conflicts when working on a team is to
enable e-mail notification on your repository. 

Bitbucket, the hosting service we are using and recommending for our
students, provides full support for e-mail notification. Whenever you
or your partner(s) push changes to the hosted repository, an e-mail
will be generated.

These are the steps to set it up. (Owing to the changing nature of web
interfaces, we are providing generic instructions that should be
adaptable if the Bitbucket service decides to change its web user interface.)

#. Make sure your repository is selected. This is always the
   especially when you visit your repository by URL.

#. Select the administrative (Admin) tab.

#. Select Services (left-hand-side navigation).

#. Add the Email or Email Diff service. These services are basically
   equivalent, but one will generate links so you can view the
   differences that were just pushed. We recommend Email Diff.
  
#. Add the email notification address. You can only have one address.
   A good way to overcome this limitation is to set up a group service,
   say, at Google Groups.

Communication is Key to Success
-------------------------------------

At the risk of repeating ourselves, we close by reminding you of the
central importance of good communication. The authors of this book
communicate when it comes to their changes--even before we make
them. Yet we occasionally trip over each other, and there is usually a
fair amount of manual reconciliation required to deal with conflicts
when we end up touching the same file by mistake. 

When you absolutely and positively need to change a common file, it is
important to ask yourself the important question: Shouldn't we be
sitting together to make these changes? It's a rhetorical question,
but working closely together, either in the same room or through a
chat session/phone call, can result in significantly fewer headaches,
especially during the early stages of a project.

So please take this time to stop what you are doing and
communicate. You'll know your communication is good if you never need
to do anything that has been described on this page. Then again, we're
human. So you it is likely to happen at least once. (We know from
experience but are doing everything possible to avoid conflicts in our
work!)
