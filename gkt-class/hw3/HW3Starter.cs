using System;

namespace HW3 {
  class HW3Solution {
     static string[] GetStringArray(string input) {
        string[] parts = input.Split(',');
        return parts;
     }

     static int[] GetIntArray(string input) {
        string[] parts = input.Split(',');
        int[] intparts = new int[parts.Length];
        for (int i=0; i < parts.Length; i++)
           intparts[i] = int.Parse(parts[i]);
        return parts;
     }

     static void Main() {
        // reading in the category names into a string array
        int i;
        Console.WriteLine("Please enter the categories, separated by commas.");
        string categories = Console.ReadLine();
        string[] catnames = categories.Split(',');
        for (i=0; i < catnames.Length; i++)
           Console.WriteLine("category at position {0} = {1}", i, catnames[i]);
        
        // reading in the weight values into an integer array
        Console.WriteLine("Please enter the weights, separated by commas.");
        string weights = Console.ReadLine();
        string[] weightstrings = weights.Split(',');
        int[] weightvalues = new int[weightstrings.Length];
        for (i=0; i < weightstrings.Length; i++) {
           weightvalues[i] = int.Parse(weightstrings[i]);
           Console.WriteLine("weight at position {0} = {1}", i, weightvalues[i]);
        }
     }
  }
}
