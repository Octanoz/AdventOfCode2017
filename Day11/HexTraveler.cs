namespace Day11;

using AdventUtilities.DOF8;

public static class HexTraveler
{
    public static int Part1(string input)
    {
        Coord current = Coord.Zero;
        string[] directions = input.Split(',');

        foreach (var direction in directions)
        {
            current = Move(current, direction);
        }

        return CalculateResult(current);
    }

    public static int Part2(string input)
    {
        Coord current = Coord.Zero;
        string[] directions = input.Split(',');

        int maxRow = 0, maxCol = 0;
        foreach (var direction in directions)
        {
            current = Move(current, direction);
            maxRow = Math.Max(maxRow, Math.Abs(current.Row));
            maxCol = Math.Max(maxCol, Math.Abs(current.Col));
        }

        return CalculateResult(new(maxRow, maxCol));
    }

    private static Coord Move(Coord current, string direction)
    {
        return direction switch
        {
            "n" => current.Up,
            "ne" => current.UpRight,
            "e" => current.Right,
            "se" => current.DownRight,
            "s" => current.Down,
            "sw" => current.DownLeft,
            "w" => current.Left,
            "nw" => current.UpLeft,
            _ => throw new ArgumentException($"Unknown direction {direction}")
        };
    }

    private static int CalculateResult(Coord current)
    {
        int row = Math.Abs(current.Row);
        int col = Math.Abs(current.Col);

        return row > col ? row : col;
    }
}