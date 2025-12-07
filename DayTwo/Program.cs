// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;

Console.WriteLine("Hello, World!");
using var fileStream = File.OpenRead("../../../DayTwoInput.txt");
using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 512);
while (streamReader.ReadLine() is { } line)
{
    var invalidIds = new ArrayList();
    var ids = line.Split(',');
    foreach (var id in ids)
    {
        if (!(id.Contains('-')))    // valid id
        {
            continue;
        }
        var range = id.Split('-');
        var start = long.Parse(range[0]);
        var end = long.Parse(range[1]);
        for (var i = start; i <= end; ++i)
        {
            if (!(ValidateIdPartTwo(i)))
            {
                invalidIds.Add(i);
            }
        }
    }
    Console.WriteLine(invalidIds.Cast<long>().Sum());
    
    
}
bool ValidateId(long id)
{
    string idAsString = id.ToString();
    if (idAsString.Length % 2 != 0)
    {
        return true;
    }
    int middle = idAsString.Length / 2;
    string firstHalf = idAsString.Substring(0, middle);
    string secondHalf = idAsString[^middle..];
    return !(firstHalf.Equals(secondHalf));
}

bool ValidateIdPartTwo(long id)
{
    var compoundedSequence = new ArrayList();
    var sequence = id.ToString();
    foreach (var t in sequence)
    {
        compoundedSequence.Add(t);
        if (sequence.Length % compoundedSequence.Count != 0)
        {
            continue;
        }
        var length = compoundedSequence.Count;
        if (IsSequenceRepeated(length)) return false;
    }
    return true;

    bool IsSequenceRepeated(int length)
    {
        if (sequence.Length == 2)
        {
            return sequence[0].Equals(sequence[1]);
        }

        if (compoundedSequence.Count + length > sequence.Length)
        {
            return false;
        }

        var compoundedSequenceBuilder = new StringBuilder(compoundedSequence.Count);
        foreach (var t in compoundedSequence) {
            compoundedSequenceBuilder.Append(t);
        }
        var compareSequence = compoundedSequenceBuilder.ToString();
        var skipLength = compoundedSequence.Count;
        for (var j = length; (j + length) <= sequence.Length; j += skipLength)
        {
            var nextSequence = sequence[j..(j + length)];
            if (!(nextSequence.Equals(compareSequence)))
            {
                return false;
            }
        }

        return true;
    }
}