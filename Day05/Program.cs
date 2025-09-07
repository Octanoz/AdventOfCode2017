
using Day05;
using AdventUtilities;

string currentDay = "Day05";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

string[] input = File.ReadAllLines(filePaths["input"]);

Jumper jumper = new(input);
Console.WriteLine($"Part 1: {jumper.Part1()}");

Jumper jumper2 = new(input);
Console.WriteLine($"Part 1: {jumper2.Part2()}");