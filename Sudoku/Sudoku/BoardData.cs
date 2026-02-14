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
    /// <summary>
    /// return the mask that presting all the valid digits in the board
    /// </summary>
    public int CompleteMask { get; }
    
    /// <summary>
    /// Constructor thar initialize each attribute
    /// </summary>
    /// <param name="board"></param>
    public BoardData(int[][] board)
    {
        
    }
    
    
}