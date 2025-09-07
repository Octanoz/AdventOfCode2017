namespace Day03;

using AdventUtilities.DOF8;

public class CumulativeGridGenerator
{
    private readonly Dictionary<Coord, int> grid = new()
    {
        [Coord.Zero] = 1,
        [new(0, 1)] = 1
    };

    public int Part2(int target)
    {
        AddLayers(new(0, 1), target);

        return grid.First(c => c.Value >= target).Value;
    }

    private void AddLayers(Coord current, int target)
    {
        Direction dir = new();
        while (true)
        {
            //Keep expanding in the current direction while inner layer is found
            while (dir is Direction.Up && grid.ContainsKey(current.Left)
            || dir is Direction.Left && grid.ContainsKey(current.Down)
            || dir is Direction.Down && grid.ContainsKey(current.Right)
            || dir is Direction.Right && grid.ContainsKey(current.Up))
            {
                current = dir switch
                {
                    Direction.Up => current.Up,
                    Direction.Left => current.Left,
                    Direction.Right => current.Right,
                    _ => current.Down
                };

                int cellValue = CellUpdate(current);
                grid[current] = cellValue;

                if (cellValue >= target)
                    return;
            }

            dir = (Direction)(((int)dir + 1) % 4);
        }
    }

    private int CellUpdate(Coord current)
    {
        int result = 0;
        foreach (var nb in current.Neighbours)
        {
            result += grid.TryGetValue(nb, out var storedValue) ? storedValue : 0;
        }

        return result;
    }

    public void Reset()
    {
        grid.Clear();
        grid[Coord.Zero] = 1;
        grid[new(0, 1)] = 1;
    }
}
