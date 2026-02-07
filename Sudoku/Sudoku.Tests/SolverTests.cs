namespace Sudoku.Tests;

public class SolverTests
{
    private int[][] ParseBoard(string strBoard)
    {
        var parser = new Parser();
        parser.Parse(strBoard, out int[][] board, out _);
        return board;
    }

    private bool isSolved(int[][] board)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row][col] == 0)
                    return false;
            }
        }
        return true;
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
        Assert.True(result);
        Assert.Empty(errorMsg);
        Assert.True(isSolved(board));
    }
    [Fact]
    public void Solve_HardSudoku()
    {
        //create solver object
        var solver = new Solver();
        string strBoard = "000000012980000000000600000100700080402000000000300600070000300050040000000010000";
        //call to the parse function
        int [][] board = ParseBoard(strBoard);
        bool result = solver.Solve(board, out string errorMsg);
        Assert.True(result);
        Assert.Empty(errorMsg);
        Assert.True(isSolved(board));
    }
    
    [Fact]
    public void Solve_SolvedSudoku()
    {
        //create solver object
        var solver = new Solver();
        string solved = "534678912672195348198342567859761423426853791713924856961537284287419635345286179";
        //call to the parse function
        int[][] board = ParseBoard(solved);
        bool result = solver.Solve(board, out string errorMsg);
        Assert.True(result);
        Assert.Empty(errorMsg);
    }

    [Fact]
    public void Solve_Unsolveable()
    {
        
    }
}