
for example_cs in *.cs
do
   example_name=$(basename $example_cs .cs)
   ./build.sh $example_name
done
