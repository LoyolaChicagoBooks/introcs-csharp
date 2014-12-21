#!/bin/bash

num_changes=0
total_checked=0
for dir in . source/*/
do
	pushd $dir
	this_changed=$(git pull | head -1 | grep -v ^Already | wc -l)
	num_changes=$((num_changes + this_changed))
	total_checked=$((total_checked + 1))
	popd
done


[ $num_changes -gt 0 ] \
	&& echo "$num_changes of $total_checked IntroCS repositories changed" \
	&& echo "git log for $(date)" \
	&& git --no-pager log -5 --pretty=oneline \
	&& sh ./deploy-introcs.sh
