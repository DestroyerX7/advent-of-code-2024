using System;
using System.IO;

namespace day_twelve;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-twelve/input.txt");

        int width = input[0].Length;
        int height = input.Length;
        Grid grid = new(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid.SetGardenPlot(x, y, input[y][x]);
            }
        }

        grid.UpdateConnections();

        Console.WriteLine("Part One : " + grid.GetTotalPrice());
        Console.WriteLine("Part Two : " + grid.GetTotalBulkPrice());
    }
}
