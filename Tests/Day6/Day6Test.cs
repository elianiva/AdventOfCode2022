using AdventOfCode2022.Solutions.Day6;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day6;

public class Day6Test
{
    private readonly ITestOutputHelper output;

    public Day6Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void ShouldBeAbleToSolveExampleInputFirstPart(string input, int expected)
    {
        int count = Solution.Solve(input, 4);
        Assert.Equal(expected, count);
    }

    [Fact]
    public void ShouldBeAbleToSolveInputFirstPart()
    {
        using FileStream? fileStream = File.Open("./Tests/Day6/Input.txt", FileMode.Open);
        using StreamReader reader = new(fileStream);
        int count = Solution.Solve(reader.ReadToEnd(), 4);
        output.WriteLine($"First Part: {count}");
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void ShouldBeAbleToSolveExampleInputSecondPart(string input, int expected)
    {
        int count = Solution.Solve(input, 14);
        Assert.Equal(expected, count);
    }

    [Fact]
    public void ShouldBeAbleToSolveInputSecondPart()
    {
        using FileStream? fileStream = File.Open("./Tests/Day6/Input.txt", FileMode.Open);
        using StreamReader reader = new(fileStream);
        int count = Solution.Solve(reader.ReadToEnd(), 14);
        output.WriteLine($"First Part: {count}");
    }
}