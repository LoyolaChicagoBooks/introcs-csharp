@echo off
if %1z == z goto usage
if not %2z == z goto usage
nant -buildfile:Generic.build -D:program=%1
goto end
:usage
echo usage: build EXAMPLE  (omit .cs)
:end
