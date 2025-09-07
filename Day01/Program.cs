using Day01;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "Day01/input.txt")
};

string input = File.ReadAllText(filePaths["input"]);

CaptchaSequence sequence = new(input);

Console.WriteLine($"Part 1: {sequence.Part1()}");
Console.WriteLine($"Part 2: {sequence.Part2()}");
