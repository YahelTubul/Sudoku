namespace Sudoku.Tests;

public class ValidationTests
{
    [Fact]
    //This test validate empty board 
    public void Validate_EmptyBoard_Pass()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard(9);
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.True(result);
        Assert.Empty(errorMsg);
    }

    [Fact]
    //This test validate duplicate values in row
    public void Validate_DupInRow_Fails()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard(9);
        //allocate duplicate values in same rows
        board[0][0] = 5;
        board[0][1] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    //This test validate duplicate values in cols
    public void Validate_DupInCol_Fails()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard(9);
        //allocate duplicate values in same cols
        board[0][0] = 5;
        board[1][0] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    //This test validate duplicate values in block
    public void Validate_DupInBlock_Fails()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard(9);
        //allocate duplicate values in block
        board[0][0] = 5;
        board[2][2] = 5;
        //call to the validate function from the class
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("duplicate", errorMsg.ToLower());
    }

    [Fact]
    public void Validate_InvalidValue_Fails()
    {
        //create validation object
        var validate = new Validation();
        //create empty board
        int[][] board = Helper.CreateEmptyBoard(9);
        //allocate invalid value in the board 
        board[0][0] = 10;
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("must be between", errorMsg.ToLower());
    }

    [Fact]
    public void Validate_WrongSizeBoard_Fails()
    {
        //create validation object
        var validate = new Validation();
        //create board with wrong size 
        int[][] board = new int[8][];
        bool result = validate.Validate(board, out string errorMsg);
        Assert.False(result);
        Assert.Contains("rows", errorMsg.ToLower());
    }
}