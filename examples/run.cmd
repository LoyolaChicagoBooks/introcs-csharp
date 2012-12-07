@echo off
if %1z == z goto usage
call nant -buildfile:Generic.build -D:program=%1 -q -nologo
@if errorlevel 1 goto end

mono --debug %1.exe %2 %3 %4 %5 %6 %7 %8 %9
goto end

:usage
echo usage:    run programBaseName param1 param2 ...  
echo    where programBaseName is the single source file name OMITTING .cs
echo    param1 param2 ... are OPTIONAL command line parameters 
echo       that become the args array parameter in Main.

:end