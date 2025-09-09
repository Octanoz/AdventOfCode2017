namespace Day07;

using System.Text.RegularExpressions;

public class TowerSystem
{
    private readonly Dictionary<string, Node> nodes = [];
    public Node? Root { get; set; }

    public void AssignRoot(string filePath)
    {
        ParseNodes(filePath);
        LinkChildren();
        Root = nodes.Select(kvp => kvp.Value)
                    .Where(n => n.ChildrenNames.Length > 0)
                    .First(n => !nodes.Values.SelectMany(other => other.Children).Any(child => child.Name == n.Name));
    }

    private void ParseNodes(string filePath)
    {
        using StreamReader sr = new(filePath);
        while (!sr.EndOfStream)
        {
            string currentLine = sr.ReadLine()!;
            string[] values = [..Helpers.Names()
                                        .Matches(currentLine)
                                        .Select(m => m.Value)
                                        .Where(s => !String.IsNullOrEmpty(s))];

            int number = int.Parse(values[1]);

            Node currentNode = new(values[0], number)
            {
                ChildrenNames = values[2..]
            };

            nodes.Add(values[0], currentNode);
        }
    }

    private void LinkChildren()
    {
        foreach (var node in nodes.Values)
        {
            node.Children = node.ChildrenNames.Select(name => nodes[name]).ToList();
        }
    }

    public int FindCorrectWeight(Node node)
    {
        var childWeights = node.Children.Select(c => new { Node = c, Total = c.TotalWeight })
                                        .GroupBy(x => x.Total)
                                        .ToList();

        if (childWeights.Count is 1)
            return -1;

        var correctGroup = childWeights.First(g => g.Count() > 1);
        var incorrectGroup = childWeights.First(g => g.Count() == 1); //The odd one out is likely wrong

        var incorrectNode = incorrectGroup.First().Node;
        int weightDiff = correctGroup.Key - incorrectGroup.Key; //Difference between correct total and incorrect group total

        int deeperFix = FindCorrectWeight(incorrectNode);
        return deeperFix == -1
                          ? incorrectNode.Weight + weightDiff // Weight to correct incorrect weight to match correct weights
                          : deeperFix;
    }
}

static partial class Helpers
{
    [GeneratedRegex(@"\w*")]
    public static partial Regex Names();
}
