#! /bin/bash

# No error checking. This must be set to "default" or "bootstrap" (the only
# two themes I set up in rst (e.g. rst/default and rst/bootstrap).

export CONFIG=$1
export FORCRON=-N
if [ $2 == "nocron" ]; then
    export FORCRON=
fi

# Adding a second parameter "nocron" lets sphinx-build use curses.

if [ $2 != "nocron" ]; then
    export FORCRON=-N
fi

mkdir ../all
mkdir ../all/html

HTML=../all/html/$CONFIG
DOWNLOAD=../all/download/
mkdir -p $DOWNLOAD
rm -R $HTML

# assume start in devel dir or rst
cd ../rst
make clean
make html

cd ../build

tar czf $DOWNLOAD/comp170$CONFIG$html.tar.gz html
rm $DOWNLOAD/comp170$CONFIG$html.zip
zip -r -q $DOWNLOAD/comp170$CONFIG$html.zip html
echo created $DOWNLOAD/comp170$CONFIG$html.zip
mv html $HTML 
