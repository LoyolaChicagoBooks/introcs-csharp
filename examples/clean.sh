ARGS=$#
echo $ARGS

if [ $ARGS -lt 1 ]; then
   echo "usage: build EXAMPLE (without .cs)"
   exit 1
fi

PROGRAM=$1
nant -buildfile:Generic.build -D:program=$PROGRAM clean
