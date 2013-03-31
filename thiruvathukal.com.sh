#! /bin/bash
#
[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate
rm -rf build/
pushd rst
make CONFIG=default html
make CONFIG=default epub
make CONFIG=default latexpdf
popd
rsync -avz $(pwd)/build/ thiruvathukal.com:/home/gkt/sites/introcs/

