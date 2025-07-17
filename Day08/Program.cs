using Common;

namespace Day08;

public static class Program
{
    private static string inputPath = "..//..//..//input.txt";
    public static void Main()
    {
        var input = FileLoader.LoadFile(inputPath, x => x);
        TreeGrid treeGrid = new TreeGrid(input);
        Console.WriteLine($"Part 1: {Part1(treeGrid)}");
        Console.WriteLine($"Part 2: {Part2(treeGrid)}");
    }

    private static int Part1(TreeGrid treeGrid)
    {
        treeGrid.UpdateVisibility();
        return treeGrid.GetAmountOfVisibleTrees();
    }

    private static int Part2(TreeGrid treeGrid)
    {
        return treeGrid.GetBestScenicScore();
    }
}