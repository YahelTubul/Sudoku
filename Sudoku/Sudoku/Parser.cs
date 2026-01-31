namespace Sudoku;

public class Parser
{
    public const int SizeBoard = 9;
    public const int NumOfCells = 81;
    
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
        if (strBoard.Length != NumOfCells)
        {
            errorMsg = $"The string must contain {NumOfCells} numbers,you need to add {NumOfCells - strBoard.Length} numbers!";
            return false;
        }
        
        //pass on each char in the array and check if its digit between '0' to '9'
        for (int i = 0; i < NumOfCells; i++)
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

    private static int BuildBoard(string strBoard)
    {
        
    }
}

