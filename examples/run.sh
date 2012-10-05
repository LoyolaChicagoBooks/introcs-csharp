#!/bin/bash

ARGS=$#

OS=$(uname -s)

if [ "$OS" == "Darwin" ]; then
   PKG_CONFIG_PATH=/Library/Frameworks/Mono.framework/Versions/Current/lib/pkgconfig
   export PKG_CONFIG_PATH
fi

if [ $ARGS -lt 1 ]; then
  echo usage:    run programBaseName param1 param2 ...  
  echo    where programBaseName is the single source file name OMITTING .cs
  echo    param1 param2 ... are OPTIONAL command line parameters 
  echo       that become the args array parameter in Main.
  exit 1
fi

nant -buildfile:Generic.build -D:program=$1 -q -nologo && mono --debug $1.exe $2 $3 $4 $5 $6 $7 $8 $9
