#! /bin/bash



# No error checking. This must be set to "default" or "bootstrap" (the only
# two themes I set up in rst (e.g. rst/default and rst/bootstrap).

sh ./makehtml.sh default
sh ./makehtml.sh bootstrap

DOWNLOAD=../all/download

# assume start in devel dir
cd ../rst
export CONFIG=default
make latexpdf
#make epub

cd ../build

cp latex/*.pdf $DOWNLOAD
cp epub/*.epub $DOWNLOAD
#rsync -av $(pwd)/html/ $HTML

cd ..
tar czf rst/$DOWNLOAD/comp170code.tar.gz examples
rm rst/$DOWNLOAD/comp170code.zip
zip -r rst/$DOWNLOAD/comp170code.zip examples
