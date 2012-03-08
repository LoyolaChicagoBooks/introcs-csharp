using System;

namespace Scales
{
   class MainClass
   {
      // chunk-tones-begin
      static string[] tones = { "C", "C#", "D", "D#", "E", "F",
         "F#", "G", "G#", "A", "A#", "B" };
      // chunk-tones-end

      // chunk-compute-begin
      static void ComputeScale(string key, int[] steps, int[] scale) {
         int sum = 0;
         int start;
         for (start=0; start < scale.GetLength(0); start++) {
            if (key == tones[start])
               break;
         }

         if (steps.GetLength(0) != scale.GetLength(0))
            return;

         sum = start;
         for (int i=0; i < steps.GetLength(0); i++) {
            scale[i] = sum % tones.GetLength(0);
            sum += steps[i];
         }
      }
      // chunk-compute-end

      // chunk-write-begin
      static void WriteScale(int[] scale) {
         foreach (int i in scale) {
            Console.Write ("{0} ", tones[i]);
         }
         Console.WriteLine ();
      }
      // chunk-write-end


      // chunk-main-begin
      public static void Main (string[] args)
      {
         int[] scale = new int[8];
         int[] major = { 2, 2, 1, 2, 2, 2, 1, 0 };
         int[] minor = { 2, 1, 2, 2, 1, 2, 2, 0 };

         string name = args[0];
         Console.WriteLine("{0} major scale", name);
         ComputeScale(name, major, scale);
         WriteScale(scale);
         Console.WriteLine("{0} minor scale", name);
         ComputeScale(name, minor, scale);
         WriteScale(scale);
      }
      // chunk-main-end
   }
}
