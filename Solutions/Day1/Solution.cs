using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions.Day1;

internal sealed class Solution
{
    public static int FirstPart(string path)
    {
        List<int> calories = new();
        IEnumerable<string> lines = File.ReadLines(path);

        int i = 0;
        foreach (ReadOnlySpan<char> line in lines)
        {
            if (line == "\n")
            {
                i++;
                continue;
            }

            _ = int.TryParse(line, out int calory);
            calories[i] += calory;
        }

        return calories.Max();
    }
}
