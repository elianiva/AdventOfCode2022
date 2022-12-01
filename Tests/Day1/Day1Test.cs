using AdventOfCode2022.Solutions.Day1;
using Xunit;

namespace Tests.Day1;

public class UnitTest1
{
    [Fact]
    public void ShouldBeAbleToSolveExampleInput()
    {
        int maxCalory = Solution.FirstPart("./ExampleInput");
        Assert.Equal(24_000, maxCalory);
    }
}