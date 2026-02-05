namespace Sudoku;
public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            
        }
    }

    private static void SolveBoard(string strBoard)
    {
        // try to parse the board
        if (!Parser.Parse(strBoard, out int[][] board, out string parseError))
        {
            Helper.PrintError("Parse", parseError);
            return;
        }
        //call to vallidate function for check the board
        if (!Validation.Validate(board, out string validError))
        {
            Helper.PrintError("Validation", validError);
            return;
        }
        Solver solver = new Solver();
        //measure the solving time of the sudoku
        var time = System.Diagnostics.Stopwatch.StartNew();
        bool solved = solver.Solve(board, out string solveError);
        time.Stop();
        Console.WriteLine($"Solve time: {time.ElapsedMilliseconds} ms");
        if (!solved)
        {
            Console.WriteLine($"Solve error: {solveError}\n");
            return;
        }
        //prints
        Helper.PrintBoard(board);
        Console.WriteLine("\nSolution string:");
        Console.WriteLine(Helper.PrintBoardString(board));
        Console.WriteLine();
    }
}