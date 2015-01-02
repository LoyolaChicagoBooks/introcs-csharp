rsync -avz --exclude .htaccess ./build/ gkt@thiruvathukal.com:./sites/introcs.courses.thiruvathukal.com/
