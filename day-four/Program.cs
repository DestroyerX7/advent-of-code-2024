using System;
using System.IO;

namespace day_four;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-four/input.txt");

        int width = input[0].Length;
        int height = input.Length;
        Grid grid = new(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid.AddGridLetter(x, y, input[y][x]);
            }
        }

        Console.WriteLine("Part One : " + grid.GetNumAppearancesPartOne());
        Console.WriteLine("Part Two : " + grid.GetNumAppearancesPartTwo());
    }
}
