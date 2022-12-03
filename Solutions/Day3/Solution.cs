using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day3;

internal class Solution
{
    public static int FirstPart(Stream fileStream)
    {
        return fileStream
            .ToEnumerable()
            .Select(line => line.Chunk(line.Length / 2).Take(2))
            .Select(chunks => chunks.First().Intersect(chunks.Last()).First())
            .Select(letter => letter switch
            {
                char l when Char.IsUpper(l) => (byte)l - 38,
                char l when Char.IsLower(l) => (byte)l- 96,
                _ => 0,
            })
            .Sum();
    }

    public static int SecondPart(Stream fileStream)
    {
        return fileStream
            .ToEnumerable()
            .Chunk(3)
            .Select(chunks => chunks.Skip(1).Aggregate(new HashSet<char>(chunks.First().ToCharArray()), (acc, chunk) =>
            {
                acc.IntersectWith(chunk.ToCharArray());
                return acc;
            }))
            .Select(letter => letter.First() switch
            {
                char l when Char.IsUpper(l) => (byte)l - 38,
                char l when Char.IsLower(l) => (byte)l - 96,
                _ => 0,
            })
            .Sum();
    }
}
