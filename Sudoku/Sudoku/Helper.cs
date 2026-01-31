namespace Sudoku;

public class Helper
{
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;
    
    /// <summary>
    /// check if the bit is on using binary operator
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="bit"></param>
    /// <returns>true/false</returns>
    public static bool SetBit(int mask, int bit)
    {
        return (mask & bit) != 0;
    }
    /// <summary>
    /// calculate the index of the present block
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>index of the present block</returns>
    public static int GetBlockIndex(int row, int col)
    {
        return (row / SizeBlock) * SizeBlock + (col / SizeBlock);
    }
}