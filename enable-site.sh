#!/bin/bash

SITE=$1
pushd sites-enabled
ln -sf ../sites-available/$SITE .
popd
