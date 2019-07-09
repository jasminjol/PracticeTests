using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount_and_RepeatedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "There was a green house." +
                "Inside the green house there was a white house." +
                "Inside the white house there was a red house." +
                "Inside the red house there were lots of babies. What is it?";

            string[] words = input.Split(new char[] { ' ', ',', '.', '?' });

            Console.WriteLine("Number of words in the input is {0}", CountWords(words));
            Console.WriteLine("There are {0} occurrences of white in the input", RepeatedWord("white", words));
            Console.WriteLine("Printing count of each word");
            FindEachRepeatedWord(words);
        }

        public static int CountWords(string[] words)
        {
            return words.Count();
        }

        public static int RepeatedWord(string searchWord, string[] words)
        {
            var query = from word in words
                        where word.ToLowerInvariant() == searchWord.ToLowerInvariant()
                        select word;

            return query.Count();
        }

        public static void FindEachRepeatedWord(string[] words)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            for (int i=0; i<words.Length; i++)
            {
                if (wordCounts.ContainsKey(words[i]))
                {
                    wordCounts[words[i]] = wordCounts[words[i]] + 1;

                }
                else
                    wordCounts.Add(words[i], 1);
            }

            foreach (var pair in wordCounts)
            {
                Console.WriteLine("Word - {0}   Count - {1} ", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
