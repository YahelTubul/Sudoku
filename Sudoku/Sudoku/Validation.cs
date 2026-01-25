namespace Sudoku;

public class Validation
{
    public const int SIZE_BOARD = 9;
    public const int SIZE_BLOCK = 3;
    
    public static bool AppearInRow(int[][] board, int row, int number){
        for (int col = 0; col < SIZE_BOARD; col++)
        {
            if (board[row][col] == number)
                return true;
        }
        return false;
    }

    public static bool AppearInCol(int[][] board, int col, int number)
    {
        for (int row = 0; row < SIZE_BOARD; row++)
        {
            if(board[row][col] == number)
                return true;
        }
        return false;
    }

    public static bool AppearInBlock(int[][] board, int row, int col, int number)
    {
        for (int i = 0; i < SIZE_BLOCK; i++)
        {
            for (int j = 0; j < SIZE_BLOCK; j++)
            {
                if (board[i + row][col + j] == number)
                {
                    return true;
                }
            }
        }
        return false;
    }
}