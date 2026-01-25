namespace Sudoku;

public class Validation
{
    public const int SIZE_BOARD = 9;
    
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
}