using System;
using System.IO;

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
        return intparts;
     }

     static void Main() {
        // reading in the category names into a string array
        int i;
        
        var reader = new StreamReader("sample.dat");
        //Console.WriteLine("Please enter the category names, separated by commas.");
        string categories = reader.ReadLine();
        string[] catnames = GetStringArray(categories);
        for (i=0; i < catnames.Length; i++)
           Console.WriteLine("category at position {0} = {1}", i, catnames[i]);
        
        // reading in the weight values into an integer array
        //Console.WriteLine("Please enter the weights, separated by commas.");
        string weights = reader.ReadLine();
        int[] weightvalues = GetIntArray(weights);
        for (i=0; i < weightvalues.Length; i++) {
           Console.WriteLine("weight at position {0} = {1}", i, weightvalues[i]);
        }

        // read in the number of items per category
        //Console.WriteLine("Please enter the number of items per category, separated by commas.");
        string numitems = reader.ReadLine();
        int[] numitemsvalues = GetIntArray(numitems);
        for (i=0; i < numitemsvalues.Length; i++) {
           Console.WriteLine("number of items at position {0} = {1}", i, numitemsvalues[i]);
        }

        reader.Close();

     }
  }
}
