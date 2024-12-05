using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_five;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-five/input.txt");

        Dictionary<int, HashSet<int>> rules = new();
        int middleSum = 0;
        int middleSumUnordered = 0;

        foreach (string line in input)
        {
            if (line.Contains('|'))
            {
                int[] rule = line.Split('|').Select(int.Parse).ToArray();

                if (rules.ContainsKey(rule[0]))
                {
                    rules[rule[0]].Add(rule[1]);
                }
                else
                {
                    rules[rule[0]] = new()
                    {
                        rule[1]
                    };
                }
            }
            else if (line.Contains(','))
            {
                int[] numsToAdd = line.Split(',').Select(int.Parse).ToArray();
                bool inOrder = IsOrdered(numsToAdd, rules);

                if (inOrder)
                {
                    middleSum += numsToAdd[numsToAdd.Length / 2];
                }
                else
                {
                    Reorder(numsToAdd, rules);
                    middleSumUnordered += numsToAdd[numsToAdd.Length / 2];
                }
            }
        }

        Console.WriteLine("Part One : " + middleSum);
        Console.WriteLine("Part Two : " + middleSumUnordered);
    }

    private static void Reorder(int[] nums, Dictionary<int, HashSet<int>> rules)
    {
        bool inOrder = false;

        // Swaps numbers that are not in the right order one at a time until they are in order.
        while (!inOrder)
        {
            // Looks for a number that should be before any of the numbers in rules and then swaps them.
            for (int i = 0; i < nums.Length; i++)
            {
                if (rules.ContainsKey(nums[i]))
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (rules[nums[i]].Contains(nums[j]))
                        {
                            (nums[i], nums[j]) = (nums[j], nums[i]);
                            break;
                        }
                    }
                }
            }

            inOrder = IsOrdered(nums, rules);
        }
    }

    private static bool IsOrdered(int[] nums, Dictionary<int, HashSet<int>> rules)
    {
        HashSet<int> numsAdded = new();
        foreach (int num in nums)
        {
            if (rules.ContainsKey(num) && numsAdded.Any(n => rules[num].Contains(n)))
            {
                return false;
            }

            numsAdded.Add(num);
        }

        return true;
    }
}
