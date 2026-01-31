namespace Sudoku;

public class Validation
{
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;

    private static bool BoardValid(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        if (board == null || board.Length != SizeBoard)
        {
            errorMsg = "Board size need to include 9 rows!";
            return false;
        }

        for (int row = 0; row < SizeBoard; row++ )
        {
            if (board[row] == null || board[row].Length != SizeBoard)
            {
                errorMsg = "Board size need to include 9 columns!";
                return false;
            }
        }
        return true;
    }

    private static bool ValueValid(int[][] board, int row, int col, out int value, out int bit, out string errorMsg)
    {
        errorMsg = "";
        bit = 0;
        value = board[row][col];
        
        //check if the value of digit is between 1 to 9
        if (value < 0 || value > 9)
        {
            errorMsg = "The value must be between 1 to 9!";
            return false;
        }

        if (value == 0)
        {
            return true;
        }

        bit = 1 << value;
        return true;
    }

    private static bool AddValid(int[] maskRow, int[] maskCol, int[] maskBlock, int row, int col,
        int block, int value, int bit, out string errorMsg)
    {
        errorMsg = "";
        
        //check if the digit appear in the row
        if (SetBit(maskRow[row], bit))
        {
            errorMsg = $"There is a duplicate value in {row+1}";
            return false;
        }
        
        //check if the digit appear in the col
        if (SetBit(maskCol[col], bit))
        {
            errorMsg = $"There is a duplicate value in {col+1}";
            return false;
        }
        
        //check if the digit appear in the block
        if (SetBit(maskBlock[block], bit))
        {
            errorMsg = $"There is a duplicate value in {block+1}";
            return false;
        }
        // after the checks mark the digit as used
        maskRow[row] |= bit;
        maskCol[col] |= bit;
        maskBlock[block] |= bit;
        return true;
    }

    private static bool SetBit(int mask, int bit)
    {
        return (mask & bit) != 0;
    }

    private static int GetBlockIndex(int row, int col)
    {
        return (row / SizeBlock) * SizeBlock + (col / SizeBlock);
    }
}