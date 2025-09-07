using Day03;

int target = 312051;

GridGenerator generator = new();
Console.WriteLine($"Part 1: {generator.Part1(target)}");

CumulativeGridGenerator cumGenerator = new();
Console.WriteLine($"Part 2: {cumGenerator.Part2(target)}");
