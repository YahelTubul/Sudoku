namespace Sudoku;

public class Helper
{
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;
    public const int CompleteMask = 0b1111111110;
    
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
    /// <summary>
    /// Convert number to bit series 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int NumberToBit(int number)
    {
        return 1 << number;
    }
    /// <summary>
    /// Count how much on bits there are in the mask
    /// </summary>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static int CountOnBits(int mask)
    {
        int count = 0;
        while (mask != 0)
        {
            mask &= (mask - 1);
            count++;
        }
        return count;
    }
    
    /// <summary>
    /// return the first set bit, this is the first option for check in the backtracking 
    /// </summary>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static int GetFirstSetBit(int mask)
    {
        return mask & -mask;
    }

    public static void PrintBoard(int[][] board)
    {
        
    }
}