using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_nineteen;

public class Program
{
    private static readonly Dictionary<string, long> _patternToNumWays = new();

    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-nineteen/input.txt");

        List<string> patterns = input[0].Split(", ").ToList();

        int numPossible = 0;
        long numWays = 0;

        for (int i = 2; i < input.Length; i++)
        {
            if (IsPossible(input[i], patterns))
            {
                numPossible++;
            }

            numWays += NumWays(input[i], patterns);
        }

        Console.WriteLine("Part One : " + numPossible);
        Console.WriteLine("Part Two : " + numWays);
    }

    private static bool IsPossible(string design, List<string> patterns)
    {
        if (design.Length == 0)
        {
            return true;
        }

        foreach (string pattern in patterns)
        {
            if (design.IndexOf(pattern) == 0 && IsPossible(design[pattern.Length..], patterns))
            {
                return true;
            }
        }

        return false;
    }

    private static long NumWays(string design, List<string> patterns)
    {
        if (design.Length == 0)
        {
            return 1;
        }

        long totalNumWays = 0;

        foreach (string pattern in patterns)
        {
            if (design.IndexOf(pattern) == 0)
            {
                string remainingPattern = design[pattern.Length..];

                if (!_patternToNumWays.ContainsKey(remainingPattern))
                {
                    _patternToNumWays[remainingPattern] = NumWays(remainingPattern, patterns);
                }

                totalNumWays += _patternToNumWays[remainingPattern];
            }
        }

        return totalNumWays;
    }
}
