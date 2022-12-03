using AdventOfCode2022.Solutions.Day1;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Day1;

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
        using Stream? exampleInputStream = File.Open("./Tests/Day1/ExampleInput.txt", FileMode.Open);
        int maxCalory = Solution.FirstPart(exampleInputStream);
        Assert.Equal(24_000, maxCalory);
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputFirstPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day1/Input.txt", FileMode.Open);
        int maxCalory = Solution.FirstPart(inputStream);
        output.WriteLine($"First Part: {maxCalory}");
    }

    [Fact]
    public void ShouldBeAbleToSolveRealInputSecondPart()
    {
        using Stream? inputStream = File.Open("./Tests/Day1/Input.txt", FileMode.Open);
        int maxCalory = Solution.SecondPart(inputStream);
        output.WriteLine($"Second Part: {maxCalory}");
    }
}