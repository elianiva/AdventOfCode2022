using AdventOfCode2022.Solutions.Day7;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day7;

public class Day7Test
{
    private readonly ITestOutputHelper output;

    public Day7Test(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputFirstPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day7/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int totalSize = Solution.FirstPart(exampleInputStream);
        Assert.Equal(95437, totalSize);
    }

    [Fact]
    public void ShouldBeAbleToSolveExampleInputSecondPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day7/ExampleInput.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int totalSize = Solution.SecondPart(exampleInputStream);
        Assert.Equal(24933642, totalSize);
    }

    [Fact]
    public void ShouldBeAbleToSolveInputFirstPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day7/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int totalSize = Solution.FirstPart(exampleInputStream);
        output.WriteLine($"First Part: {totalSize}");
    }

    [Fact]
    public void ShouldBeAbleToSolveInputSecondPart()
    {
        using Stream? exampleInputStream = File.Open("./Tests/Day7/Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        int totalSize = Solution.SecondPart(exampleInputStream);
        output.WriteLine($"Second Part: {totalSize}");
    }
}