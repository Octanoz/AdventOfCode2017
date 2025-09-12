using Day11;
using AdventUtilities;

string currentDay = "Day11";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string input = File.ReadAllText(filePaths["input"]);

Console.WriteLine($"Part 1: {HexTraveler.Part1(input)}");
Console.WriteLine($"Part 2: {HexTraveler.Part2(input)}");