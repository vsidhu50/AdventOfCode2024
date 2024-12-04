namespace AdventOfCode2024;

public class Day4 
{
    public static int PartOne() 
    {
        var grid = Utilities.GetInputGridChars(4);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var count = 0;

        // horizontal left to right
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols - 3; j++) {
                if (grid[i, j] == 'X') {
                    if (grid[i, j + 1] == 'M' && grid[i, j + 2] == 'A' && grid[i, j + 3] == 'S') {
                        count++;
                        j += 3;
                    }
                }
            }
        }

        // horizontal right to left
        for (int i = 0; i < numRows; i++) {
            for (int j = numCols - 1; j >= 3; j--) {
                if (grid[i, j] == 'X') {
                    if (grid[i, j - 1] == 'M' && grid[i, j - 2] == 'A' && grid[i, j - 3] == 'S') {
                        count++;
                        j -= 3;
                    }
                }
            }
        }

        // vertical down
        for (int j = 0; j < numCols; j++) {
            for (int i = 0; i < numRows - 3; i++) {
                if (grid[i, j] == 'X') {
                    if (grid[i + 1, j] == 'M' && grid[i + 2, j] == 'A' && grid[i + 3, j] == 'S') {
                        count++;
                        i += 3;
                    }
                }
            }
        }

        // vertical up
        for (int j = 0; j < numCols; j++) {
            for (int i = numRows - 1; i >= 3; i--) {
                if (grid[i, j] == 'X') {
                    if (grid[i - 1, j] == 'M' && grid[i - 2, j] == 'A' && grid[i - 3, j] == 'S') {
                        count++;
                        i -= 3;
                    }
                }
            }
        }

        // diagonal down and to the right
        for (int i = 0; i < numRows - 3; i++) {
            for (int j = 0; j < numCols - 3; j++) {
                if (grid[i, j] == 'X') {
                    if (grid[i + 1, j + 1] == 'M' && grid[i + 2, j + 2] == 'A' && grid[i + 3, j + 3] == 'S') {
                        count++;
                    }
                }
            }
        }

        // diagonal down and to the left
        for (int i = 0; i < numRows - 3; i++) {
            for (int j = numCols - 1; j >= 3; j--) {
                if (grid[i, j] == 'X') {
                    if (grid[i + 1, j - 1] == 'M' && grid[i + 2, j - 2] == 'A' && grid[i + 3, j - 3] == 'S') {
                        count++;
                    }
                }
            }
        }

        // diagonal up and to the right
        for (int i = numRows - 1; i >= 3; i--) {
            for (int j = 0; j < numCols - 3; j++) {
                if (grid[i, j] == 'X') {
                    if (grid[i - 1, j + 1] == 'M' && grid[i - 2, j + 2] == 'A' && grid[i - 3, j + 3] == 'S') {
                        count++;
                    }
                }
            }
        }

        // diagonal up and to the left
        for (int i = numRows - 1; i >= 3; i--) {
            for (int j = numCols - 1; j >= 3; j--) {
                if (grid[i, j] == 'X') {
                    if (grid[i - 1, j - 1] == 'M' && grid[i - 2, j - 2] == 'A' && grid[i - 3, j - 3] == 'S') {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public static int PartTwo()
    {
        var grid = Utilities.GetInputGridChars(4);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var count = 0;

        for (int i = 0; i < numRows - 2; i++) {
            for (int j = 0; j < numCols - 2; j++) {
                if (grid[i, j] == 'M') {
                    if (grid[i + 1, j + 1] == 'A' && grid[i + 2, j + 2] == 'S') {
                        // both Ms on top
                        if (grid[i, j + 2] == 'M' && grid[i + 2, j] == 'S') {
                            count++;
                        }
                        // both Ms on left
                        else if (grid[i, j + 2] == 'S' && grid[i + 2, j] == 'M') {
                            count++;
                        }
                    }
                }
            }
        }

        // both Ms on bottom
        for (int i = numRows - 1; i >= 2; i--) {
            for (int j = 0; j < numCols - 2; j++) {
                if (grid[i, j] == 'M') {
                    if (grid[i - 1, j + 1] == 'A' && grid[i - 2, j + 2] == 'S') {
                        if (grid[i, j + 2] == 'M' && grid[i - 2, j] == 'S') {
                            count++;
                        }
                    }
                }
            }
        }

        // both Ms on right
        for (int i = 0; i < numRows - 2; i++) {
            for (int j = numCols - 1; j >= 2; j--) {
                if (grid[i, j] == 'M') {
                    if (grid[i + 1, j - 1] == 'A' && grid[i + 2, j - 2] == 'S') {
                        if (grid[i, j - 2] == 'S' && grid[i + 2, j] == 'M') {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}