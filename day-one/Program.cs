using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_one;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-one/input.txt");
        PartOne(input);
        PartTwo(input);
    }

    private static void PartOne(string[] input)
    {
        int[] listOne = new int[input.Length];
        int[] listTwo = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            string[] separated = input[i].Split("   ");
            listOne[i] = int.Parse(separated[0]);
            listTwo[i] = int.Parse(separated[1]);
        }

        listOne = listOne.OrderBy(n => n).ToArray();
        listTwo = listTwo.OrderBy(n => n).ToArray();

        int totalDistance = 0;

        for (int i = 0; i < input.Length; i++)
        {
            int distance = Math.Abs(listOne[i] - listTwo[i]);
            totalDistance += distance;
        }

        Console.WriteLine("Part One : " + totalDistance);
    }

    private static void PartTwo(string[] input)
    {
        int[] listOne = new int[input.Length];
        int[] listTwo = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            string[] separated = input[i].Split("   ");
            listOne[i] = int.Parse(separated[0]);
            listTwo[i] = int.Parse(separated[1]);
        }

        Dictionary<int, int> numAppearances = new();

        foreach (int num in listTwo)
        {
            if (numAppearances.ContainsKey(num))
            {
                numAppearances[num]++;
            }
            else
            {
                numAppearances[num] = 1;
            }
        }

        int similarityScore = 0;

        foreach (int num in listOne)
        {
            if (numAppearances.ContainsKey(num))
            {
                similarityScore += numAppearances[num] * num;
            }
        }

        Console.WriteLine("Part One : " + similarityScore);
    }
}
