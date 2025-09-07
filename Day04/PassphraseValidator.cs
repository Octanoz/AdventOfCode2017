namespace Day04;

public static class PassphraseValidator
{
    public static int Part1(ReadOnlySpan<string> input)
    {
        int result = 0;
        foreach (var line in input)
        {
            if (AllUnique(line))
                result++;
        }

        return result;
    }

    private static bool AllUnique(string line)
    {
        var words = line.Split();
        HashSet<string> wordsSet = [.. words];

        return wordsSet.Count == words.Length;
    }

    public static int Part2(ReadOnlySpan<string> input)
    {
        int result = 0;
        foreach (var line in input)
        {
            if (AllUniqueSorted(line))
                result++;
        }

        return result;
    }

    private static bool AllUniqueSorted(string line)
    {
        var sortedLetters = line.Split()
                                .Select(s => s.ToCharArray().Order())
                                .Select(arr => new string([.. arr]))
                                .ToArray();

        HashSet<string> sortedLettersSet = [.. sortedLetters];

        return sortedLettersSet.Count == sortedLetters.Length;
    }
}
