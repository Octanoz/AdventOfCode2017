namespace Day02;

public static class LineChecksum
{
    public static int Part1(string[] input)
    {
        int result = 0;
        foreach (var line in input)
        {
            var currentLine = line.Split('\t', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            result += currentLine.Max() - currentLine.Min();
        }

        return result;
    }

    public static int Part2(string[] input)
    {
        int result = 0;
        foreach (var line in input)
        {
            var currentLine = line.Split('\t', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            result += Divisible(currentLine);
        }

        return result;
    }

    private static int Divisible(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 2; i++)
        {
            int j = i + 1;
            while (j < numbers.Length)
            {
                int first = numbers[i], second = numbers[j];
                if (second > first)
                {
                    (first, second) = (second, first);
                }

                if (first % second == 0)
                {
                    return first / second;
                }

                j++;
            }
        }

        return -1;
    }
}
