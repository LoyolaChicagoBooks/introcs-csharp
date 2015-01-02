#!/bin/bash

for script in sites-enabled/*
do
   echo "rsync-ing using $script"
   sh $script
done
