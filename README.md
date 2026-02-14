# Sudoku Solver
A Sudoku solver supporting standard 9x9 puzzles using a backtracking algorithm
with MRV heuristic and bit manipulation optimization.

---

## Features
- **Arithmetic operations**: Input parsing from 81 character strings
- **Validation**: Duplicate detection in rows, columns, and 3x3 blocks
- **Smart solving**: Backtracking with MRV heuristic
- **Bit optimization**: Constraint tracking using bit masks for fast performance
- **OOP Design**: Interface based architecture following SOLID principles

---

## Quickstart
```bash
# Run solver
dotnet run --project Sudoku

# Run tests
dotnet test
```

---

## Usage Examples
```text
Enter Sudoku string:
> 530070000600195000098000060800060003400803001700020006060000280000419005000080079

Solve time: 12 ms

5 3 4 | 6 7 8 | 9 1 2
6 7 2 | 1 9 5 | 3 4 8
1 9 8 | 3 4 2 | 5 6 7
------+-------+------
8 5 9 | 7 6 1 | 4 2 3
4 2 6 | 8 5 3 | 7 9 1
7 1 3 | 9 2 4 | 8 5 6
------+-------+------
9 6 1 | 5 3 7 | 2 8 4
2 8 7 | 4 1 9 | 6 3 5
3 4 5 | 2 8 6 | 1 7 9

Solution string: 534678912672195348198342567859761423426853791713924856961537284287419635345286179
```

---

## Input Format
| Field       | Description                        | Example            |
|-------------|------------------------------------|--------------------|
| String      | 81 characters, row by row          | `530070000...`     |
| Empty cell  | Represented by `0`                 | `0`                |
| Filled cell | Digits `1-9`                       | `5`                |
| Exit        | Type to quit                       | `exit`             |

---

## Architecture
```
Input → Parser → Validator → Solver → Result
```

Three stage pipeline:
1. **Parser**: Converts 81 character string into a 9x9 board
2. **Validator**: Checks board structure and Sudoku rules
3. **Solver**: Solves using backtracking with MRV heuristic

---

## Project Structure
```
Sudoku/
├── Program.cs        # Entry point and user interaction
├── Parser.cs         # Parses string input, infers board size automatically
├── Validation.cs     # Board and rules validation
├── Solver.cs         # Backtracking algorithm with MRV
├── BoardData.cs      # Board properties derived from the board itself (generic)
├── Helper.cs         # Bit manipulation utilities
├── IParser.cs        # Parser interface
├── IValidator.cs     # Validator interface
└── ISolver.cs        # Solver interface

Sudoku.Tests/
├── ParserTests.cs       # 6 tests
├── ValidationTests.cs   # 6 tests
├── SolverTests.cs       # 4 tests
└── ProgramTests.cs      # 1 integration test
```

---

## Requirements
- .NET 10.0+
- xUnit 2.9+

---

## Author
Yahel Haim Tubul
