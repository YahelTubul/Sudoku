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
    public void Solve_EasySudoku()
    {
        //create solver object
        var solver = new Solver();
        string strBoard = "301086504046521070500000001400800002080347900009050038004090200008734090007208103";
        //call to the parse function
        int [][] board = ParseBoard(strBoard);
        bool result = solver.Solve(board, out string errorMsg);
        
        

    }
}