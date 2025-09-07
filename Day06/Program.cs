
using Day06;
using AdventUtilities;

string currentDay = "Day06";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string input = File.ReadAllText(filePaths["input"]);

Debugger debugger = new(input);
Console.WriteLine($"Part 1: {debugger.Part1()}");
Console.WriteLine($"Part 2: {debugger.Part2()}");
