namespace Sudoku;

public class Validation
{
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;

    private static bool BoardValid(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        if (board == null || board.Length != SizeBlock)
        {
            errorMsg = "Board size need to include 9 rows!";
            return false;
        }

        for (int row = 0; row < SizeBoard; row++ )
        {
            if (board[row] == null || board[row].Length != SizeBlock)
            {
                errorMsg = "Board size need to include 9 columns!";
            }
        }
        return true;
    }
}