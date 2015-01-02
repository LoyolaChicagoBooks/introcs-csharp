#!/bin/bash

num_changes=0
total_checked=0
for dir in . source/*/
do
        ./git-pull-status.sh $dir
	this_changed=$?
	num_changes=$((num_changes + this_changed))
	total_checked=$((total_checked + 1))
        echo "Checked $dir changes=$num_changes"
done

[ $num_changes -gt 0 ] \
	&& echo "$num_changes of $total_checked IntroCS repositories changed" \
	&& echo "git log for $(date)" \
	&& git --no-pager log -5 --pretty=oneline \
	&& ./deploy-introcs.sh
