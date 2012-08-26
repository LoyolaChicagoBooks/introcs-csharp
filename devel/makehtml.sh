#! /bin/bash



# No error checking. This must be set to "default" or "bootstrap" (the only
# two themes I set up in rst (e.g. rst/default and rst/bootstrap).

export CONFIG=$1

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
zip -r $DOWNLOAD/comp170$CONFIG$html.zip html

mv html $HTML
