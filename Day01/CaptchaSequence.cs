namespace Day01;

public class CaptchaSequence(string input)
{
    private readonly int[] numbers = [.. input.ToCharArray().Select(n => n - '0')];

    public int Part1()
    {
        int result = numbers[0] == numbers[^1] ? numbers[0] : 0;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
                result += numbers[i];
        }

        return result;
    }

    public int Part2()
    {
        int mid = numbers.Length / 2;
        int result = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[(mid + i) % numbers.Length])
                result += numbers[i];
        }

        return result;
    }
}
