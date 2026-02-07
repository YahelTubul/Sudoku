namespace Sudoku;

public class Parser : IParser
{
    
    /// <summary>
    /// This function try to parse the board with call to the helper function that check the string , and build the board
    /// </summary>
    /// <param name="strBoard"></param>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false, error message</returns>
    public bool Parse(string strBoard, out int[][] board, out string errorMsg)
    {
        board = null;
        errorMsg = "";
        // check if the string is valid
        if (!ValidInput(strBoard, out errorMsg))
        {
            return false;
        }
        board = BuildBoard(strBoard);
        return true;
    }
    /// <summary>
    /// This function check the received input
    /// </summary>
    /// <param name="strBoard"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false, error message</returns>
    private static bool ValidInput(string strBoard, out string errorMsg)
    {
        errorMsg = "";
        char ch = ' ';

        if (strBoard == null)
        {
            errorMsg = "The string is empty";
            return false;
        }
        //remove whitespaces from the string 
        strBoard = strBoard.Trim();
        
        // check if the length of the string is equal to the number of cells
        if (strBoard.Length != Helper.NumOfCells)
        {
            errorMsg = $"The string must contain {Helper.NumOfCells} numbers,you need to add {Helper.NumOfCells - strBoard.Length} numbers!";
            return false;
        }
        
        //pass on each char in the array and check if its digit between '0' to '9'
        for (int i = 0; i < Helper.NumOfCells; i++)
        {
            ch = strBoard[i];
            if (ch < '0' || ch > '9')
            {
                errorMsg = $"Invalid character in position {i}";
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Build the board as 2d array by using the string received
    /// </summary>
    /// <param name="strBoard"></param>
    /// <returns>board</returns>
    private static int[][] BuildBoard(string strBoard)
    {
        int[][] board = new int[Helper.SizeBoard][];
        
        // pass on each row, and create new array in this index
        for (int row = 0; row < Helper.SizeBoard; row++)
        {
            board[row] = new int[Helper.SizeBoard];
        }
        // pass on each cell and sets to it the specific char from the string
        for (int i = 0; i < Helper.NumOfCells; i++)
        {
            int value = strBoard[i] - '0';
            board[i / Helper.SizeBoard][i % Helper.SizeBoard] = value;
        }
        return board;
    }
}

