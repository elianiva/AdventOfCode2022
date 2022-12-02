using AdventOfCode2022.Solutions.Day2;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day2;

public class Day2Test
{
    private readonly ITestOutputHelper output;

    public Day2Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInput()
    {
        using Stream? exampleInputStream = new FileStream("./Tests/Day2/ExampleInput.txt", FileMode.Open);
        int score = Solution.FirstPart(exampleInputStream);
        Assert.Equal(15, score);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = new FileStream("./Tests/Day2/Input.txt", FileMode.Open);
        int score = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {score}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = new FileStream("./Tests/Day2/Input.txt", FileMode.Open);
        int score = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {score}");
    }
}