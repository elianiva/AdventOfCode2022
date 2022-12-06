using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day6;

internal class Solution
{
    public static int Solve(string input, int markerLength)
    {
        return input.SkipLast(markerLength)
                    .TakeWhile((marker, index) => markerLength != input.Skip(index).Take(markerLength).Distinct().Count())
                    .Count() + markerLength;
    }
}
