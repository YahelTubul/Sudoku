namespace Sudoku;

public class Solver : ISolver
{
    private int[] _maskRow;
    private int[] _maskCol;
    private int[] _maskBlock;
    private BoardData _data;
    private int[][] _blockIndex;
    
    /// <summary>
    /// This function turn the board to mask for fast scan
    /// </summary>
    /// <param name="board"></param>
    private void CreateMask(int[][] board)
    {
        //create an objects for the attributes
        _data = new BoardData(board);
        _maskRow   = new int[_data.SizeBoard];
        _maskCol   = new int[_data.SizeBoard];
        _maskBlock = new int[_data.SizeBoard];
        _blockIndex =  new int[_data.SizeBoard][];
        //calculate the block index of all the board
        for (int row = 0; row < _data.SizeBoard; row++)
        {
            _blockIndex[row] = new int[_data.SizeBoard];
            for (int col = 0; col < _data.SizeBoard; col++)
                _blockIndex[row][col] = Helper.GetBlockIndex(row, col, _data.SizeBlock);
        }
        
        //these loops pass on each cell
        for (int row = 0; row < _data.SizeBoard; row++)
        {
            for (int col = 0; col < _data.SizeBoard; col++)
            {
                //save the value in the present cell
                int value = board[row][col];
                if (value == 0)
                    continue;
                
                int bit = Helper.NumberToBit(value);
                //sign the number by turn on the bits in the masks
                _maskRow[row] |= bit;
                _maskCol[col] |= bit;
                _maskBlock[_blockIndex[row][col]] |= bit;
            }
        }
    }
    /// <summary>
    /// This function return bit mask of number that can to place
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private int OptionalMask(int row, int col)
    {
        // create mask of numbers that you cant to place in the specific cell
        int useMask = _maskRow[row] | _maskCol[col] | _maskBlock[_blockIndex[row][col]];
        return _data.CompleteMask & ~useMask;
    }
    /// <summary>
    /// find the empty cell with the minimal options to place 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="FindRow"></param>
    /// <param name="FindCol"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    private bool FindCell(int[][] board, out int FindRow, out int FindCol,  out int mask)
    {
        FindRow = -1;
        FindCol = -1;
        mask = 0;
        int count = 10;
        //these loops pass on each cell in the board
        for (int row = 0; row < _data.SizeBoard; row++)
        {
            for (int col = 0; col < _data.SizeBoard; col++)
            {
                //if there is a value in cell continue to the next iteration
                if (board[row][col] != 0)
                {
                    continue; 
                }
                int optionalMask = OptionalMask(row, col);
                if (optionalMask == 0)
                {
                    FindRow = row;
                    FindCol = col;
                    mask = 0;
                    return true;
                }
                int countOnBits = Helper.CountOnBits(optionalMask);
                //check if the amount of the on bits is smaller than the max on bits
                if (countOnBits < count)
                {
                    count =  countOnBits;
                    FindRow = row;
                    FindCol = col;
                    mask = optionalMask;
                }
                
                if (count == 1)
                    return true;
            } 
        }
        return FindRow != -1;
    }
    
    /// <summary>
    /// allocate value in the cell
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="number"></param>
    /// <param name="bit"></param>
    private void AllocateValue(int[][] board, int row, int col, int number, int bit)
    {
        //allocate the new number in cell
        board[row][col] = number;
        //turn on the bits in each mask 
        _maskBlock[_blockIndex[row][col]] |= bit;
        _maskRow[row] |= bit;
        _maskCol[col] |= bit;
    }
    /// <summary>
    /// remove the value from cell
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="bit"></param>
    private void RemoveValue(int[][] board, int row, int col, int bit)
    {
        //change the value in the cell to 0
        board[row][col] = 0;
        //turn off the bits in each mask 
        _maskBlock[_blockIndex[row][col]] &= ~bit;
        _maskRow[row] &= ~bit;
        _maskCol[col] &= ~bit;
    }
    /// <summary>
    /// solves the board using recursive backtracking algorithm
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    private bool Backtracking(int[][] board)
    {
        // find the cell with the minimum options to allocate in
        if (!FindCell(board, out int row, out int col, out int optionalMask))
            // if dont find, the sudokou is solved
            return true;
        //there are no options to allocate in the cell
        if (optionalMask == 0)
            return false;
        while (optionalMask != 0)
        {
            //get the bit that present the first option to check 
            int setBit = Helper.GetFirstSetBit(optionalMask);
            int number = Helper.BitToNumber(setBit);
            //try to do allocate to the option that taken from the mask
            AllocateValue(board, row, col, number, setBit);
            //check if find true option to the cell and stop the recursion
            if(Backtracking(board))
                return true;
            //remove the incorrect value that try to allocate in the cell
            RemoveValue(board, row, col, setBit);
            //remove the incorrect option from the mask
            optionalMask ^= setBit;
        }
        return false;
    }
    /// <summary>
    /// implement the ISolver interface function
    /// </summary>
    /// <param name="board"></param>
    /// <param name="errorMsg"></param>
    /// <returns></returns>
    public bool Solve(int[][] board, out string errorMsg)
    {
        errorMsg = "";
        CreateMask(board);
        bool solve = Backtracking(board);
        if (!solve)
        {
            errorMsg = "The board has no solution";
            return false;
        }
        return solve;
    }
}


