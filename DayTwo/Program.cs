// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine("Hello, World!");
using var fileStream = File.OpenRead("../../../DayTwoInput.txt");
using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 512);
while (streamReader.ReadLine() is { } line)
{
    var invalidIds = new List<long>();
    var ids = line.Split(',');
    foreach (var id in ids)
    {
        if (!id.Contains('-'))    // valid id
        {
            continue;
        }
        var range = id.Split('-');
        var start = long.Parse(range[0]);
        var end = long.Parse(range[1]);
        for (var i = start; i <= end; i++)
        {
            if (!ValidateIdPartTwo(i))
            {
                invalidIds.Add(i);
            }
        }
    }
    Console.WriteLine(invalidIds.Sum());
    
    
}
bool ValidateId(long id)
{
    string idAsString = id.ToString();
    if (idAsString.Length % 2 != 0)
    {
        return true;
    }
    int middle = idAsString.Length / 2;
    string firstHalf = idAsString[0..middle];
    string secondHalf = idAsString[^middle..];
    return !(firstHalf.Equals(secondHalf));
}

bool ValidateIdPartTwo(long id)
{
    var sequence = id.ToString();
    for (var patternEnd = 0; patternEnd < sequence.Length; patternEnd++)
    {
        // check if the remainder can obviously not be just a repetition
        if (sequence.Length % (patternEnd + 1) != 0)
        {
            continue;
        }
        var expectedMatch = sequence[0..(patternEnd+1)];

        if (IsSequenceRepeated(expectedMatch, sequence)) return false;
    }
    return true;
}

bool IsSequenceRepeated(string expectedMatch, string sequence)
{
    var length = expectedMatch.Length;
    // at least the length of two patterns
    if (length * 2 > sequence.Length)
    {
        return false;
    }
        
    for (var patternStart = length; (patternStart + length) <= sequence.Length; patternStart += length)
    {
        var nextSequence = sequence[patternStart..(patternStart + length)];
        if (!nextSequence.Equals(expectedMatch))
        {
            return false;
        }
    }

    return true;
}