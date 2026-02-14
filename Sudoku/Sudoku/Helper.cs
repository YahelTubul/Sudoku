using System.Text;

namespace Sudoku;

public class Helper
{
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
    public static int GetBlockIndex(int row, int col,int sizeBlock)
    {
        return (row / sizeBlock) * sizeBlock + (col / sizeBlock);
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
        int sizeBoard = board.Length;
        int sizeBlock = (int)Math.Sqrt(sizeBoard);
        for (int row = 0; row < sizeBoard; row++)
        {
            if (row > 0 && row % sizeBlock == 0)
            {
                Console.WriteLine(new string('-', sizeBoard * 2 + sizeBlock - 1));
            }

            for (int col = 0; col < sizeBoard; col++)
            {
                if (col > 0 && col % sizeBlock == 0)
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
        int sizeBoard = board.Length;
        StringBuilder solvedStr = new StringBuilder(sizeBoard*sizeBoard);
        for (int row = 0; row < sizeBoard; row++)
        {
            for (int col = 0; col < sizeBoard; col++)
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
    
    public static int[][] CreateEmptyBoard(int sizeBoard)
    {
        int[][] board = new int[sizeBoard][];
        for (int i = 0; i < sizeBoard; i++)
        {
            board[i] = new int[sizeBoard];
        }
        return board;
    }

}