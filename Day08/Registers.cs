namespace Day08;

public class Registers
{
    private readonly Dictionary<string, int> registers = [];
    int maxValueHeld = 0;

    public void ParseRegisters(string filePath)
    {
        using StreamReader sr = new(filePath);
        while (!sr.EndOfStream)
        {
            string currentLine = sr.ReadLine()!;
            var parts = currentLine.Split();

            string firstRegister = parts[0];
            registers[firstRegister] = registers.TryGetValue(firstRegister, out var storedValue) ? storedValue : 0;
            string secondRegister = parts[^3];
            registers[secondRegister] = registers.TryGetValue(secondRegister, out storedValue) ? storedValue : 0;

            int conditionValue = int.Parse(parts[^1]);
            string conditionOperator = parts[^2];

            switch (conditionOperator)
            {
                case ">" when registers[secondRegister] > conditionValue:
                case "<" when registers[secondRegister] < conditionValue:
                case ">=" when registers[secondRegister] >= conditionValue:
                case "<=" when registers[secondRegister] <= conditionValue:
                case "==" when registers[secondRegister] == conditionValue:
                case "!=" when registers[secondRegister] != conditionValue:
                    if (parts[1] is "dec")
                        registers[firstRegister] -= int.Parse(parts[2]);
                    else
                        registers[firstRegister] += int.Parse(parts[2]);
                    maxValueHeld = int.Max(maxValueHeld, registers[firstRegister]);
                    break;
                default:
                    break;
            }
        }
    }

    public int MaxValue() => registers.Values.Max();
    public int MaxValueHeld() => maxValueHeld;
}
