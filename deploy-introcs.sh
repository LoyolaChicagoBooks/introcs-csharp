#! /bin/bash

./pull-examples.sh
./sphinx-bootstrap.sh && ./htmlzip.sh && ./rsync-introcs.sh
