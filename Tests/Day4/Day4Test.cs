using AdventOfCode2022.Solutions.Day4;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day4;

public class Day4Test
{
    private readonly ITestOutputHelper output;

    public Day4Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputFirstPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day4/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int pair = Solution.FirstPart(exampleInputStream);
        Assert.Equal(2, pair);
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputSecondPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day4/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int pair = Solution.SecondPart(exampleInputStream);
        Assert.Equal(4, pair);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day4/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int pair = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {pair}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day4/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int pair = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {pair}");
    }
}