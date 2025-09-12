
using Day10;
using AdventUtilities;

string currentDay = "Day10";
Dictionary<string, string> filePaths = new()
{
    ["example1"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/example1.txt"),
    ["example2"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/example2.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), $"{currentDay}/input.txt")
};
string input = File.ReadAllText(filePaths["input"]);
int[] inputArray = Array.ConvertAll(input.Split(','), int.Parse);

Console.WriteLine($"Part 1: {KnotHash.Part1(inputArray)}");
Console.WriteLine($"Part 2: {KnotHash.Part2(input)}");