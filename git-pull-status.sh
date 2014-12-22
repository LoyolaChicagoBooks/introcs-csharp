#!/bin/bash

repo_dir=$1
cd $repo_dir
TMPFILE=/tmp/git-pull-$$.out
git pull > $TMPFILE
repo_changed=$(head -1 $TMPFILE | grep -v ^Already | wc -l)
exit $repo_changed
