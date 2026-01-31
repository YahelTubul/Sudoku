namespace Sudoku;

public class Solver
{
    private int[] maskRow = new int[Helper.SizeBoard];
    private int[] maskCol = new int[Helper.SizeBoard];
    private int[] maskBlock =  new int[Helper.SizeBoard];

    private bool CreateMask(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        Array.Clear(maskRow, 0, maskRow.Length);
        Array.Clear(maskCol, 0, maskCol.Length);
        Array.Clear(maskBlock, 0, maskBlock.Length);

        for (int row = 0; row < maskRow.Length; row++)
        {
            for (int col = 0; col < maskCol.Length; col++)
            {
                int value = board[row][col];
                if (value == 0)
                    continue;
                int bit = Helper.NumberToBit(value);
                
            }
        }
        return true;
    }
}