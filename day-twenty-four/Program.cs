using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_twenty_four;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-twenty-four/input.txt");

        Dictionary<string, int> dict = new();

        int i = 0;
        while (input[i].Length != 0)
        {
            string[] split = input[i].Split(": ");
            dict[split[0]] = int.Parse(split[1]);
            i++;
        }

        HashSet<string[]> operations = new();

        while (i < input.Length - 1)
        {
            i++;

            string[] split = input[i].Split(' ');

            operations.Add(split);

            CheckOperations(operations, dict);
        }

        char[] bits = dict.Where(k => k.Key.StartsWith('z')).OrderByDescending(k => k.Key).Select(k => k.Value.ToString()[0]).ToArray();
        string binaryNum = new(bits);
        Console.WriteLine("Part One : " + Convert.ToInt64(binaryNum, 2));
    }

    private static void CheckOperations(HashSet<string[]> operations, Dictionary<string, int> dict)
    {
        foreach (string[] operation in operations)
        {
            if (dict.ContainsKey(operation[0]) && dict.ContainsKey(operation[2]))
            {
                switch (operation[1])
                {
                    case "AND":
                        dict[operation[4]] = dict[operation[0]] & dict[operation[2]];
                        break;
                    case "OR":
                        dict[operation[4]] = dict[operation[0]] | dict[operation[2]];
                        break;
                    case "XOR":
                        dict[operation[4]] = dict[operation[0]] ^ dict[operation[2]];
                        break;
                }

                operations.Remove(operation);

                CheckOperations(operations, dict);
            }
        }
    }
}
