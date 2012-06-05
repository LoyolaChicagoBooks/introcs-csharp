@nant -buildfile:Generic.build -D:program=%1
@if errorlevel 1 goto end
mono --debug %1.exe %2 %3 %4 %5 %6 %7 %8 %9
:end