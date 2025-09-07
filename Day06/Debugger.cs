namespace Day06;

public class Debugger(string input)
{
    private int[] banks = Array.ConvertAll(input.Split('\t'), int.Parse);
    private readonly HashSet<string> banksFound = [];

    public int Part1()
    {
        int cycles = 0;
        banksFound.Add(String.Join(" ", banks));

        while (true)
        {
            cycles++;
            RedistributeBlocks();

            if (!banksFound.Add(String.Join(" ", banks)))
                return cycles;
        }
    }

    private void RedistributeBlocks()
    {
        int mostBlocks = banks.Max();
        int index = Array.IndexOf(banks, mostBlocks);
        banks[index] = 0;

        while (mostBlocks > 0)
        {
            index = (index + 1) % 16;
            banks[index]++;
            mostBlocks--;
        }
    }

    public int Part2()
    {
        int cycles = 0;
        string target = String.Join(" ", banks);

        while (true)
        {
            cycles++;
            RedistributeBlocks();

            if (String.Join(" ", banks) == target)
                return cycles;
        }
    }
}
