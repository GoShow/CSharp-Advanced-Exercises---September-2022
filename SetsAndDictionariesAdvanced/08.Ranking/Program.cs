using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of contests")
                {
                    break;
                }

                string[] credentials = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                contests.Add(credentials[0], credentials[1]);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of submissions")
                {
                    break;
                }

                string[] tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = tokens[0];
                string pass = tokens[1];
                string candidate = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    UpsertCandidate(candidate, points, contest, candidates);
                }
            }

            string bestCandidate = candidates
                .OrderByDescending(c => c.Value.Values.Sum())
                .First().Key;

            int bestCandidateTotalPoints = candidates[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidateTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates)
            {
                var orderedByPointsDesc = candidate.Value.OrderByDescending(c => c.Value);

                Console.WriteLine(candidate.Key);

                foreach (var contest in orderedByPointsDesc)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void UpsertCandidate(string name, int points, string contest, SortedDictionary<string, Dictionary<string, int>> candidates)
        {
            if (!candidates.ContainsKey(name))
            {
                candidates[name] = new Dictionary<string, int>();
            }

            if (!candidates[name].ContainsKey(contest))
            {
                candidates[name][contest] = 0;
            }

            if (candidates[name][contest] < points)
            {
                candidates[name][contest] = points;
            }
        }
    }
}