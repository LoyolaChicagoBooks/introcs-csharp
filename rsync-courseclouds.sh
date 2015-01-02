#!/bin/bash

rsync -avz --exclude .htaccess ./build/ course@courseclouds.com:./sites/introcs.cs.courseclouds.com/
