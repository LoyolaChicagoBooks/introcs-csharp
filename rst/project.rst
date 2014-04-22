.. _group-project:

Group Project
=====================

Objectives
-------------

- Being creative, imagining and describing a program, and working it
  through to completion

- Working in a team:

  -  Communicating to each other
  -  Dividing responsibilities
  -  Helping each other
  -  Finding consensus
  -  Dealing with conflict
  -  Providing process feedback
  -  Integrating parts created by several people

- Developing new classes to fit your needs

- Using the .Net API library

- Designing a program for refinement

- Testing

- Evolving a program

- Creating documentation for user and implementers

- Programming in the large -- not a small predefined problem

- Make something that is fun

See the project :file:`csproject_stub`, already discussed in class.


**What to turn in:** 

- Periodic reports
- intermediate implementation
- a final presentation
- a final implementation
  including user and programmer documentation and process documentation
- individual evaluations

Overview
----------

You will be assigned to groups of 3-4 people to work on a project that
will extend until the end of the semester, with only a little other work
introduced in class, and of course your last exam. This leaves a month
of course time (in a regular semester) 
for the project (classes, labs, dedicated homework time),
ending with presentations in final exam period. Your group will be
designing and implementing a project of your choosing.  You could
choose to make a text based game, starting from our game skeleton or not, 
or something completely different, started from scratch.   
The project should have some clear focus or aim,
For instance a game should be able to be won.

Start by brainstorming and listing ideas -- do not criticize ideas at
this point. That is what is meant by brainstorming - having your internal critic
going inhibits creativity. After you have a large list from
brainstorming, it is time to think more practically and settle on one
basic situation, and think of a considerable list of features you would
like it to have. Order the features, considering importance, apparent ease of
development, and what depends on what else. Get something simple
working, and then add a few features at a time, testing the pieces added
and the whole project so far. Test, debug, and make sure the program
works completely before using your past experience to decide what to add
next. This may different than what you imagined before the work on your
first stage! Like the provided project, early stages do not need
to be full featured, but make sure that you are building up to a version
with an aim, and which includes interesting features. You should
end with a program that has enough instructions provided for the user, so
someone who knows *nothing* of your implementation process or intentions
can use the program successfully. Your implementation should also be
documented, imagining that a new team of programmers is about to take
over after your departure, looking to create yet another version.

Your Team
-------------

Your instructor will tell you about team makeup. 

There are a number of roles
that must be filled by team members. Some will be shared between all
members, like coder, but for each role there should be a lead person who
makes sure all the contributions come together. Each person will have
more than one role. All members are expected to pull their own weight,
though not all in exactly the same roles. Everyone should make sustained
contributions, every week, documented in the weekly reports. Understand
that this project will be the major course commitment for the rest of
the semester.  These roles vary from rather small to central.  
Not all are important immediately.

Roles
-------

#. Leader: Makes sure the team is coordinated, encourage consensus on
   the overall plan, oversee that the agreements are carried through, be
   available as contact person for the team and the TA and your instructor.
#. Lead programmer: Keep track of different people's parts to make sure
   they fit together.
#. Coder/unit tester: *Everyone* must have a significant but not
   necessarily equal part in this job. Each person should have primary
   responsibility for one or more cohesive substantive units, and code
   and test and be particularly familiar with those parts. Do your best
   to make individual parts be cohesive and loosely coupled with other
   people's work, to save a lot of pain in the testing and debugging
   phase. When coding you are still encouraged to do pair programming,
   though what pair from the team is working together at different times
   may be fluid. The lead programmer might be involved in pairs more
   often than others, but be sure the other coders get to drive often.
#. Librarian/version coordinator: The default should be for you to have a
   box.com folder shared with your whole team and me and your TA, with all
   as editors.  Your folder should have the name of your team.  
   You should always have a folder that contains the latest working version 
   of the project.  You should also keep old versions, for instance copied into
   numbered version folders.  
   Box does not handle successive versions automatically.  
   You can choose
   to use the more capable professional combination of 
   Bitbucket and :ref:`hg-and-teamwork`.  
   The latter will have a learning curve, and in that case this person 
   should be the best informed on Mercurial, and help
   the other team members.  
#. Report coordinator: Gather the contributions for reports from team
   members and make sure the whole reports get to posted on schedule. 
   Your instructor needs
   a clear idea of the contributions of each member each week. If a team
   member is not clear on this to the report writer, 
   *the report writer needs to be insistent*.
#. Instruction coordinator: Make sure there are clear written documents
   and help within the program for the user, who you assume is not a
   C# programmer and knows nothing about your program at the start.
#. Documentation coordinator: Make sure the documentation
   is clear for method users/consumers. 
   This includes the documentation for programmers
   before the headings of methods and classes.  
   This is for any time someone wants to use (not rewrite) a class or
   method you wrote.  
   Also have implementer documentation, for someone who will
   want to modify or debug your code and needs to understand the
   details of your internal implementations.  The extent of this
   can be greatly minimized by good naming.
#. Quality manager: Take charge of integrated tests of the whole program
   (following coder's unit tests). Make sure deficiencies are addressed.

Conflict resolution: You will certainly have disagreements and possibly
conflicts. Try to resolve them within the team. When that is not
working, anyone can go to the instructor with a problem.  Do not delay
coming to me if things are clearly not working with the team.

The process
------------

Initial:

#. Agree on roles. These roles can change if necessary, but you are
   encouraged to stick with them for simplicity and consistency.
#. Agree on a team name and a short no-space abbreviation if necessary,
   and let me know it.
#. Brainstorm about the project. Distill the ideas into a direction and
   overall goals.

On individual versions (Two formal versions will be required):

#. Break out specific goals for the version. How are you heading for
   your overall goals? Are you biting off a significant and manageable
   amount? You are expected to check in with me on this part and 2 and 3
   before moving very far. This will be new for most of you.
#. Plan and organize the necessary parts and the interfaces between the
   parts.
#. Write the interface documentation for consumers of the code
   for the parts you plan to write.
   Agree on them. You need to do this eventually anyway. Agreement up
   front can save you an enormous amount of time! Do not let the gung-ho
   hackers take off before you agree on documented interfaces.
   We have seen it happen:  If you do not put your foot down,
   you are stuck with a bad plan that will complicate things.  Otherwise lots 
   of code needs to be rethought and rewritten.
#. If more than one person is working on the same class, plan the names,
   meanings, and restrictions on the private instance variables -- all
   coders should be assuming the same things about the instance
   variables! Also agree on documentation for any private helping methods you
   share.
#. Code to match the agreed consumer interface and class implementation
   designs.
#. Check each other's code.
#. Do unit tests on your own work, and fix them and test again...
#. Do overall tests of everything together, and fix and test again...
#. Look back at what you did, how it went, what you could do better, and
   what to change in your process for the next version.

You are strongly encouraged to follow modern programming practice which
involves splitting each of these formal versions into much smaller steps
that can be completed and tested following a similar process. Order
pieces so you only need to code a little bit more before testing and
combining with pieces that already work. This is enormously helpful in
isolating bugs! This is really important. If you thought you spent a
long while fighting bugs in your small homework assignment, that is
nothing compared to the time you can spend with a large project,
particularly if you make a lot of haphazard changes all at once.

Splitting Up The Coding
-----------------------

Make good use of the
separation of public interface and detailed implementation. 
If your project has loosely coupled class, the main part of the
public interface should be limited and easy to comprehend.

Ideally have one individual
(or pair) assigned a whole class. One useful feature for allowing
compiling is to first generate a stub file like we have given you for
homework, that includes the public interface documentation, 
headings, and dummy return values
and compiles but does nothing. 
*Post this under a box folder for the current version number.*
You will then provide your team members
with something that tells them what they can use and allows them to
compile their own part. Then later substitute more functional classes.

Your instructor and you will want to review your code. We do not want to have to
reread almost the same thing over and over: Use the editor copy command
with extreme caution. If you are considering making an exact copy,
clearly use a common method instead. If you copy and then make
substitutions in the same places, you are likely better off
with a method with the common parts and with parameters inserted where there
are differences.  You can make a quick test with a
couple of copied portions, but then 
*convert to using a method with parameters for the substitutions*. 
Besides being a waste of effort to define seven methods each
defining a tool, with just a few strings differing from one method to
the next, we will require you to rewrite it, with one method with
parameters, and just seven different calls to the method with different
parameters. Save yourself trouble and do it that way the first time, or
at least after you code a second method and see how much it is like the
first one you coded....

If you are making many substitutions
of static textual data, put the data into a resource file in a variation
of the Fake Advise Lab. 

You only want to commit working code into the shared current version folder.
Comment out incomplete additions that you want to show to everyone,
or comment out the call to a method that compiles but does not yet 
function logically.  An alternative is to have a separate folder for
in-process code to share for comment, 
so you will not try to compile it with the current working version.
   
Weekly reports 
------------------------------------------------

Reports are due from the report writer each Tuesday.

#. Inside your team's box folder have a subfolder called WeeklyReports.  
   A sample stub form to fill out on the computer is in 
   `Weekly-Report.rtf <http://anh.cs.luc.edu/170/examples/Weekly-Report.rtf>`_.
   Make the name of each weekly 
   report document be the date it was due, like Mar26.rtf.
   It is easy
   to copy the table from this week to last week and edit it to show 
   how much your plans matched reality.
   You should post a version for your team to look at first.  Please distinguish
   drafts from the final version for me to look at.   You might have a separate
   folder Drafts, and move the report into the WeeklyReport folder when 
   it is final. Box easily allows moving files, but not renaming them.
#. Only one report should be generated each week, with the person in the role of
   report writer making sure a complete version is produced and placed in the
   WeeklyReport folder.
#. Under plans for the next week, include concrete tasks planned to be
   completed, and who will do them, with an informative
   explanation.  The content and depth of the person's work should be clear. 
   If you can state that clearly and be brief, great.
   The tasks do not only include coding: they can be any of the
   parts listed above, and for any particular part of the project, where
   that makes sense.  *If individuals cannot state clearly what they are working on,* 
   *then the team leader and lead coder have a significant issue in their leadership*
   *that needs to be addressed.*
#. In the review of the last week (after the first week) include the
   last week's plans and what actually happened, task by task,
   concretely, with enough detail to give an idea on the magnitude
   of the work. This can include the portion completed and/or changes in
   the plans and their reasons. "Still working on X" is not useful: Who
   was doing what? What methods, doing what, were completed? Which are
   in process? Which are being debugged? What part remains to be done,
   and who is it assigned to? The report writer is responsible to get a
   clear statement from each team member.

Intermediate deliverables
-------------------------

These materials should be placed in a subfolder **Intermediate** 
of your team project folder.
See the due date in the schedule.

-  Copy the linked stub of 
   `projectPlans.rtf <http://anh.cs.luc.edu/170/examples/projectPlans.rtf>`_ document.
   Then complete it:

   -  List the project roles again, and who ended up filling them. For
      coding, say who was the person primarily responsible for each
      part.
   -  If you used old classes, like those from the skeleton project or a lab or
      somewhere else, say which ones are included *unchanged* or give a
      summary of changes.
   -  If your documentation of methods is not generally done,
      say what classes got clear documentation (or individual methods if only
      some were done).
   -  Where are you planning to go from here, and who you envision being
      primarily responsible for different parts?

-  Include parts 2-4 listed below under Final Deliverables, but for an
   intermediate version that runs, and does *not* need to have the goal
   working yet. Have documentation of your methods, including summary description
   and description of parameters and return values. 
   If for some reason you do not have all the documentation that you were encouraged
   to write *first*, at least be sure to have and point out significant examples of your
   clear documentation of purpose, parameters, and return values.  
   This allows instructor feedback
   for completing the rest.

-  The idea is to have everyone get an idea of what is expected, so we
   have no misunderstandings about the final version. We will give you
   feedback from this version to incorporate in the final version. We do
   not want to have to say anyone did anything "wrong" on the final
   version. We want to be able to concentrate on your creative
   accomplishments.
-  Look through the list of deliverables again and make sure your collection is complete.

Final Deliverables 
--------------------------------

**Group Submission**:

One submission of the group work is due one hour before the final presentations.

#. All files listed in parts 2-5.
   Also include a zip file, named with your team abbreviation, 
   containing a Windows executable with (a separate copy of) any other 
   image and data files needed.  Test to make sure you can
   unzip and run the executable. 
   The final submissions will be accessible to the whole class
   -- so we can all play them!
#. Source code. You can name the classes appropriately
   for the content of your game. 
#. User instructions. These should be partly built into the program. The
   most extensive documentation may be in a document file separate from
   the program, if you like. (Plain text, MS Word, Rich text (rtf), or
   PDF, please.) The starting message built into the beginning of the
   game should mention the file name of such external documentation, if
   you have it.
#. Programmer documentation. Document the public interface for all
   methods in comments directly before the method heading. 
   Add implementation comments
   embedded in the code where they add clarity (not just verbosity). You
   may have a separate overview document.  Include "Overview" in the 
   file name
#. Overall project and process review in a document named like the linked stub,
   `projectReview.rtf <http://anh.cs.luc.edu/170/examples/projectReview.rtf>`_.
   
   -  The first section should be Changes. So the instructor does not 
      duplicate effort, please give an overview of the changes from the
      intermediate version. What classes are the same? What features
      were added? What classes are new? Which classes or methods were
      given major rewrites? What classes had only a few changes? (In
      this case try to list what to look for.)
   -  List again the roles, and who filled them. For coding, say who was
      the person primarily responsible for each part.
   -  What did you learn? What were the biggest challenges? What would
      you do differently the next time? What are you most proud of?
   -  How could we administer this project better? What particularly
      worked about the structure we set up?

#. A 10-15 minute presentation of your work to the class in final exam
   period. What would you want to hear about other projects? (Say it
   about yours.) What was the overall idea? What was the overall
   organization? What did you learn that was beyond the regular class
   topics that others might find useful to know? What were your biggest
   challenges? Do not show off all your code just because it is there.
   Show specific bits that gave you trouble or otherwise are
   instructive, if you like.
   
Look through the list of deliverables again, before sending files,
and check with the whole team to make sure your collection is complete.
   
**Your Assessment of Individuals in the Group**:

This is due electronically 10 minutes after the final class presentation period,
from each team member, *independently*, turned in a manner specified by your 
instructor, like other homework assignments.  

Change the name of the linked stub file
`Indiv-Mem-Assessment.rtf <http://anh.cs.luc.edu/170/examples/Indiv-Mem-Assessment.rtf>`_
to your
teamAbbreviation-yourName.rtf. 
You may want to tweak it after the
group presentation, but have it essentially done beforehand. 

Writing this is NOT a part of your
collective group deliberations. It is individual in two senses: both
in being about individual team members and in being the view of *one*
individual, you. For this document only, everyone should be writing
separately, privately, and independently from individual experience.  
If you lack data on some point, say so, rather than using what others are saying.
