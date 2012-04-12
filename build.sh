#! /bin/bash
cd rst
make SPHINXBUILD="sphinx-build" SPHINXOPTS="-D html_theme=bootstrap -a" html
