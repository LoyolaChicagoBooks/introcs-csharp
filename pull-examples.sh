#!/bin/bash

rm -rf source/*
git clone https://github.com/LoyolaChicagoBooks/introcs-csharp-examples.git \
	source/examples

git clone https://bitbucket.org/josullivan1/comp170-xcode-xamarin-ios.git \
	source/ios
