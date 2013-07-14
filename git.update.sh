#!/bin/bash

SHORT_NAME=$1
REPO_URI=$2
EXAMPLE_DIR=source
THIS_EXAMPLE_DIR=$EXAMPLE_DIR/$SHORT_NAME

mkdir -p $EXAMPLE_DIR
if [ -e "$THIS_EXAMPLE_DIR" ]; then
   cd $THIS_EXAMPLE_DIR
   git pull
else
   rm -rf $THIS_EXAMPLE_DIR
   git clone $REPO_URI $THIS_EXAMPLE_DIR
fi
