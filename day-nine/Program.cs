using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_nine;

public class Program
{
    private static void Main(string[] args)
    {
        string input = File.ReadAllText("D:/VS Code Projects/advent-of-code-2024/day-nine/input.txt");
        PartOne(input);
        PartTwo(input);
    }

    private static void PartOne(string input)
    {
        List<string> unwrapped = new();

        int id = 0;
        for (int i = 0; i < input.Length; i += 2)
        {
            int blockSize = int.Parse(input[i].ToString());
            int spaceSize = i + 1 < input.Length ? int.Parse(input[i + 1].ToString()) : 0;

            for (int j = 0; j < blockSize; j++)
            {
                unwrapped.Add(id.ToString());
            }

            for (int j = 0; j < spaceSize; j++)
            {
                unwrapped.Add(".");
            }

            id++;
        }

        int periodIndex = Array.IndexOf(unwrapped.ToArray(), ".");
        int lastValueIndex = unwrapped.Count - 1;
        while (periodIndex < lastValueIndex)
        {
            if (unwrapped[lastValueIndex] != ".")
            {
                unwrapped[periodIndex] = unwrapped[lastValueIndex];
                unwrapped[lastValueIndex] = ".";
                periodIndex = Array.IndexOf(unwrapped.ToArray(), ".");
            }

            lastValueIndex--;
        }

        long checkSum = 0;

        for (int i = 1; i < unwrapped.Count; i++)
        {
            if (unwrapped[i] == ".")
            {
                break;
            }

            int num = int.Parse(unwrapped[i].ToString());
            checkSum += i * num;
        }

        Console.WriteLine("Part One : " + checkSum);
    }

    private static void PartTwo(string input)
    {
        List<FileBlock> unwrapped = new();

        int id = 0;
        for (int i = 0; i < input.Length; i += 2)
        {
            int blockSize = int.Parse(input[i].ToString());
            int spaceSize = i + 1 < input.Length ? int.Parse(input[i + 1].ToString()) : 0;

            if (blockSize > 0)
            {
                unwrapped.Add(new(blockSize, id));
            }

            if (spaceSize > 0)
            {
                unwrapped.Add(new(spaceSize));
            }

            id++;
        }

        for (int i = unwrapped.Count - 1; i >= 0; i--)
        {
            if (!unwrapped[i].IsFreeSpace && !unwrapped[i].AlreadyMoved)
            {
                for (int j = 0; j < i; j++)
                {
                    if (unwrapped[j].IsFreeSpace && unwrapped[j].Size >= unwrapped[i].Size)
                    {
                        FileBlock fileBlock = unwrapped[i];
                        unwrapped[j].SetFreeSpaceAmount(unwrapped[j].Size - fileBlock.Size);
                        unwrapped.RemoveAt(i);
                        unwrapped.Insert(i, new(fileBlock.Size));
                        bool yo = CombineFreeSpace(unwrapped, i);
                        unwrapped.Insert(j, fileBlock);
                        fileBlock.SetAsMoved();

                        if (!yo)
                        {
                            i++;
                        }
                        break;
                    }
                }
            }
        }

        string[] concatenated = Array.Empty<string>();
        foreach (FileBlock fileBlock in unwrapped)
        {
            concatenated = concatenated.Concat(fileBlock.Files).ToArray();
        }

        long checkSum = 0;
        for (int i = 1; i < concatenated.Length; i++)
        {
            if (concatenated[i] != ".")
            {
                int num = int.Parse(concatenated[i].ToString());
                checkSum += i * num;
            }
        }

        Console.WriteLine("Part Two : " + checkSum);
    }

    private static bool CombineFreeSpace(List<FileBlock> fileBlocks, int index)
    {
        if (index + 1 >= 0 && index + 1 < fileBlocks.Count && fileBlocks[index + 1].IsFreeSpace)
        {
            int sizeOnRight = fileBlocks[index + 1].Size;
            fileBlocks[index].SetFreeSpaceAmount(fileBlocks[index].Size + sizeOnRight);
            fileBlocks.RemoveAt(index + 1);
        }

        if (index - 1 >= 0 && index - 1 < fileBlocks.Count && fileBlocks[index - 1].IsFreeSpace)
        {
            int sizeOnLeft = fileBlocks[index - 1].Size;
            fileBlocks[index].SetFreeSpaceAmount(fileBlocks[index].Size + sizeOnLeft);
            fileBlocks.RemoveAt(index - 1);
        }

        return index - 1 >= 0 && index - 1 < fileBlocks.Count && fileBlocks[index - 1].IsFreeSpace;
    }
}
