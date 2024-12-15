﻿using System;
using System.Collections.Generic;
using System.IO;

namespace day_fifteen;

public class Program
{
    private static readonly Dictionary<char, Vector2> _directions = new()
    {
        { '>', Vector2.Right },
        { '<', Vector2.Left },
        { '^', Vector2.Down },
        { 'v', Vector2.Up },
    };

    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-fifteen/input.txt");
        PartOne(input);
        PartTwo(input);
    }

    private static void PartOne(string[] input)
    {
        int width = input[0].Length;
        int height = Array.IndexOf(input, "");
        Grid grid = new(width, height);

        Vector2 robotPos = new(-1, -1);

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (y < height)
                {
                    switch (input[y][x])
                    {
                        case '@':
                            robotPos = new(x, y);
                            grid.SetGridPos(x, y, ItemType.Robot);
                            break;
                        case '#':
                            grid.SetGridPos(x, y, ItemType.Wall);
                            break;
                        case 'O':
                            grid.SetGridPos(x, y, ItemType.Box);
                            break;
                    }
                }
                else
                {
                    if (grid.TryMoveInDirectionPartOne(robotPos, _directions[input[y][x]]))
                    {
                        robotPos += _directions[input[y][x]];
                    }
                }
            }
        }

        Console.WriteLine("Part One : " + grid.GetGPSCoordinateSum());
    }

    private static void PartTwo(string[] input)
    {
        int width = input[0].Length * 2;
        int height = Array.IndexOf(input, "");
        Grid grid = new(width, height);

        Vector2 robotPos = new(-1, -1);

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (y < height)
                {
                    switch (input[y][x])
                    {
                        case '@':
                            robotPos = new(x * 2, y);
                            grid.SetGridPos(x * 2, y, ItemType.Robot);
                            break;
                        case '#':
                            grid.SetGridPos(x * 2, y, ItemType.Wall);
                            grid.SetGridPos(x * 2 + 1, y, ItemType.Wall);
                            break;
                        case 'O':
                            grid.SetGridPos(x * 2, y, ItemType.LeftBoxPart);
                            grid.SetGridPos(x * 2 + 1, y, ItemType.RightBoxPart);
                            break;
                    }
                }
                else
                {
                    if (grid.TryMoveInDirectionPartTwo(robotPos, _directions[input[y][x]]))
                    {
                        robotPos += _directions[input[y][x]];
                    }
                }
            }
        }

        Console.WriteLine("Part Two : " + grid.GetGPSCoordinateSum());
    }
}
