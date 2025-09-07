using Day02;
using AdventUtilities;

string currentDay = "Day02";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string[] input = File.ReadAllLines(filePaths["input"]);

Console.WriteLine($"Part 1: {LineChecksum.Part1(input)}");
Console.WriteLine($"Part 2: {LineChecksum.Part2(input)}");
