namespace Sudoku.Tests;

public class ValidationTests
{
    [Fact]
    //This test validate empty board 
    public void Validate_EmptyBoard()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard();
        bool result = validate.Validate(board, out string errorMsg);
        Assert.True(result);
        Assert.Empty(errorMsg);
    }

    [Fact]
    //This test validate duplicate values in row
    public void Validate_DupInRow()
    {
        //create validation object
        var validate = new Validation();
    }
}