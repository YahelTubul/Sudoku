namespace Sudoku;
//This interface implement the board validation function
public interface IValidation
{
    /// <summary>
    /// check if the board size and values are valid 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns></returns>
    bool Validate(int[][] board, out string errorMsg);
}