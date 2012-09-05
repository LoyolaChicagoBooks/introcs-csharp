
#!/bin/bash

whoami
echo $PATH
date

cd /home/gkt/introcs-csharp/devel

# added so no build if no changes:
hg incoming | tail -n 1  | diff - nochange.txt  && echo no change, done  && exit 0

# I don't like the current code:  for a full minute you get no version.
# Instead I suggest:  
# no need to rm single file entities (downloads) at all: just overwrite
# Bigger deal for html: create html in temp dir, 
# Then in an instant mv out old html dir, mv in new dir, and only then remove old
# I suggest this all be done in makeall.introcs so the next two rm -r  lines 
# are no longer here.
# Not implemented yet.


echo "Removing generated directories at introcs"
rm -r /var/www/book/html/*/
rm -r /var/www/book/download/*/

echo "Building default/bootstrap themes"
hg pull
hg update --clean
./makeall.introcs default
./makeall.introcs bootstrap

