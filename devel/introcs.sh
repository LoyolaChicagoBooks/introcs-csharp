#!/bin/bash

whoami
echo $PATH
date

cd /home/gkt/introcs-csharp/devel

# added so no build if no changes:
hg incoming | tail -n 1  | diff - nochange.txt  && echo no change, done  && exit 0

echo "Building default/bootstrap themes"
hg pull
hg update --clean
./makeall.introcs default
./makeall.introcs bootstrap

