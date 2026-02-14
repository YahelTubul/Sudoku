namespace Sudoku;
//This interface implements the parse of the board
public interface IParser
{
    /// <summary>
    /// parsing the sudoku board
    /// </summary>
    /// <param name="strBoard"></param>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns></returns>
    bool Parse(string strBoard, out int[][] board, out string errorMsg);
}