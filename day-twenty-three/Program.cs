using System;
using System.Collections.Generic;
using System.IO;

namespace day_twenty_three;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-twenty-three/input.txt");

        Dictionary<string, HashSet<string>> computerToConnections = new();

        foreach (string connections in input)
        {
            string[] computers = connections.Split('-');

            if (!computerToConnections.ContainsKey(computers[0]))
            {
                computerToConnections[computers[0]] = new()
                {
                    computers[1],
                };
            }
            else
            {
                computerToConnections[computers[0]].Add(computers[1]);
            }

            if (!computerToConnections.ContainsKey(computers[1]))
            {
                computerToConnections[computers[1]] = new()
                {
                    computers[0],
                };
            }
            else
            {
                computerToConnections[computers[1]].Add(computers[0]);
            }
        }

        int numSets = 0;

        foreach (var computerToConnection in computerToConnections)
        {
            foreach (string connection in computerToConnection.Value)
            {
                foreach (string secondConnection in computerToConnections[connection])
                {
                    if (computerToConnections[secondConnection].Contains(computerToConnection.Key))
                    {
                        if (computerToConnection.Key.StartsWith('t') || connection.StartsWith('t') || secondConnection.StartsWith('t'))
                        {
                            numSets++;
                        }
                    }
                }
            }
        }

        Console.WriteLine("Part One : " + numSets / 6.0);
    }
}
