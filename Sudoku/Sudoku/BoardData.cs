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
        SizeBoard = board.Length;
        SizeBlock = (int)Math.Sqrt(SizeBoard);
        NumOfCells = SizeBlock * SizeBlock;
        CompleteMask = (1 << (SizeBoard + 1)) - 2;
    }

    /// <summary>
    /// Constructor function that before the board is built
    /// </summary>
    /// <param name="sizeBoard"></param>
    public BoardData(int sizeBoard)
    {
        SizeBoard = sizeBoard;
        SizeBlock = (int)Math.Sqrt(SizeBoard);
        NumOfCells = SizeBlock * SizeBlock;
        CompleteMask = (1 << (SizeBoard + 1)) - 2;
    }
}