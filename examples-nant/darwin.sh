#
# This is NOT a standalone script. It is a script that is read in by the
# other scripts to fix a problem with the NAnt installation on OS X
#
# Mac users who want to run NAnt without using our convenience scripts 
# (build.sh, run.sh, unittest.sh, etc.) can source this file in their 
# initialization file (.bash_profile) or current shell as follows:
#
# . darwin.sh
#

OS=$(uname -s)

if [ "$OS" == "Darwin" ]; then
   PKG_CONFIG_PATH=/Library/Frameworks/Mono.framework/Versions/Current/lib/pkgconfig
   export PKG_CONFIG_PATH
fi

