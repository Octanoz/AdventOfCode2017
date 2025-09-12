namespace Day09;

public class BraceCounter
{
    private Stack<char> braces = [];

    public int Counter(string input)
    {
        int score = 0;
        bool skipOne = false;
        foreach (var letter in input)
        {
            if (skipOne)
            {
                skipOne = false;
                continue;
            }

            if (letter is '!')
            {
                skipOne = true;
                continue;
            }

            if (letter is '{' or '<' && (braces.Count is 0 || braces.Peek() == '{'))
            {
                braces.Push(letter);
            }

            if (letter is '>' && braces.Count > 0 && braces.Peek() == '<')
                braces.Pop();

            if (letter is '}' && braces.Count > 0 && braces.Peek() == '{')
            {
                score += braces.Count;
                braces.Pop();
            }
        }

        return score;
    }

    public int Counter2(string input)
    {
        braces.Clear();
        int totalScore = 0;
        int score = 0;
        bool skipOne = false;
        foreach (var letter in input)
        {
            if (skipOne)
            {
                skipOne = false;
                continue;
            }

            if (letter is '!')
            {
                skipOne = true;
                continue;
            }

            if (letter is '<' && braces.Count is 0)
            {
                braces.Push(letter);
                continue;
            }

            if (letter is not '>' && braces.Count > 0)
                score++;

            if (letter is '>' && braces.Peek() == '<')
            {
                totalScore += score;
                score = 0;
                braces.Pop();
            }
        }

        return totalScore;
    }
}
