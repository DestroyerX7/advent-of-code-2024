using System;
using System.IO;
using System.Linq;

namespace day_seven;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2024/day-seven/input.txt");

        long totalCalibrationResultPartOne = 0;
        long totalCalibrationResultPartTwo = 0;

        foreach (string line in input)
        {
            string[] split = line.Split(": ");
            long testValue = long.Parse(split[0]);
            int[] nums = split[1].Split(' ').Select(int.Parse).ToArray();

            if (ValidPermutationPartOne(testValue, nums))
            {
                totalCalibrationResultPartOne += testValue;
            }

            if (ValidPermutationPartTwo(testValue, nums))
            {
                totalCalibrationResultPartTwo += testValue;
            }
        }

        Console.WriteLine("Part One : " + totalCalibrationResultPartOne);
        Console.WriteLine("Part Two : " + totalCalibrationResultPartTwo);
    }

    private static bool ValidPermutationPartOne(long testValue, int[] nums)
    {
        long numPermutations = (long)Math.Pow(2, nums.Length - 1);

        for (int i = 0; i < numPermutations; i++)
        {
            long sum = nums[0];
            string binary = Convert.ToString(i, 2);
            char[] charArray = binary.ToCharArray().Reverse().ToArray();
            binary = new string(charArray);

            for (int j = 1; j < nums.Length && sum <= testValue; j++)
            {
                if (j - 1 >= binary.Length || binary[j - 1] == '0')
                {
                    sum *= nums[j];
                }
                else
                {
                    sum += nums[j];
                }
            }

            if (sum == testValue)
            {
                return true;
            }
        }

        return false;
    }

    private static bool ValidPermutationPartTwo(long testValue, int[] nums)
    {
        long numPermutations = (long)Math.Pow(3, nums.Length - 1);

        for (int i = 0; i < numPermutations; i++)
        {
            long sum = nums[0];
            string binary = ToBaseThree(i);
            char[] charArray = binary.ToCharArray().Reverse().ToArray();
            binary = new string(charArray);

            for (int j = 1; j < nums.Length && sum <= testValue; j++)
            {
                if (j - 1 >= binary.Length || binary[j - 1] == '0')
                {
                    sum *= nums[j];
                }
                else if (binary[j - 1] == '1')
                {
                    sum += nums[j];
                }
                else
                {
                    string sumString = sum.ToString();
                    sumString += nums[j];
                    sum = long.Parse(sumString);
                }
            }

            if (sum == testValue)
            {
                return true;
            }
        }

        return false;
    }

    private static string ToBaseThree(long num)
    {
        string baseThree = "";

        while (num != 0)
        {
            int remainder = (int)num % 3;
            num /= 3;
            baseThree += remainder;
        }

        char[] charArray = baseThree.ToCharArray().Reverse().ToArray();
        return new string(charArray);
    }
}
