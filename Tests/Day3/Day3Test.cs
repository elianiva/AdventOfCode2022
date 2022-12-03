using AdventOfCode2022.Solutions.Day3;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day3;

public class Day3Test
{
    private readonly ITestOutputHelper output;

    public Day3Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputFirstPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day3/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.FirstPart(exampleInputStream);
        Assert.Equal(157, score);
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputSecondPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day3/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.SecondPart(exampleInputStream);
        Assert.Equal(70, score);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day3/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {score}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day3/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {score}");
    }
}