// using Day04;
using AdventUtilities;
using Day04;

string currentDay = "Day04";

Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string[] input = File.ReadAllLines(filePaths["input"]);

Console.WriteLine($"Part 1: {PassphraseValidator.Part1(input)}");
Console.WriteLine($"Part 2: {PassphraseValidator.Part2(input)}");

