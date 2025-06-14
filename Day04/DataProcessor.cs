using Common;

namespace Day04;

public abstract class ADataProcessor
{
    protected DataArray Data { get; init; }

    protected ADataProcessor(string filepath)
    {
        this.Data = new DataArray(FileLoader.LoadFileAsArray(filepath, x => x));
    }
    
    protected bool AreUnique(char[] toCheck)
    {
        HashSet<char> set = new HashSet<char>(toCheck);
        return (set.Count == toCheck.Length);
    }

    public abstract int SolvePuzzle();
}

public class DataProcessorPart1(string filepath) : ADataProcessor(filepath)
{
    public override int SolvePuzzle()
    {
        for (int i = 0; i < Data.Char.Length - 4; i++)
        {
            if (base.AreUnique(Data.Char[i..(i + 4)]))
            {
                return i + 4;
            }
        }
        return 0;
    }
}   

public class DataProcessorPart2(string filepath) : ADataProcessor(filepath)
{
    public override int SolvePuzzle()
    {
        for (int i = 0; i < Data.Char.Length - 14; i++)
        {
            if (base.AreUnique(Data.Char[i..(i + 14)]))
            {
                return i + 14;
            }
        }
        return 0;
    }
}   

public record struct DataArray(char[] Data)
{
    public char[] Char { get; init; } = Data;
}