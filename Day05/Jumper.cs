namespace Day05;

public class Jumper(string[] input)
{
    private readonly int[] jumps = Array.ConvertAll(input, int.Parse);

    public int Part1()
    {
        int index = 0, steps = 0;
        while (index < jumps.Length)
        {
            int jump = jumps[index];
            jumps[index]++;
            index += jump;

            steps++;
        }

        return steps;
    }

    public int Part2()
    {
        int index = 0, steps = 0;
        while (index < jumps.Length)
        {
            int jump = jumps[index];
            jumps[index] += jumps[index] >= 3 ? -1 : 1;
            index += jump;

            steps++;
        }

        return steps;
    }
}
