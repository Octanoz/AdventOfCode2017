
using Day09;
using AdventUtilities;

string currentDay = "Day09";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string input = File.ReadAllText(filePaths["input"]);
BraceCounter counter = new();
Console.WriteLine($"Part 1: {counter.Counter(input)}");
Console.WriteLine($"Part 2: {counter.Counter2(input)}");