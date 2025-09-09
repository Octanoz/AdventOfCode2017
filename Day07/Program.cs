
using Day07;
using AdventUtilities;

string currentDay = "Day07";
Dictionary<string, string> filePaths = new()
{
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};

TowerSystem tower = new();
tower.AssignRoot(filePaths["input"]);
Console.WriteLine($"Part 1: Root is {tower.Root?.Name}");

if (tower.Root is not null)
    Console.WriteLine($"Part 2: Corrected Weight = {tower.FindCorrectWeight(tower.Root)}");