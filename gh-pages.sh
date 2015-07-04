#!/bin/bash

git config --global user.email "gkt@cs.luc.edu"
git config --global user.name "George K. Thiruvathukal"
git remote add deploy "https://$GH_TOKEN@github.com/$GH_USER/$GH_REPO.git"
git fetch deploy
git reset -q deploy/gh-pages
git checkout master source Makefile build.sh
git reset HEAD
rm -rf build
./build.sh
./htmlzip.sh
mkdir -p download
mv -f build/html/* ./
mv -f build/latex/*.pdf ./download/
mv -f build/epub/*.epub ./download/
mv -f build/dist/*.zip ./download/
touch .nojekyll
git log master -5 > COMMITS.txt
git add -A
git status
git commit -m "Generated gh-pages for `git log master -1 --pretty=short --abbrev-commit`" && git push deploy HEAD:gh-pages

