@echo off
if %1z == z goto usage
if not %2z == z goto usage
nant -buildfile:Generic.build -D:program=%1 clean
goto end
:usage
echo usage: clean EXAMPLE  
echo        to remove all build products for single file program EXAMPLE.cs.
echo        Note that the command line parameter does *not* include .cs.
:end
