#!/bin/bash

BUILDDIR=$1

if [ -d "$BUILDDIR" ]; then
   find $BUILDDIR -name bootstrap.min.css -exec ./cssFix.py {} \; 
fi
