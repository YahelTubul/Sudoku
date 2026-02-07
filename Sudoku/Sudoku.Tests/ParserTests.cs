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
    public void Parse_EmptyBoard()
    {
        var parser = new Parser();
    }
}