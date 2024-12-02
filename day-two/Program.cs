using System;

namespace day_two;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-two/input.txt");
        PartOne(input);
        PartTwo(input);
    }

    private static void PartOne(string[] input)
    {
        int numSafe = 0;

        foreach (string line in input)
        {
            int[] nums = line.Split(' ').Select(int.Parse).ToArray();

            bool isSafe = false;

            if (nums[0] < nums[1])
            {
                isSafe = CheckAscending(nums);
            }
            else
            {
                isSafe = CheckDescending(nums);
            }

            if (isSafe)
            {
                numSafe++;
            }
        }

        Console.WriteLine("Part One : " + numSafe);

        bool CheckAscending(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] >= nums[i + 1] || nums[i] + 3 < nums[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        bool CheckDescending(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[i + 1] || nums[i] - 3 > nums[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    private static void PartTwo(string[] input)
    {
        int numSafe = 0;

        foreach (string line in input)
        {
            List<int> nums = line.Split(' ').Select(int.Parse).ToList();

            bool isSafe = CheckAscending(nums, true) || CheckDescending(nums, true);

            if (isSafe)
            {
                numSafe++;
            }
        }

        Console.WriteLine("Part Two : " + numSafe);

        // Kinda iffy making 2 separate new lists, but idc, it works.
        bool CheckAscending(List<int> nums, bool canRemove)
        {
            List<int> newNums = new(nums);

            for (int i = 0; i < newNums.Count - 1; i++)
            {
                if (newNums[i] >= newNums[i + 1] || newNums[i] + 3 < newNums[i + 1])
                {
                    if (canRemove)
                    {
                        List<int> another = new(nums);
                        another.RemoveAt(i);
                        newNums.RemoveAt(i + 1);
                        return CheckAscending(newNums, false) || CheckAscending(another, false);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        bool CheckDescending(List<int> nums, bool canRemove)
        {
            List<int> newNums = new(nums);

            for (int i = 0; i < newNums.Count - 1; i++)
            {
                if (newNums[i] <= newNums[i + 1] || newNums[i] - 3 > newNums[i + 1])
                {
                    if (canRemove)
                    {
                        List<int> another = new(nums);
                        another.RemoveAt(i);
                        newNums.RemoveAt(i + 1);
                        return CheckDescending(newNums, false) || CheckDescending(another, false);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}