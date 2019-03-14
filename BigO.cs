using System;
using System.Linq;
using System.Diagnostics;

class MainClass {
  public static void Main (string[] args) {
  
  /*  string[] word = new string[10000];
    word = Enumerable.Repeat("nemo", 10000).ToArray();
    FindNemo(word);*/

    string[] strArray = new string[] {"a","b", "c", "d", "e"};
    LogAllPairsofArray(strArray);
  }

// Testing Big O ... O(n) --> Linear Time
  private static void FindNemo(string[] word)
  {
    Console.WriteLine ("Number of elements in the array: " + word.Length);

    var watch = Stopwatch.StartNew();
    for (int i=0; i < word.Length; i++)
    {
      if (word[i] =="nemo")
        Console.WriteLine ("Found Nemo");
    } 

    watch.Stop();

    Console.WriteLine("Function took " + watch.ElapsedMilliseconds + " milliseconds");
  }

// Big O = O(n^2)
  private static void LogAllPairsofArray(string[] strArray)
    {
        for (int i=0; i<strArray.Length; i++)
        {
          for (int j=0; j<strArray.Length; j++)
          {
            Console.WriteLine(strArray[i] +"," +strArray[j]);
          }
        }
    }
  }

