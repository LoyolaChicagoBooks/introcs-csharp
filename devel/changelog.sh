CHANGELOG=rst/changelog.rst
echo "Change Log" > $CHANGELOG
echo "==========" >> $CHANGELOG
echo >> $CHANGELOG
git log --format=format:"#. %s%n    - %h%n    - %an%n    - %ar%n" >> $CHANGELOG
