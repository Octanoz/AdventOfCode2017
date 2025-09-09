
using Day08;
using AdventUtilities;

string currentDay = "day08";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

Registers regs = new();
regs.ParseRegisters(filePaths["input"]);

Console.WriteLine($"Part 1: {regs.MaxValue()}");
Console.WriteLine($"Part 2: {regs.MaxValueHeld()}");