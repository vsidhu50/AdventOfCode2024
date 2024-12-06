namespace AdventOfCode2024;

public class Day6 {
    public static int PartOne() {
        var grid = Utilities.GetInputGridChars(6);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        (int row, int col, char direction) guard = (0, 0, '^');
        (int row, int col) start = (0, 0);
        var count = 0;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                if (grid [i, j] == '^') {
                    guard = (i, j, '^');
                    start = (i, j);
                }
            }
        }

        while (guard.row >= 0 && guard.row < numRows && guard.col >= 0 && guard.col < numCols) {
            switch (grid[guard.row, guard.col]) {
                case '^':
                    if (guard.row == 0) {
                        grid[guard.row, guard.col] = 'X';
                        guard.row--;
                    }
                    else if (grid[guard.row - 1, guard.col] == '#') {
                        grid[guard.row, guard.col] = '>';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row - 1, guard.col] = '^';
                        guard.row--;
                    }
                    break;
                case '>':
                    if (guard.col == numCols - 1) {
                        grid[guard.row, guard.col] = 'X';
                        guard.col++;
                    }
                    else if (grid[guard.row, guard.col + 1] == '#') {
                        grid[guard.row, guard.col] = 'v';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row, guard.col + 1] = '>';
                        guard.col++;
                    }
                    break;
                case 'v':
                    if (guard.row == numRows - 1) {
                        grid[guard.row, guard.col] = 'X';
                        guard.row++;
                    }
                    else if (grid[guard.row + 1, guard.col] == '#') {
                        grid[guard.row, guard.col] = '<';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row + 1, guard.col] = 'v';
                        guard.row++;
                    }
                    break;
                default:
                    if (guard.col == 0) {
                        grid[guard.row, guard.col] = 'X';
                        guard.col--;
                    }
                    else if (grid[guard.row, guard.col - 1] == '#') {
                        grid[guard.row, guard.col] = '^';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row, guard.col - 1] = '<';
                        guard.col--;
                    }
                    break;
            }
        }

        grid[start.row, start.col] = 'X';

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                if (grid [i, j] == 'X') {
                    count++;
                }
            }
        }

        return count;
    }

    public static int PartTwo() {
        var grid = Utilities.GetInputGridChars(6);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        (int row, int col, char direction) guard = (0, 0, '^');
        (int row, int col) start = (0, 0);
        var count = 0;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                if (grid [i, j] == '^') {
                    guard = (i, j, '^');
                    start = (i, j);
                }
            }
        }

        while (guard.row >= 0 && guard.row < numRows && guard.col >= 0 && guard.col < numCols) {
            switch (grid[guard.row, guard.col]) {
                case '^':
                    if (guard.row == 0) {
                        grid[guard.row, guard.col] = 'X';
                        guard.row--;
                    }
                    else if (grid[guard.row - 1, guard.col] == '#') {
                        grid[guard.row, guard.col] = '>';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row - 1, guard.col] = '^';
                        guard.row--;
                    }
                    break;
                case '>':
                    if (guard.col == numCols - 1) {
                        grid[guard.row, guard.col] = 'X';
                        guard.col++;
                    }
                    else if (grid[guard.row, guard.col + 1] == '#') {
                        grid[guard.row, guard.col] = 'v';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row, guard.col + 1] = '>';
                        guard.col++;
                    }
                    break;
                case 'v':
                    if (guard.row == numRows - 1) {
                        grid[guard.row, guard.col] = 'X';
                        guard.row++;
                    }
                    else if (grid[guard.row + 1, guard.col] == '#') {
                        grid[guard.row, guard.col] = '<';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row + 1, guard.col] = 'v';
                        guard.row++;
                    }
                    break;
                default:
                    if (guard.col == 0) {
                        grid[guard.row, guard.col] = 'X';
                        guard.col--;
                    }
                    else if (grid[guard.row, guard.col - 1] == '#') {
                        grid[guard.row, guard.col] = '^';
                    }
                    else {
                        grid[guard.row, guard.col] = 'X';
                        grid[guard.row, guard.col - 1] = '<';
                        guard.col--;
                    }
                    break;
            }
        }

        grid[start.row, start.col] = '^';
        var possiblePositions = new List<(int row, int col)>();

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                if (grid [i, j] == 'X') {
                    possiblePositions.Add((i, j));
                }
            }
        }

        foreach (var (row, col) in possiblePositions) {
            guard = (start.row, start.col, '^');
            grid[start.row, start.col] = '^';
            var visited = new List<(int row, int col, char direction)>();

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (grid[i, j] == 'X')
                    {
                        grid[i, j] = '.';
                    }
                }
            }

            grid[row, col] = '#';

            while (guard.row >= 0 && guard.row < numRows && guard.col >= 0 && guard.col < numCols && !visited.Contains(guard)) {
                visited.Add(guard);
                switch (grid[guard.row, guard.col])
                {
                    case '^':
                        if (guard.row == 0)
                        {
                            grid[guard.row, guard.col] = 'X';
                            guard.row--;
                        }
                        else if (grid[guard.row - 1, guard.col] == '#')
                        {
                            grid[guard.row, guard.col] = '>';
                            guard.direction = '>';
                        }
                        else
                        {
                            grid[guard.row, guard.col] = 'X';
                            grid[guard.row - 1, guard.col] = '^';
                            guard.row--;
                        }
                        break;
                    case '>':
                        if (guard.col == numCols - 1)
                        {
                            grid[guard.row, guard.col] = 'X';
                            guard.col++;
                        }
                        else if (grid[guard.row, guard.col + 1] == '#')
                        {
                            grid[guard.row, guard.col] = 'v';
                            guard.direction = 'v';
                        }
                        else
                        {
                            grid[guard.row, guard.col] = 'X';
                            grid[guard.row, guard.col + 1] = '>';
                            guard.col++;
                        }
                        break;
                    case 'v':
                        if (guard.row == numRows - 1)
                        {
                            grid[guard.row, guard.col] = 'X';
                            guard.row++;
                        }
                        else if (grid[guard.row + 1, guard.col] == '#')
                        {
                            grid[guard.row, guard.col] = '<';
                            guard.direction = '<';
                        }
                        else
                        {
                            grid[guard.row, guard.col] = 'X';
                            grid[guard.row + 1, guard.col] = 'v';
                            guard.row++;
                        }
                        break;
                    default:
                        if (guard.col == 0)
                        {
                            grid[guard.row, guard.col] = 'X';
                            guard.col--;
                        }
                        else if (grid[guard.row, guard.col - 1] == '#')
                        {
                            grid[guard.row, guard.col] = '^';
                            guard.direction = '^';
                        }
                        else
                        {
                            grid[guard.row, guard.col] = 'X';
                            grid[guard.row, guard.col - 1] = '<';
                            guard.col--;
                        }
                        break;
                }
            }

            if (visited.Contains(guard)) {
                count++;
            }

            grid[row, col] = '.';
        }

        return count;
    }
}