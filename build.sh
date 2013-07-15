#! /bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

python get-examples.py

rm -rf build/
pushd rst
make CONFIG=default html
make CONFIG=default epub
make CONFIG=default latexpdf
popd

pushd build
mkdir -p dist
zip -r dist/html.zip html/
popd
