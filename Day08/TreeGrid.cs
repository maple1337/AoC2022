namespace Day08;

public sealed class TreeGrid
{
    private readonly Tree[,] _grid;

    public TreeGrid(List<string> input)
    {
        var gridWidth = input[0].Length;
        var gridHeight = input.Count;
        int ctr = 0;
        
        _grid = new Tree[gridWidth, gridHeight];

        for (int i = 0; i < gridHeight; i++)
        {
            int[] treeSizes = input[i]
                .Select(c => (int)char.GetNumericValue(c))
                .ToArray();
            
            foreach (var treeSize in treeSizes)
            {
                int xIndex = i;
                int yIndex = ctr;
                _grid[xIndex, yIndex] = new Tree(treeSize, xIndex, yIndex);
                ctr++;
            }
            ctr = 0;
        }
    }

    private class Tree
    {
        internal readonly int Row;
        internal readonly int Column;
        internal readonly int Height;
        internal bool IsVisible;
        internal int ScenicScore;

        public Tree(int height,  int row, int column)
        {
            Row = row;
            Column = column;
            Height = height;
            IsVisible = false;
            ScenicScore = 0;
        }
    }

    public void UpdateVisibility()
    {
        int rows = _grid.GetLength(0);
        int cols = _grid.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Tree current = _grid[r, c];
                if (IsVisibleFromBottom(current) ||
                    IsVisibleFromTop(current) ||
                    IsVisibleFromLeft(current) ||
                    IsVisibleFromRight(current))
                {
                    current.IsVisible = true;
                }
            }       
        }
    }

    private bool IsVisibleFromLeft(Tree current)
    {

        int currentSize = current.Height;
        for (int i = 0; i < current.Column; i++)
        {
            if (_grid[current.Row, i].Height >= currentSize)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsVisibleFromRight(Tree current)
    {
        int cols = _grid.GetLength(1);
        int currentSize = current.Height;
        
        for (int i = current.Column + 1; i < cols; i++)
        {
            if (_grid[current.Row, i].Height >= currentSize)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsVisibleFromBottom(Tree current)
    {
        int rows = _grid.GetLength(0);
        int currentSize = current.Height;
        
        for (int i = current.Row + 1; i < rows; i++)
        {
            if (_grid[i, current.Column].Height >= currentSize)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsVisibleFromTop(Tree current)
    {
        int currentSize = current.Height;
        
        for (int i = 0; i < current.Row; i++)
        {
            if (_grid[i, current.Column].Height >= currentSize)
            {
                return false;
            }
        }
        return true;
    }
    
    public int GetAmountOfVisibleTrees()
    {
        int count = 0;
        
        foreach (Tree tree in _grid)
        {
            if (tree.IsVisible == true)
                count++;
        }
        return count;
    }

    private void SetScenicScore()
    {
        foreach (Tree current in _grid)
        {
            int scenicScore =
                CalculateScenicScoreTop(current) *
                CalculateScenicScoreLeft(current) *
                CalculateScenicScoreBottom(current) *
                CalculateScenicScoreRight(current);
            
            current.ScenicScore = scenicScore;
        }
    }

    private int CalculateScenicScoreLeft(Tree current)
    {
        int column =  current.Column;
        int row = current.Row;
        int counter = 0;

        if (column == 0)
            return 0;
        
        for (int c = column - 1; c >= 0; c--)
        {
            if (_grid[row, c].Height < current.Height)
            {
                counter++;
            }
            else
            {
                counter++;
                break;
            }
        }
        return counter;
    }
    
    private int CalculateScenicScoreRight(Tree current)
    {
        int column =  current.Column;
        int row = current.Row;
        int gridWidth = _grid.GetLength(1);
        
        int counter = 0;

        if (column == gridWidth - 1)
            return 0;
        
        for (int c = column + 1; c < gridWidth ; c++)
        {
            if (_grid[row, c].Height < current.Height)
            {
                counter++;
            }
            else
            {
                counter++;
                break;
            }
        }
        return counter;
    }
    
    private int CalculateScenicScoreTop(Tree current)
    {
        int column =  current.Column;
        int row = current.Row;
        
        int counter = 0;

        if (row == 0)
            return 0;
        
        for (int r = row - 1; r >= 0 ; r--)
        {
            if (_grid[r, column].Height < current.Height)
            {
                counter++;
            }
            else
            {
                counter++;
                break;
            }
        }
        return counter;
    }
    
    private int CalculateScenicScoreBottom(Tree current)
    {
        int column =  current.Column;
        int row = current.Row;
        int gridHeight = _grid.GetLength(0);
        int counter = 0;

        if (row == gridHeight - 1)
            return 0;
        
        for (int r = row + 1; r < gridHeight ; r++)
        {
            if (_grid[r, column].Height < current.Height)
            {
                counter++;
            }
            else
            {
                counter++;
                break;
            }
        }
        return counter;
    }

    public int GetBestScenicScore()
    {
        Tree highest = _grid[0, 0];
        
        SetScenicScore();

        foreach (Tree tree in _grid)
        {
            if (tree.ScenicScore > highest.ScenicScore)
            {
                highest = tree;
            }
        }
        return highest.ScenicScore;
    }
}