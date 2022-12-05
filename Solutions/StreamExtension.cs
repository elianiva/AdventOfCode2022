using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions;

public static class StreamExtension
{
    public static IEnumerable<string> ToEnumerable(this Stream stream)
    {
        using StreamReader streamReader = new(stream);
        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;
            yield return line;
        }
    }

    public static IEnumerable<string> ToLines(this Stream stream)
    {
        using StreamReader streamReader = new(stream);
        return streamReader.ReadToEnd().Split('\n');
    }
}
