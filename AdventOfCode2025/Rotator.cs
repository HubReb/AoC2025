namespace AdventOfCode2025;

public class Rotator(int currentPosition, int highestNumber, int lowestNumber)
{
    private Dial _dial = new Dial(currentPosition, highestNumber, lowestNumber);
    public int CounterOfCompletedRounds { get; private set; } = 0;
    public int CounterOfRotationsStoppedAtZero{ get; private set; } = 0;

    public void Rotate(bool direction, int numberOfClicks)
    {
        if (numberOfClicks <= 0)
        {
            throw new ArgumentException("numberOfClicks cannot be negative!");
        }

        if (direction)
        {
            IncreaseDialNumberByClicks(numberOfClicks);
        }
        else
        {
            DecreaseDialNumberByClicks(numberOfClicks);
        }

        if (_dial.CurrentPosition == 0) {
            CounterOfRotationsStoppedAtZero++;
        }
    }

    private void DecreaseDialNumberByClicks(int numberOfClicks)
    {
        while (numberOfClicks > _dial.HighestNumber)
        {
            CounterOfCompletedRounds++;
            numberOfClicks -= _dial.HighestNumber + 1;
        }
        if (_dial.CurrentPosition - numberOfClicks < _dial.LowestNumber)
        {
            numberOfClicks -= _dial.CurrentPosition + 1; 
            _dial.CurrentPosition = _dial.HighestNumber;
            CounterOfCompletedRounds++;
        }
        if (numberOfClicks == 0)
        {
            return;
        }
        _dial.CurrentPosition -= numberOfClicks;
        if (_dial.CurrentPosition == 0) { 
            CounterOfCompletedRounds++;
        }
    }

    private void IncreaseDialNumberByClicks(int numberOfClicks)
    {
        while (numberOfClicks > _dial.HighestNumber)
        {
            CounterOfCompletedRounds++;
            numberOfClicks -= _dial.HighestNumber + 1;
        }
        if (_dial.CurrentPosition + numberOfClicks > _dial.HighestNumber)
        {
            numberOfClicks -= _dial.HighestNumber - _dial.CurrentPosition + 1; 
            _dial.CurrentPosition = 0;
            CounterOfCompletedRounds++;
        }
        if (numberOfClicks == 0)
        {
            return;
        }
        _dial.CurrentPosition += numberOfClicks;
        if (_dial.CurrentPosition == 0)
        {
            CounterOfCompletedRounds++;
        }
    }

    public int GetCurrentPositionOfDial()
    {
        return _dial.CurrentPosition;
    }
}