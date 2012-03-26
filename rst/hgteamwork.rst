.. todo::
   Not quite ready yet but getting there...

Mercurial and Teamwork
=========================

As this course has a team project, this lecture is about how to work as
a team and make effective use of the version control system, Mercurial,
that we have been using throughout the semester. While the focus is on
the use of Mercurial, the principles we are introducing here can be
adapted to other situations.


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
organize our code using projects (with MonoDevelop). Within a project
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

In any event, the above suggests that you actually need to *communicate*
if you want to get anything done. You should start by discussing what needs
to be done and work in *real time* to do what has been described above. 
Then you start coding. As you are coding, you are going to realize that 
as well as you planned the work to be done, you "forgot" or "misunderstood"
some aspect. When this happens, you and your partner(s) need to communicate.
In the modern era of software development, we are richly blessed with
text messaging, chat, and other forms of synchronous collaboration. When you
and your partner(s) are working on the project, we highly encourage you
to keep a chat window open (Google Talk, AIM, Yahoo, IRC, whatever) and 
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
  a file named ``projects/MyProject/MyProject.cs`` and the incoming log 
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
    to add it usin ``hg add`` as explained above.

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

We'll cover how to avoid conflicting changes.

If you absolutely must have conflicts, you'll need to master 
``hg merge`` and ``hg resolve``.


E-mail Notifications
----------------------

The Bitbucket service has a way of pushing out e-mail whenever a commit
operation takes place.

Steps

#. Make sure your repository is selected.

#. Admin tab

#. Services (left navigation)

#. Add the Email or Email Diff service

#. Add the email notification address. You can only have one address.
   A good way to overcome this limitation is to set up a group service,
   say, at Google Groups.


