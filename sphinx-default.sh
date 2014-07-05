#! /bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

rm -rf build/
pushd rst
make CONFIG=default html
make CONFIG=default epub
make CONFIG=default LATEXOPTS=' -interaction=batchmode ' latexpdf
popd
