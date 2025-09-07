namespace Day03;

using AdventUtilities;

public class GridGenerator
{
    private readonly Dictionary<Coord, int> grid = new()
    {
        [Coord.Zero] = 1,
        [new(0, 1)] = 2
    };

    public int Part1(int target)
    {
        AddLayers(new(0, 1), target);

        return grid.First(c => c.Value == target).Key.Manhattan(Coord.Zero);
    }

    private void AddLayers(Coord current, int target)
    {
        int currentValue = grid[current];
        Direction dir = new();

        while (currentValue < target)
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

                grid[current] = ++currentValue;
            }

            dir = (Direction)(((int)dir + 1) % 4);
        }
    }

    public void Reset()
    {
        grid.Clear();
        grid[Coord.Zero] = 1;
        grid[new(0, 1)] = 2;
    }
}
