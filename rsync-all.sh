#!/bin/bash

echo "Pushing to introcs.cs.luc.edu"
./rsync-introcs.sh
echo
echo "Pushing to introcs.cs.courseclouds.com"
./rsync-courseclouds.sh
echo
