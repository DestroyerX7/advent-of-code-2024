using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_eleven;

public class Program
{
    private static void Main(string[] args)
    {
        string input = File.ReadAllText("D:/VS Code Projects/advent-of-code-2024/day-eleven/input.txt");

        List<string> stones = input.Split(' ').ToList();

        Console.WriteLine("Part One : " + GetNumStonesAfterBlinks(stones, 25));
        Console.WriteLine("Part Two : " + GetNumStonesAfterBlinks(stones, 75));
    }

    private static long GetNumStonesAfterBlinks(List<string> initialStones, int numBlinks)
    {
        Dictionary<string, long> stonesCount = new();
        initialStones.ForEach(s => stonesCount.Add(s, 1));

        for (int i = 0; i < numBlinks; i++)
        {
            Dictionary<string, long> currentStonesCount = new(stonesCount);

            foreach (KeyValuePair<string, long> stoneCount in currentStonesCount)
            {
                string stone = stoneCount.Key;
                long count = stoneCount.Value;

                if (count < 1)
                {
                    continue;
                }

                if (stone == "0")
                {
                    IncrementCount(stonesCount, "1", count);
                }
                else if (stone.Length % 2 == 0)
                {
                    string newStoneOne = stone[..(stone.Length / 2)];
                    string newStoneTwo = long.Parse(stone[(stone.Length / 2)..]).ToString();

                    IncrementCount(stonesCount, newStoneOne, count);
                    IncrementCount(stonesCount, newStoneTwo, count);
                }
                else
                {
                    long newNum = long.Parse(stone) * 2024;
                    IncrementCount(stonesCount, newNum.ToString(), count);
                }

                stonesCount[stone] -= count;
            }
        }

        return stonesCount.Sum(s => s.Value);
    }

    private static void IncrementCount(Dictionary<string, long> dict, string value, long multiplier)
    {
        if (dict.ContainsKey(value))
        {
            dict[value] += multiplier;
        }
        else
        {
            dict[value] = multiplier;
        }
    }
}
