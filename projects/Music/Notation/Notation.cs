using System;
using System.Collections.Generic;

namespace Music
{
   public struct Note {

      private int tone;
      private int octave;
      private Rational duration;

      public Rational GetDuration() {
         return duration;
      }

      public Note(int tone, int octave, Rational duration) {
         this.tone = tone;
         this.octave = octave;
         this.duration = duration;
      }
   }

   // Agile approach: Let's allow one voice per measure.

   public class Measure {
      private List<Note> voice;
      Rational duration;

      public Measure(Rational duration) {
         this.voice = new List<Note>();
         this.duration = duration;
      }

      public Rational Length() {
         Rational sum = new Rational(0);
         foreach (Note n in voice) {
            sum = sum.Add(n.GetDuration());
         }
         return sum;
      }

      public bool AddNote(Note note) {
         Rational currentLength = Length();
         Rational newLength = currentLength.Add(note.GetDuration());
         if (newLength.CompareTo(duration) > 0)
            return false;
         else {
            voice.Add(note);
            return true;
         }
      }
   }

   // In this first version, we're going to support any base note in major or minor.

   public class Scale {

      public enum ScaleTypes { Major, Minor };

      private int [] scale;

      private static int[] MajorIntervals = { 2, 2, 1, 2, 2, 2, 1 };

      private static int[] MinorIntervals = { 2, 1, 2, 2, 1, 2, 2 };


      // chunk-tones-begin
      public static string[] tones = { "C", "C#", "D", "D#", "E", "F",
         "F#", "G", "G#", "A", "A#", "B" };
      // chunk-tones-end

      // chunk-findtone-begin
      public static int FindTone(string key) {
         for (int i=0; i < tones.GetLength(0); i++) {
            if (key == tones[i])
               return i;
         }
         return -1;
      }
      // chunk-findtone-end

      // chunk-compute-begin
      private static void ComputeScale(string key, int[] steps, int[] scale) {
         int tonePosition = 0;
         int startTone;

         startTone = FindTone(key);
         if (startTone < 0)
            return;
         if (steps.GetLength(0)+1 != scale.GetLength(0))
            return;
         tonePosition = startTone;
         for (int i=0; i < steps.GetLength(0); i++) {
            scale[i] = tonePosition % tones.GetLength(0);
            tonePosition += steps[i];
         }
         scale[scale.Length-1] = scale[0];
      }
      // chunk-compute-end

      public Scale(string key, ScaleTypes type) {
         scale = new int [8];
         if (type ==  ScaleTypes.Major)
            ComputeScale(key, MajorIntervals, scale);
         else if (type == ScaleTypes.Minor)
            ComputeScale(key, MinorIntervals, scale);
         else
            ComputeScale(key, MajorIntervals, scale);
      }

      // position is interpreted mod 8 (scale.Length).
      public int GetTone(int position) {
         return scale[position % scale.Length];
      }

      public void Output() {
         foreach (int i in scale) {
            Console.Write ("{0} ", tones[i]);
         }
         Console.WriteLine ();
      }

   }

   public class Score {
      private Rational timeSignature;
      private Scale keySignature;


   }

   class MainClass
   {
      public static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");
      }
   }
}
