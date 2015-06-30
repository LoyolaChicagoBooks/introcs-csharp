#! /bin/bash

export CONFIG=spellcheck

# assume start in devel dir or rst
cd ../rst
make spelling
