rsync -avz --delete --exclude .htaccess -e "ssh -oPort=22222" $(pwd)/build/ gkt@introcs.cs.luc.edu:/var/www/
