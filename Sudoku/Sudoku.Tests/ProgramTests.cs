namespace Sudoku.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_FullFlow_Pass()
    {
        string strBoard = "000000012500008000000700000600120000700000450000030000030000800000500700020000000";
        var parser = new Parser();
        var validate = new Validation();
        var solver = new Solver();
        
        bool parseRes= parser.Parse(strBoard, out int[][] board, out string parseError);
        bool validateRes = validate.Validate(board, out string validateError);
        bool solveRes = solver.Solve(board, out string solveError);
        
        Assert.True(parseRes, $"parse failed: {parseError}");
        Assert.True(validateRes, $"validation failed: {validateError}");
        Assert.True(solveRes, $"solve failed: {solveError}");
        
        //valid the board is complete and solved
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board.Length; col++)
            {
                Assert.InRange(board[row][col], 1, 9);
            }
        }
    }
}