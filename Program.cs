using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        var inputLines = new System.Collections.Generic.List<string>();

        // Read all lines at once
        for (int i = 0; i < t; i++)
        {
            inputLines.Add(Console.ReadLine());
        }

        // Process each line
        foreach (var input in inputLines)
        {
            string pattern1 = @"[A-Z]{1}[0-9]{2}[A-Z]{2}";
            string pattern2 = @"[A-Z]{1}[0-9]{1}[A-Z]{2}";

            Regex rgx1 = new Regex(pattern1);
            Regex rgx2 = new Regex(pattern2);

            var matches1 = rgx1.Matches(input).Cast<Match>();
            var matches2 = rgx2.Matches(input).Cast<Match>();

            if (matches1.Count() == 0 && matches2.Count() == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                var allMatches = matches1.Concat(matches2);
                var sortedMatches = allMatches.OrderBy(m => m.Index).ToList();
                int totalMatchLength = sortedMatches.Sum(m => m.Length);
                bool canSplit = true;
                int lastEnd = 0;
                for (int i = 0; i < sortedMatches.Count; i++)
                {
                    if (sortedMatches[i].Index != lastEnd)
                    {
                        canSplit = false;
                        break;
                    }
                    lastEnd = sortedMatches[i].Index + sortedMatches[i].Length;
                }
                if (!canSplit || totalMatchLength != input.Length)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    foreach (var match in sortedMatches)
                    {
                        Console.Write("{0} ", match.Value);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

