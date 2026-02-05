using System.Text;

namespace Sudoku;

public class Helper
{
    public const int SizeBoard = 9;
    public const int SizeBlock = 3;
    public const int CompleteMask = 0b1111111110;

    /// <summary>
    /// check if the bit is on using binary operator
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="bit"></param>
    /// <returns>true/false</returns>
    public static bool SetBit(int mask, int bit)
    {
        return (mask & bit) != 0;
    }

    /// <summary>
    /// calculate the index of the present block
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>index of the present block</returns>
    public static int GetBlockIndex(int row, int col)
    {
        return (row / SizeBlock) * SizeBlock + (col / SizeBlock);
    }

    /// <summary>
    /// Convert number to bit series 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int NumberToBit(int number)
    {
        return 1 << number;
    }

    /// <summary>
    /// Count how much on bits there are in the mask
    /// </summary>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static int CountOnBits(int mask)
    {
        int count = 0;
        while (mask != 0)
        {
            mask &= (mask - 1);
            count++;
        }

        return count;
    }

    /// <summary>
    /// return the first set bit, this is the first option for check in the backtracking 
    /// </summary>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static int GetFirstSetBit(int mask)
    {
        return mask & -mask;
    }
    /// <summary>
    /// convert bit to number
    /// </summary>
    /// <param name="bit"></param>
    /// <returns></returns>
    public static int BitToNumber(int bit)
    {
        int number = 0;
        while (bit > 1)
        {
            bit >>= 1;
            number++;
        }
        return number;
    }

    /// <summary>
    /// print the solution of the board as pretty table
    /// </summary>
    /// <param name="board"></param>
    public static void PrintBoard(int[][] board)
    {
        for (int row = 0; row < SizeBoard; row++)
        {
            if (row == SizeBlock || row == 6)
            {
                Console.WriteLine("---------------------");
            }

            for (int col = 0; col < SizeBoard; col++)
            {
                if (col == SizeBlock || col == 6)
                {
                    Console.Write("| ");
                }

                Console.Write(board[row][col] + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// return the string the present the solved sudoku
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public static string PrintBoardString(int[][] board)
    {
        StringBuilder solvedStr = new StringBuilder(81);
        for (int row = 0; row < SizeBoard; row++)
        {
            for (int col = 0; col < SizeBoard; col++)
            {
                solvedStr.Append((char)('0' + board[row][col]));
            }
        }

        return solvedStr.ToString();
    }
    /// <summary>
    /// print error message 
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    public static void PrintError(string subject, string message)
    {
        Console.WriteLine($"{subject} error: {message}\n");
    }

}