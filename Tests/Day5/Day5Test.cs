using AdventOfCode2022.Solutions.Day5;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day5;

public class Day5Test
{
    private readonly ITestOutputHelper output;

    public Day5Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputFirstPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day5/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        string topCrates = Solution.FirstPart(exampleInputStream);
        Assert.Equal("CMZ", topCrates);
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputSecondPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day5/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        string topCrates = Solution.SecondPart(exampleInputStream);
        Assert.Equal("MCD", topCrates);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day5/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        string topCrates = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {topCrates}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day5/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        string topCrates = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {topCrates}");
    }
}