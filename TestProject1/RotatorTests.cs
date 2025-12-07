using DayOneSolution;

namespace TestProject1;

public class RotatorTests
{
    [Theory]
    [InlineData(50, 1, 51)]
    [InlineData(50, 10, 60)]
    [InlineData(0, 1, 1)]
    [InlineData(50, 49, 99)]
    [InlineData(50, 50, 0)]
    [InlineData(50, 150, 0)]
    [InlineData(10, 15, 25)]
    public void RotatorDialUp(int currentValue, int numberOfClicks, int expectedValue)
    {
        var rotator = new Rotator(currentValue, 99, 0);
        rotator.Rotate(true, numberOfClicks);
        Assert.Equal(expectedValue, rotator.GetCurrentPositionOfDial());
    }
    
    [Theory]
    [InlineData(50, 1, 49)]
    [InlineData(50, 10, 40)]
    [InlineData(0, 1, 99)]
    [InlineData(50, 49, 1)]
    [InlineData(50, 50, 0)]
    [InlineData(50, 150, 0)]
    public void RotatorDialDown(int currentValue, int numberOfClicks, int expectedValue)
    {
        var rotator = new Rotator(currentValue, 99, 0);
        rotator.Rotate(false, numberOfClicks);
        Assert.Equal(expectedValue, rotator.GetCurrentPositionOfDial());
    }

    [Theory]
    [InlineData(50, 1, 0)]
    [InlineData(50, 10, 0)]
    [InlineData(0, 1, 0)]
    [InlineData(50, 49, 0)]
    [InlineData(50, 50, 1)]
    [InlineData(50, 150, 2)]
    [InlineData(50, 10000, 100)]
    [InlineData(50, 1000, 10)]
    public void RotatorCounterUp(int currentValue, int numberOfClicks, int expectedValue)
    {
        var rotator = new Rotator(currentValue, 99, 0);
        rotator.Rotate(true, numberOfClicks);
        Assert.Equal(expectedValue, rotator.CounterOfCompletedRounds);
    }
    
    [Theory]
    [InlineData(50, 1, 0)]
    [InlineData(50, 10, 0)]
    [InlineData(0, 1, 0)]
    [InlineData(50, 49, 0)]
    [InlineData(50, 50, 1)]
    [InlineData(50, 150, 2)]
    [InlineData(50, 10000, 100)]
    [InlineData(50, 1000, 10)]
    public void RotatorCounterDown(int currentValue, int numberOfClicks, int expectedValue)
    {
        var rotator = new Rotator(currentValue, 99, 0);
        rotator.Rotate(false, numberOfClicks);
        Assert.Equal(expectedValue, rotator.CounterOfCompletedRounds);
    }
}