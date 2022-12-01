using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace AdventOfCode2022.Solutions.Day1;

internal sealed class Solution
{
    private static IEnumerable<int> GetCalories(Stream fileStream)
    {
        List<int> calories = new() { 0 };
        using StreamReader reader = new(fileStream, Encoding.UTF8);

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(0);
                continue;
            }

            _ = int.TryParse(line, out int calory);
            calories[^1] += calory;
        }

        return calories;
    }

    public static int FirstPart(Stream fileStream)
    {
        IEnumerable<int> calories = GetCalories(fileStream);
        return calories.Max();
    }

    public static int SecondPart(Stream fileStream)
    {
        IEnumerable<int> calories = GetCalories(fileStream);
        return calories.OrderByDescending(x => x).Take(3).Sum();
    }
}
