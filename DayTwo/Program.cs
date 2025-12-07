// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.ComponentModel.DataAnnotations;
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
            if (!(ValidateId(i)))
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
