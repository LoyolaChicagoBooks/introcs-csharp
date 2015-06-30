#!/bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

./sphinx-default.sh
