namespace Sudoku;

public class BoardData
{
    /// <summary>
    /// size of the board 
    /// </summary>
    public int SizeBoard { get; }
    /// <summary>
    /// size of the block in board 
    /// </summary>
    public int SizeBlock { get; }
    /// <summary>
    /// The num of cells in the board 
    /// </summary>
    public int NumOfCells { get; }
    
    public int CompleteMask { get; }
    
    
}