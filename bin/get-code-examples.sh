#! /bin/bash

EXAMPLES=examples
mkdir -p $EXAMPLES
rm -rf $EXAMPLES/*

git clone https://github.com/LoyolaChicagoBooks/introcs-csharp-examples.git $EXAMPLES/introcs
git clone https://bitbucket.org/josullivan1/comp170-xcode-xamarin-ios.git $EXAMPLES/ios
