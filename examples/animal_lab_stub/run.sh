#!/bin/bash

ARGS=$#

OS=$(uname -s)

if [ "$OS" == "Darwin" ]; then
   PKG_CONFIG_PATH=/Library/Frameworks/Mono.framework/Versions/Current/lib/pkgconfig
   export PKG_CONFIG_PATH
fi

if [ $ARGS -lt 1 ]; then
  echo    where programBaseName is the name OMITTING .cs
  echo       of the file containing Main
  echo    param1 param2 ... are OPTIONAL command line parameters 
  echo       that become the args array parameter in Main.
  exit 1
fi

nant -q -nologo && mono --debug $1.exe $2 $3 $4 $5 $6 $7 $8 $9
