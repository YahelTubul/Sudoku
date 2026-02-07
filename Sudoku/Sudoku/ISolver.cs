namespace Sudoku;
//This interface implement the strategy to solve the sudoku
public interface ISolver
{
    /// <summary>
    /// Solves the Sudoku board 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns></returns>
    bool Solve(int[][] board, out string errorMsg);
}