﻿using System;
using System.Collections.Generic;
using System.IO;

namespace day_twenty_five;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-twenty-five/input.txt");

        List<int[]> keyHeights = new();
        List<int[]> lockHeights = new();

        for (int i = 0; i < input.Length; i += 8)
        {
            bool isLock = input[i][0] == '#';

            int[] heights = new int[5];

            for (int j = 0; j < 5; j++)
            {
                int height = isLock ? 0 : 5;

                if (isLock)
                {
                    for (int k = i + 1; input[k][j] == '#'; k++)
                    {
                        height++;
                    }
                }
                else
                {
                    for (int k = i + 1; input[k][j] == '.'; k++)
                    {
                        height--;
                    }
                }

                heights[j] = height;
            }

            if (isLock)
            {
                lockHeights.Add(heights);
            }
            else
            {
                keyHeights.Add(heights);
            }
        }

        int numFits = 0;

        foreach (int[] keyHeight in keyHeights)
        {
            foreach (int[] lockHeight in lockHeights)
            {
                bool fits = true;

                for (int i = 0; i < 5; i++)
                {
                    if (keyHeight[i] + lockHeight[i] > 5)
                    {
                        fits = false;
                        break;
                    }
                }

                if (fits)
                {
                    numFits++;
                }
            }
        }

        Console.WriteLine("Part One : " + numFits);
    }
}
