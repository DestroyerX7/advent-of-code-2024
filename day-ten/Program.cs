using System;
using System.IO;

namespace day_ten;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-ten/input.txt");

        int width = input[0].Length;
        int height = input.Length;
        Grid grid = new(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int num = int.Parse(input[y][x].ToString());
                grid.SetGridNode(x, y, num);
            }
        }

        grid.UpdateGridNodeConnections();

        Console.WriteLine("Part One : " + grid.GetSumTrailHeadScores());
        Console.WriteLine("Part Two : " + grid.GetSumTrailHeadRatings());
    }
}
