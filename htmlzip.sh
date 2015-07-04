#!/bin/bash

pushd build
mkdir -p dist
zip -qr dist/html.zip html/
popd
