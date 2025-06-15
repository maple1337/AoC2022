namespace Day06;

public static class Program
{
    private const string InputFile = "..//..//..//input.txt";
    public static void Main()
    {
        Console.WriteLine("Result Part1: " + Part1());
        Console.ReadLine();
        Console.WriteLine("Result Part2: " + Part2());
        Console.ReadLine();
    }

    public static int Part1()
    {
        DataProcessorPart1 dataProcessor = new DataProcessorPart1(InputFile);
        return dataProcessor.SolvePuzzle();       
    }
    
    public static int Part2()
    {
        DataProcessorPart2 dataProcessor = new DataProcessorPart2(InputFile);
        return dataProcessor.SolvePuzzle();       
    }
    
    
}

