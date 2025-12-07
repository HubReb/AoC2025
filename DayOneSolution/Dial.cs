namespace DayOneSolution;

public struct Dial(int currentPosition, int highestNumber, int lowestNumber)
{
    public int CurrentPosition { get; set; } = currentPosition;

    public int HighestNumber { get; } = highestNumber;
    public int LowestNumber { get; } = lowestNumber;
}