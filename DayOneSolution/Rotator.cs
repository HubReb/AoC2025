namespace DayOneSolution;

public class Rotator(int currentPosition, int highestNumber, int lowestNumber)
{
    private Dial _dial = new(currentPosition, highestNumber, lowestNumber);
    public int CounterOfCompletedRounds { get; private set; }
    public int CounterOfRotationsStoppedAtZero { get; private set; }

    public void Rotate(bool direction, int numberOfClicks)
    {
        if (numberOfClicks <= 0) throw new ArgumentException("numberOfClicks cannot be negative!");

        if (direction)
            IncreaseDialNumberByClicks(numberOfClicks);
        else
            DecreaseDialNumberByClicks(numberOfClicks);

        if (_dial.CurrentPosition == 0) CounterOfRotationsStoppedAtZero++;
    }

    private void DecreaseDialNumberByClicks(int numberOfClicks)
    {
        numberOfClicks = HandleFullDialTurn(numberOfClicks);

        if (_dial.CurrentPosition == 0)
        {
            _dial.CurrentPosition = _dial.HighestNumber - numberOfClicks + 1;
            return;
        }
        if (_dial.CurrentPosition - numberOfClicks < _dial.LowestNumber)
        {
            numberOfClicks -= _dial.CurrentPosition + 1;
            _dial.CurrentPosition = _dial.HighestNumber;
            CounterOfCompletedRounds++;
        }
        _dial.CurrentPosition -= numberOfClicks;
        if (_dial.CurrentPosition == 0 && numberOfClicks != 0) CounterOfCompletedRounds++;
    }

    private void IncreaseDialNumberByClicks(int numberOfClicks)
    {
        numberOfClicks = HandleFullDialTurn(numberOfClicks);

        if (_dial.CurrentPosition + numberOfClicks > _dial.HighestNumber)
        {
            numberOfClicks -= _dial.HighestNumber - _dial.CurrentPosition + 1;
            _dial.CurrentPosition = 0;
            CounterOfCompletedRounds++;
        }
        _dial.CurrentPosition += numberOfClicks;
        if (_dial.CurrentPosition == 0 && numberOfClicks != 0) CounterOfCompletedRounds++;

    }

    private int HandleFullDialTurn(int numberOfClicks)
    {
        while (numberOfClicks > _dial.HighestNumber)
        {
            CounterOfCompletedRounds++;
            numberOfClicks -= _dial.HighestNumber + 1;
        }

        return numberOfClicks;
    }

    public int GetCurrentPositionOfDial()
    {
        return _dial.CurrentPosition;
    }
}