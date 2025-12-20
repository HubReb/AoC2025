using System.Text;

namespace ConsoleApp1;

public class BankCombinator
{
    private int _highestNumberFound ;
    private int _firstIndex;
    private int _secondIndex = 1;


    public long GetHighestLine(string input)
    {
        List<int> stack = new List<int>();
        for (var i = 0; i  < 12;  i++)
        {
            stack.Add(int.Parse(input[i].ToString()));
        }
        string currentNumberAsString = input[..12];
        long currentNumber = long.Parse(currentNumberAsString);
        for ( int i = 12; i < input.Length; i++)
        {
            currentNumberAsString = CreateHighestNumber(input, i, stack, currentNumberAsString, ref currentNumber);
        }
        return currentNumber;
    }

    private static string CreateHighestNumber(string input, int index, List<int> stack, string currentNumberAsString,
        ref long currentNumber)
    {
        int.TryParse(input[index].ToString(), out var number);
        for (var j = 0; j < stack.Count; ++j)
        {
            var newNumberAsString = $"{currentNumberAsString[..j]}{currentNumberAsString[(j + 1)..]}{number}";
            var newNumber = long.Parse(newNumberAsString);
            if (currentNumber >=  newNumber) continue;
            stack.RemoveAt(j);
            stack.Add(number);
            currentNumberAsString = newNumberAsString;
            currentNumber = newNumber;
            break;
        }

        return currentNumberAsString;
    }

    public int GetHighestCombination(string input)
    {

        if (!int.TryParse(input[..2], out _highestNumberFound)) return -1;
        for (var i = 2; i < input.Length; i++)
        {
            if (!int.TryParse(input[_firstIndex] + input[i].ToString(), out var number)) continue;
            if (!int.TryParse(input[_secondIndex] + input[i].ToString(), out var secondNumber)) continue;
            if (number > secondNumber)
            {
                HandleCombination(number, i);
                continue;
            }

            HandleSecondCombination( secondNumber, i);
        }

        return _highestNumberFound;
    }

    private void HandleSecondCombination(int number, int i)
    {
        if (number <= _highestNumberFound) return;
        _highestNumberFound = number;
        _firstIndex = _secondIndex;
        _secondIndex = i;
    }

    private void HandleCombination( int number, int i)
    {
        if (number <= _highestNumberFound) return;
        _highestNumberFound = number;
        _secondIndex = i;
    }
    
    public void Reset()
    {
        _firstIndex = 0;
        _secondIndex = 1;
        _highestNumberFound = -1;
    }
}