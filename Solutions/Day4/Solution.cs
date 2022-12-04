using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day4;

internal class Solution
{
    public static int FirstPart(Stream fileStream)
    {
        return fileStream
            .ToEnumerable()
            .Select(line => line.Split(',')
                        .Select(range => range.Split('-').Select(n => int.Parse(n)))
                        .Select(range => Enumerable.Range(range.First(), range.Last() - range.First() + 1)))
            .Sum((range) =>
            {
                int intersected = range.First().Intersect(range.Last()).Count();
                int lhsCount = range.First().Count();
                int rhsCount = range.Last().Count();
                return intersected == lhsCount || intersected == rhsCount ? 1 : 0;
            });
    }

    public static int SecondPart(Stream fileStream)
    {
        return fileStream
            .ToEnumerable()
            .Select(line => line.Split(',')
                        .Select(range => range.Split('-').Select(n => int.Parse(n)))
                        .Select(range => Enumerable.Range(range.First(), range.Last() - range.First() + 1)))
            .Sum((range) => range.First().Intersect(range.Last()).Any() ? 1 : 0);
    }
}
