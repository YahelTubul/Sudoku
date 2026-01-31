namespace Sudoku;

public class Validation
{   
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;
    
    /// <summary>
    /// check if the board is valid after all the checks that happen in the other fucntions
    /// </summary>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false</returns>
    public static bool Validate(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        
        // call to function boardValid and return false if it's not valid
        if (!BoardValid(board, out errorMsg))
        {
            return false;
        }
        
        int[] rowMask = new int[SizeBoard];
        int[] colMask = new int[SizeBoard];
        int[] blockMask = new int[SizeBoard];

        for (int row = 0; row < SizeBoard; row++)
        {
            for (int col = 0; col < SizeBoard; col++)
            {
                // call to function valueValid to check each cell value in the board
                if (!ValueValid(board, row, col, out int value, out int bit, out errorMsg))
                    return false;
                
                if (value == 0)
                    continue;
                
                int block = GetBlockIndex(row, col);
                
                // call to addValid function to check if there is not duplicate in the board
                if (!AddValid(rowMask, colMask, blockMask, row, col, block, value, bit, out errorMsg))
                    return false;
            }
        }
        return true;
    }
    /// <summary>
    /// check the limits of the board and valid that there is 9 cols and rows
    /// </summary>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false</returns>
    private static bool BoardValid(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        // loop on each col in the board to validate that there is 9 cols
        if (board == null || board.Length != SizeBoard)
        {
            errorMsg = "Board size need to include 9 rows!";
            return false;
        }
        // loop on each row in the board to validate that there is 9 rows
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
    /// <summary>
    /// check the value in each cell in the board 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="value"></param>
    /// <param name="bit"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false, bit</returns>
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
    /// <summary>
    /// check if there is not duplicate of the digit in row,col and block in the board, if not mark the digit as used
    /// </summary>
    /// <param name="maskRow"></param>
    /// <param name="maskCol"></param>
    /// <param name="maskBlock"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="block"></param>
    /// <param name="value"></param>
    /// <param name="bit"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false</returns>
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
    /// <summary>
    /// check if the bit is on using binary operator
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="bit"></param>
    /// <returns>true/false</returns>
    private static bool SetBit(int mask, int bit)
    {
        return (mask & bit) != 0;
    }
    /// <summary>
    /// calculate the index of the present block
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>index of the present block</returns>
    private static int GetBlockIndex(int row, int col)
    {
        return (row / SizeBlock) * SizeBlock + (col / SizeBlock);
    }
}