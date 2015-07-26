#!/bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

function git_clone {
   rm -rf source/*
   git clone https://github.com/LoyolaChicagoBooks/introcs-csharp-examples.git \
      source/examples
   git clone https://bitbucket.org/josullivan1/comp170-xcode-xamarin-ios.git \
      source/ios
}

function clean {
   rm -rf build/*
}

function bootstrap_html {
   pushd rst
   make CONFIG=bootstrap html
   popd
}

function bootstrap_epub {
   pushd rst
   make CONFIG=bootstrap epub
   popd

}

function bootstrap_pdf {
   pushd rst
   make CONFIG=bootstrap LATEXOPTS=' -interaction=batchmode ' latexpdf
   popd
   mv -f build/latex build/letterpdf
}

function createspace_pdf {
   pushd rst
   make CONFIG=createspace LATEXOPTS=' -interaction=batchmode ' latexpdf
   popd
   mv -f build/latex build/bookpdf
}

function show_help {
   echo 'build.sh [-h] [-?] [-w] [-p] [-e] [-b] [-g]'
   echo '  -h or -?: help'
   echo '  -g: pull examples from introcs-csharp-examples, etc.'
   echo '  -w: build HTML (bootstrap config)'
   echo '  -e: build EPUB (bootstrap config)'
   echo '  -p: build PDF (bootstrap config)'
   echo '  -b: build book PDF (createspace config)'
   echo '  -a: all of -g, -w, -e, -p, -b'
}

function htmlzip {
   pushd build
   mkdir -p dist
   zip -qr dist/html.zip html/
   popd
}

# A POSIX variable

OPTIND=1         # Reset in case getopts has been used previously in the shell.

HTML=0
EPUB=0
PDF=0
PULL=0
BOOK=0
HTMLZIP=0

while getopts "zwepgabh?" opt; do
    case "$opt" in
    a)  HTML=1; EPUB=1; PDF=1; BOOK=1; PULL=1; HTMLZIP=1
        ;;
    w)  HTML=1
        ;;
    e)  EPUB=1
        ;;
    p)  PDF=1
        ;;
    b)  BOOK=1
        ;;
    g)  PULL=1
        ;;
    z)  HTML=1; HTMLZIP=1
        ;;
    h|\?)
        show_help
        exit 0
        ;;
     
    esac
done

#shift $((OPTIND-1))

clean
[ $PULL -ne 0 ] && git_clone
[ $HTML -ne 0 ] && bootstrap_html
[ $EPUB -ne 0 ] && bootstrap_epub
[ $PDF -ne 0 ] && bootstrap_pdf
[ $BOOK -ne 0 ] && createspace_pdf
[ $HTMLZIP -ne 0 ] && htmlzip
