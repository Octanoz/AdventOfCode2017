namespace Day07;

public record Node(string Name, int Weight)
{
    public string[] ChildrenNames { get; set; } = [];
    public List<Node> Children { get; set; }

    public int TotalWeight => Weight + Children.Sum(c => c.TotalWeight);
}
