namespace Sudoku;

public class Solver
{
    private int[] maskRow = new int[Helper.SizeBoard];
    private int[] maskCol = new int[Helper.SizeBoard];
    private int[] maskBlock =  new int[Helper.SizeBoard];
    
    /// <summary>
    /// This function turn the board to mask for fast scan
    /// </summary>
    /// <param name="board"></param>
    private void CreateMask(int[][] board)
    {
        //reset each mask before start new board 
        Array.Clear(maskRow, 0, maskRow.Length);
        Array.Clear(maskCol, 0, maskCol.Length);
        Array.Clear(maskBlock, 0, maskBlock.Length);
        
        //these loops pass on each cell
        for (int row = 0; row < maskRow.Length; row++)
        {
            for (int col = 0; col < maskCol.Length; col++)
            {
                //save the value in the present cell
                int value = board[row][col];
                if (value == 0)
                    continue;
                
                int bit = Helper.NumberToBit(value);
                int indexBlock = Helper.GetBlockIndex(row, col);
                //sign the number by turn on the bits in the masks
                maskRow[row] |= bit;
                maskCol[col] |= bit;
                maskBlock[indexBlock] |= bit;
            }
        }
    }
    /// <summary>
    /// This function return bit mask of number that can to place
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private int OptionalMask(int row, int col)
    {
        int indexBlock = Helper.GetBlockIndex(row, col);
        // create mask of numbers that you cant to place in the specific cell
        int useMask = maskRow[row] | maskCol[col] | maskBlock[indexBlock];
        return Helper.CompleteMask & ~useMask;
    }
    /// <summary>
    /// find the empty cell with the minimal options to place 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="FindRow"></param>
    /// <param name="FindCol"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    private bool FindCell(int[][] board, out int FindRow, out int FindCol,  out int mask)
    {
        FindRow = -1;
        FindCol = -1;
        mask = 0;
        int count = 10;
        //these loops pass on each cell in the board
        for (int row = 0; row < Helper.SizeBoard; row++)
        {
            for (int col = 0; col < Helper.SizeBoard; col++)
            {
                //if there is a value in cell continue to the next iteration
                if (board[row][col] != 0)
                {
                    continue; 
                }
                int optionalMask = OptionalMask(row, col);
                int countOnBits = Helper.CountOnBits(mask);
                //check if the amount of the on bits is smaller than the max on bits
                if (countOnBits < count)
                {
                    count =  countOnBits;
                    FindRow = row;
                    FindCol = col;
                    mask = optionalMask;
                }
                
                if (count == 1)
                    return true;
            } 
        }
        return FindRow != -1;
    }

    private void allocateValue(int[][] board, int row, int col, int number, int bit)
    {
        
    }
}


