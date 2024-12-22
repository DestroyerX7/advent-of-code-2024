using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_twenty_two;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-twenty-two/input.txt");

        Dictionary<string, int>[] sequenceToSellPrices = new Dictionary<string, int>[input.Length];

        long sumSecrets = 0;

        for (int i = 0; i < input.Length; i++)
        {
            long currentSecret = long.Parse(input[i]);

            int[] priceChanges = new int[2000];
            sequenceToSellPrices[i] = new();

            for (int j = 0; j < 2000; j++)
            {
                int oldPrice = (int)(currentSecret % 10);

                currentSecret = (currentSecret * 64) ^ currentSecret;
                currentSecret %= 16777216;

                currentSecret = (currentSecret / 32) ^ currentSecret;
                currentSecret %= 16777216;

                currentSecret = (currentSecret * 2048) ^ currentSecret;
                currentSecret %= 16777216;

                int newPrice = (int)(currentSecret % 10);
                priceChanges[j] = newPrice - oldPrice;

                if (j >= 3)
                {
                    string sequence = $"{priceChanges[j - 3]}{priceChanges[j - 2]}{priceChanges[j - 1]}{priceChanges[j]}";

                    if (!sequenceToSellPrices[i].ContainsKey(sequence))
                    {
                        sequenceToSellPrices[i][sequence] = newPrice;
                    }
                }
            }

            sumSecrets += currentSecret;
        }

        string[] sequences = sequenceToSellPrices.SelectMany(d => d.Keys).Distinct().ToArray();
        long mostBananas = long.MinValue;

        foreach (string sequence in sequences)
        {
            long numBananas = 0;

            foreach (Dictionary<string, int> dictionary in sequenceToSellPrices)
            {
                if (dictionary.ContainsKey(sequence))
                {
                    numBananas += dictionary[sequence];
                }
            }

            if (numBananas > mostBananas)
            {
                mostBananas = numBananas;
            }
        }

        Console.WriteLine("Part One : " + sumSecrets);
        Console.WriteLine("Part Two : " + mostBananas);
    }
}
