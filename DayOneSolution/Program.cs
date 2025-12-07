// See https://aka.ms/new-console-template for more information

using System.Text;
using DayOneSolution;

Console.WriteLine("Hello, World!");
var rotator = new Rotator(50, 99, 0);
using var fileStream = File.OpenRead("../../../DayOneInputOne.txt");
using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 512);
while (streamReader.ReadLine() is { } line)
{
    var direction = line[0];
    var increase = char.ToUpper(direction).Equals('R');
    var numberOfClicks = int.Parse(line.Substring(1));
    rotator.Rotate(increase, numberOfClicks);
}

Console.WriteLine(rotator.CounterOfCompletedRounds);