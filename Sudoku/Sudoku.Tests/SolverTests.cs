namespace Sudoku.Tests;

public class SolverTests
{
    private int[][] ParseBoard(string strBoard)
    {
        var parser = new Parser();
        parser.Parse(strBoard, out int[][] board, out _);
        return board;
    }
    [Fact]
}