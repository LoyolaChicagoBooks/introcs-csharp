ARGS=$#
echo $ARGS

if [ $ARGS -lt 1 ]; then
   echo "usage: tests EXAMPLE (without .cs)"
   exit 1
fi

PROGRAM=$1

if [ -f unittests/$PROGRAM.cs ]; then
   nant -buildfile:Tests.build -D:program=$PROGRAM clean
   nant -buildfile:Tests.build -D:program=$PROGRAM build
   nant -buildfile:Tests.build -D:program=$PROGRAM test
else
   echo "This program does not have a unittest in tests/$PROGRAM.cs"
fi
