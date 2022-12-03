using AdventOfCode2022.Solutions.Day2;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day2;

public class Day3Test
{
    private readonly ITestOutputHelper output;

    public Day3Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInput()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day2/ExampleInput.txt", FileMode.Open);
        int score = Solution.FirstPart(exampleInputStream);
        Assert.Equal(15, score);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day2/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {score}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day2/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int score = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {score}");
    }
}