#!/bin/bash

git config --global user.email "gkt@cs.luc.edu"
git config --global user.name "George K. Thiruvathukal"
git remote add deploy "https://$GH_TOKEN@github.com/$GH_USER/$GH_REPO.git"
git fetch deploy
git reset deploy/gh-pages
git checkout master source Makefile build.sh
git reset HEAD
rm -rf build
./build.sh
./htmlzip.sh
mkdir -p download
mv -vf build/html/* ./
mv -vf build/latex/*.pdf ./download/
mv -vf build/epub/*.epub ./download/
mv -vf build/dist/*.zip ./download/
touch .nojekyll
git log -5 > COMMITS.txt
git add -A
git status
git commit -m "Generated gh-pages for `git log master -1 --pretty=short --abbrev-commit`" && git push deploy HEAD:gh-pages

