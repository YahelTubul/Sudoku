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
        //call to the validate function from the class
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
        //create empty board
        int[][] board = Helper.CreateEmptyBoard();
        //allocate duplicate values in diffrent rows
        board[0][0] = 5;
        board[0][1] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    //This test validate duplicate values in cols
    public void Validate_DupInCol()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard();
        //allocate duplicate values in diffrent cols
        board[0][0] = 5;
        board[1][0] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    //This test validate duplicate values in block
    public void Validate_DupInBlock()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard();
        //allocate duplicate values in block
        board[0][0] = 5;
        board[2][2] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    public void Validate_InvalidValue()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard();
        //allocate invalid value in the board 
        board[0][0] = 10;
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("must be between", errorMsg.ToLower());
    }

    [Fact]
    public void Validate_WrongSizeBoard()
    {
        
    }
}