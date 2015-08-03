#!/bin/bash
#
# Note: This script is NOT intended to be run in your checkout directory. It is only run on the Travis CI
# system (ephemeral instances) to push to the gh-pages branch. Use build.sh instead.

git config --global user.email "gkt@cs.luc.edu"
git config --global user.name "George K. Thiruvathukal"
git remote add deploy "https://$GH_TOKEN@github.com/$GH_USER/$GH_REPO.git"
git fetch deploy
git reset -q deploy/gh-pages
git checkout master rst build.sh
git reset -q HEAD
rm -rf build
./build.sh -a
rm -rf source/*
mkdir -p download
mv -f build/html/* ./
mv -f build/letterpdf/*.pdf ./download/
mv -f build/bookpdf/*.pdf ./download/comp170book.pdf
mv -f build/epub/*.epub ./download/
mv -f build/dist/*.zip ./download/
touch .nojekyll
git log master -5 > COMMITS.txt
git add -A >& /dev/null
git commit -m "Generated gh-pages for `git log master -1 --pretty=short --abbrev-commit`" && git push deploy HEAD:gh-pages

