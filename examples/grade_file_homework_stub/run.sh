#!/bin/bash

. ../darwin.sh
nant -q -nologo && mono --debug $1.exe $2 $3 $4 $5 $6 $7 $8 $9
