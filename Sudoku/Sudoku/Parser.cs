namespace Sudoku;

public class Parser
{
    public const int SizeBoard = 9;
    public const int NumOfCells = 81;

    private static bool ValidInput(string strBoard, out string errorMsg)
    {
        errorMsg = "";

        if (strBoard == null)
        {
            errorMsg = "The string is empty";
            return false;
        }
        //remove whitespaces from the string 
        strBoard = strBoard.Trim();
    }
}