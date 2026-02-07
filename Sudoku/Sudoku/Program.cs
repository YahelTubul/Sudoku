namespace Sudoku;
public class Program
{

    private readonly IValidation validation;
    private readonly IParser parser;
    private readonly ISolver solver;
    
    /// <summary>
    /// constructor function
    /// </summary>
    /// <param name="validation"></param>
    /// <param name="parser"></param>
    /// <param name="solver"></param>
    public Program(IValidation validation, IParser parser, ISolver solver)
    {
        this.validation = validation;
        this.parser = parser;
        this.solver = solver;
    }
    //contructor default without parameters
    public Program()
    {
        validation = new Validation();
        parser = new Parser();
        solver = new Solver();
    }
    
    /// <summary>
    /// manage the conversation with the user and print the solves sudoku
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        //loop until the user want to quit 
        while (true)
        {
            Console.WriteLine("Enter Sudoku string:");
            Console.WriteLine("enter 'exit' to quit");
            string strBoard = Console.ReadLine();
            if (strBoard == null)
            {
                Console.WriteLine();
                continue;
            }
            //remove spaces from the string 
            strBoard = strBoard.Trim();
            //check if the user don't want to quit
            if (strBoard.Equals("exit", StringComparison.OrdinalIgnoreCase))
                return;
            SolveBoard(strBoard);
        }
    }
    /// <summary>
    /// solve single board and print the solution
    /// </summary>
    /// <param name="strBoard"></param>
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