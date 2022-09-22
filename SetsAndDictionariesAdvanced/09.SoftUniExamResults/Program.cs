using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        public static void Main()
        {
            SortedDictionary<string, int> participantsPoints = new SortedDictionary<string, int>();
            SortedDictionary<string, int> languagesSubmissions = new SortedDictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "exam finished")
                {
                    break;
                }

                string[] tokens = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (tokens[1] == "banned")
                {
                    participantsPoints.Remove(name);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!participantsPoints.ContainsKey(name))
                {
                    participantsPoints.Add(name, 0);
                }

                if (participantsPoints[name] < points)
                {
                    participantsPoints[name] = points;
                }

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }

                languagesSubmissions[language]++;
            }

            var orderedParticipants = participantsPoints.OrderByDescending(p => p.Value);

            var orderedLanguagesSubmissions = languagesSubmissions.OrderByDescending(p => p.Value);

            Console.WriteLine("Results:");

            foreach (var participantPoints in orderedParticipants)
            {
                Console.WriteLine($"{participantPoints.Key} | {participantPoints.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var languageSubmissions in orderedLanguagesSubmissions)
            {
                Console.WriteLine($"{languageSubmissions.Key} - {languageSubmissions.Value}");
            }
        }
    }
}
