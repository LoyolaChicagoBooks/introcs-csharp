#! /bin/bash

# assumes "bootstrap" 

export CONFIG=$1

# assume start in devel dir or rst
cd ../rst
make clean
make html
