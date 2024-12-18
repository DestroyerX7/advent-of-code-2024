using System;
using System.Collections.Generic;
using System.IO;

namespace day_sixteen;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-sixteen/input.txt");

        int width = input[0].Length;
        int height = input.Length;
        Grid grid = new(width, height);

        Vector2 startPos = new(-1, -1);
        Vector2 endPos = new(-1, -1);
        Vector2 startDirection = Vector2.Right;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2 pos = new(x, y);
                grid.SetGridNode(pos, input[y][x] == '#');

                switch (input[y][x])
                {
                    case 'S':
                        startPos = new(x, y);
                        break;
                    case 'E':
                        endPos = new(x, y);
                        break;
                }
            }
        }

        grid.UpdateConnections();

        Console.WriteLine("Part One : " + grid.GetLowestScore(startPos, endPos, startDirection));
    }
}
