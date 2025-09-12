namespace Day10;

public static class KnotHash
{

    public static int Part1(int[] input)
    {
        int[] numbers = [.. Enumerable.Range(0, 256)];
        int currentStep = 0, skip = 0;
        foreach (var step in input)
        {
            for (int j = 0; j < step / 2; j++)
            {
                int start = (currentStep + j) % 256;
                int end = (currentStep + step + 255 - j) % 256;
                (numbers[start], numbers[end]) = (numbers[end], numbers[start]);
            }

            currentStep = (currentStep + step + skip) % 256;
            skip++;
        }

        return numbers[0] * numbers[1];
    }

    public static string Part2(string input)
    {
        int[] numbers = [.. Enumerable.Range(0, 256)];
        //Take every character's ascii value and add the mandatory values
        int[] steps = [.. input.ToCharArray().Select(c => (int)c), 17, 31, 73, 47, 23];

        int currentStep = 0, skip = 0;
        for (int i = 0; i < 64; i++)
        {
            foreach (var step in steps)
            {
                for (int j = 0; j < step / 2; j++)
                {
                    int start = (currentStep + j) % 256;
                    int end = (currentStep + step + 255 - j) % 256;
                    (numbers[start], numbers[end]) = (numbers[end], numbers[start]);
                }

                currentStep = (currentStep + step + skip) % 256;
                skip++;
            }
        }

        //XOR every group of 16, value by value
        var hash = numbers.Select((v, i) => (value: v, index: i))
                          .GroupBy(x => x.index / 16)
                          .Select(g => g.Aggregate(0x0, (acc, i) => acc ^ i.value));

        byte[] byteXor = hash.Select(x => (byte)x).ToArray(); //int[] to byte[]

        return Convert.ToHexStringLower(byteXor);
    }
}
