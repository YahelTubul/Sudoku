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

    private bool FindCell(int[][] board, out int row, out int col, out int mask)
    {
        return true;
    }
}