namespace Sudoku;

public class Validation
{
    public const int SIZE = 9;
    
    public static bool AppearInRow(int[][] board, int row, int number){
        for (int col = 0; col < SIZE; col++)
        {
            if (board[row][col] == number)
                return true;
        }
        return false;
    }
}