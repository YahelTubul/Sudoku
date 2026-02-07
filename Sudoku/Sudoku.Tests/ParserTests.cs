using Xunit;

namespace Sudoku.Tests;

public class ParserTests
{
    [Fact]
    //This teest try to do parsing on valid input 
    public void Parse_ValidInput()
    {
        //create parser object 
        var parser = new Parser();
        string strBoard = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
        //call to the parse function from the class
        bool result = parser.Parse(strBoard, out int[][] board, out string errorMsg);
        Assert.True(result);
        Assert.NotNull(board);
        Assert.Equal(9, board.Length);
        Assert.Empty(errorMsg);
    }
    
    [Fact]
    // This test try to do parsing on empty board 
    public void Parse_EmptyBoard()
    {
        // create parser object
        var parser = new Parser();
        //create empty string that present the board 
        string strBoard = new string('0', 81);
        //call to the parse function from the class
        bool result = parser.Parse(strBoard, out int[][] board, out string errorMsg);
        Assert.True(result);
        Assert.NotNull(board);
        Assert.Equal(0, board[0][0]);
    }

    [Fact]
    //This test try do parsing on null that present empty board
    public void Parse_Null()
    {
        // create parser object
        var parser = new Parser();
        //call to the parse function from the class
        bool result = parser.Parse(null, out int[][] board, out string errorMsg);
        Assert.False(result);
        Assert.Null(board);
        Assert.Equal("The string is empty", errorMsg);
    }
    
    [Fact]
    // This test try to do parsing on short string 
    public void Parse_ShortBoard()
    {
        // create parser object
        var parser = new Parser();
        string strBoard = "12345";
        //call to the parse function from the class
        bool result = parser.Parse(strBoard, out int[][] board, out string errorMsg);
        Assert.False(result);
        Assert.Null(board);
        Assert.Contains("must contain 81 numbers", errorMsg);
    }

    [Fact]
    public void Parse_InvalidInput()
    {
        var parser = new Parser();
    }
    
}