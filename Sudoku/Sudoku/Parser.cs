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
        if (!ValidInput(strBoard, out errorMsg,  out int sizeBoard))
        {
            return false;
        }
        board = BuildBoard(strBoard, sizeBoard);
        return true;
    }
    /// <summary>
    /// This function check the received input
    /// </summary>
    /// <param name="strBoard"></param>
    /// <param name="errorMsg"></param>
    /// <returns>true/false, error message</returns>
    private static bool ValidInput(string strBoard, out string errorMsg, out int sizeBoard)
    {
        errorMsg = "";
        sizeBoard = 0;

        if (strBoard == null)
        {
            errorMsg = "The string is empty";
            return false;
        }
        //remove whitespaces from the string 
        strBoard = strBoard.Trim();
        
        int NumOfCells = strBoard.Length;
        //the square from the number of the cells 
        int infferSize = (int)Math.Sqrt(NumOfCells);
        
        // validate that the infer size it is square
        if (infferSize * infferSize != NumOfCells)
        {
            errorMsg = $"String length {infferSize} is not a square";
            return false;
        }
        sizeBoard = infferSize;
        //pass on each char in the array and check if its digit between '0' to '9'
        for (int i = 0; i < NumOfCells; i++)
        {
            char ch = strBoard[i];
            int digit = ch - '0';
            
            if (digit < 0 || digit > sizeBoard)
            {
                errorMsg = $"Invalid character {ch} in position {i}";
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
    private static int[][] BuildBoard(string strBoard, int sizeBoard)
    {
        int[][] board = Helper.CreateEmptyBoard(sizeBoard);

        for (int i = 0; i < strBoard.Length; i++)
        {
            board[i / sizeBoard][i % sizeBoard] = strBoard[i] - '0';
        }
        return board;
    }
}

