NAnt 
====

This will eventually become a page about NAnt. It is not linked to the
table of contents and hasn't even been started. 

These are some notes from the original README.nant file.

How to build examples manually.

nant -D:program=birthday1

To clean any example you no longer want, do this:

nant -D:program=birthday1 clean

The resulting executable/debug data goes to the "bin" subdirectory

If on Linux/OS X, I have two convenience scripts. Someone can feel free to
create a .bat version for Windows.

sh build.sh birthday1
sh clean.sh birthday1


