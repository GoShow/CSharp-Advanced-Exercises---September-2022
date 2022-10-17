using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>
            {
                {
                    "pear", new HashSet<char>()
                },
                {
                    "flour", new HashSet<char>()
                },
                {
                    "pork", new HashSet<char>()
                },
                {
                    "olive", new HashSet<char>()
                }
            };

            Queue<char> vowels = new Queue<char>(
                string.Join("", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));

            Stack<char> consonants = new Stack<char>(
                string.Join("", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }

                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }

            List<string> foundWords = words
                .Where(w => w.Key.Count() == w.Value.Count)
                .Select(w => w.Key)
                .ToList();

            Console.WriteLine($"Words found: {foundWords.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, foundWords));
        }
    }
}
