using System;
using System.IO;

namespace day_eighteen;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-eighteen/input.txt");

        PartOne(input);
        PartTwo(input);
    }

    private static void PartOne(string[] input)
    {
        int width = 71;
        int height = 71;
        Grid grid = new(width, height);

        for (int i = 0; i < 1024; i++)
        {
            int commaIndex = input[i].IndexOf(',');
            int x = int.Parse(input[i][..commaIndex]);
            int y = int.Parse(input[i][(commaIndex + 1)..]);
            grid.SetAsCurrupted(x, y);
        }

        grid.UpdateConnections();

        Console.WriteLine("Part One : " + grid.GetLowestSteps(new(0, 0), new(width - 1, height - 1)));
    }

    private static void PartTwo(string[] input)
    {
        int width = 71;
        int height = 71;
        Grid grid = new(width, height);

        grid.UpdateConnections();

        for (int i = 0; i < input.Length; i++)
        {
            int commaIndex = input[i].IndexOf(',');
            int x = int.Parse(input[i][..commaIndex]);
            int y = int.Parse(input[i][(commaIndex + 1)..]);

            grid.SetAsCurrupted(x, y);

            int lowestSteps = grid.GetLowestSteps(new(0, 0), new(width - 1, height - 1));

            if (lowestSteps == -1)
            {
                Console.WriteLine("Part Two : " + input[i]);
                return;
            }
        }
    }
}
