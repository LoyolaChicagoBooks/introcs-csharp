#!/bin/bash

num_changes=0
total_checked=0
for dir in . source/*/
do
	pushd $dir > /dev/null
	TMPFILE=/tmp/git-pull-$$.out
	git pull > $TMPFILE
	this_changed=$(head -1 $TMPFILE | grep -v ^Already | wc -l)
	rm -f $TMPFILE
	num_changes=$((num_changes + this_changed))
	total_checked=$((total_checked + 1))
	popd > /dev/null
done


[ $num_changes -gt 0 ] \
	&& echo "$num_changes of $total_checked IntroCS repositories changed" \
	&& echo "git log for $(date)" \
	&& git --no-pager log -5 --pretty=oneline \
	&& sh ./deploy-introcs.sh
