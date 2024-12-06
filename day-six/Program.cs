using System;
using System.IO;

namespace day_six;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-six/input.txt");

        int width = input[0].Length;
        int height = input.Length;

        Grid grid = new(width, height);
        int startX = 0;
        int startY = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid.SetGridNode(x, y, input[y][x]);

                if (input[y][x] == '^')
                {
                    startX = x;
                    startY = y;
                }
            }
        }

        Console.WriteLine("Part One : " + grid.GetNumPatrolPositions(startX, startY));
        Console.WriteLine("Part Two : " + grid.GetNumObstaclePlacementLocations(startX, startY));
    }
}
