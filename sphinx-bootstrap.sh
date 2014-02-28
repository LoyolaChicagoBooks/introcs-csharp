#! /bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

rm -rf build/
pushd rst
make CONFIG=bootstrap html
make CONFIG=bootstrap epub
make CONFIG=bootstrap LATEXOPTS=' -interaction=batchmode ' latexpdf
popd
