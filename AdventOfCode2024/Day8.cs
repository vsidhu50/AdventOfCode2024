using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2024;

public class Day8 {
    public static int PartOne() {
        var grid = Utilities.GetInputGridChars(8);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var antennas = new Dictionary<char, List<(int row, int col)>>();

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                var curr = grid[i, j];
                if (curr != '.') {
                    if (!antennas.ContainsKey(curr)) {
                        antennas.Add(curr, new List<(int row, int col)>());
                    }
                    antennas[curr].Add((i, j));
                }
            }
        }

        var antinodes = new HashSet<(int row, int col)>();

        foreach (var (_, locations) in antennas) {
            for (int i = 0; i < locations.Count - 1; i++) {
                var (currRow, currCol) = locations[i];
                for (int j = i + 1; j < locations.Count; j++) {
                    var (nextRow, nextCol) = locations[j];
                    var rowDist = nextRow - currRow;
                    var colDist = nextCol - currCol;

                    var (antinode1Row, antinode1Col) = (currRow - rowDist, currCol - colDist);
                    var (antinode2Row, antinode2Col) = (nextRow + rowDist, nextCol + colDist);

                    if (antinode1Row >= 0 && antinode1Row < numRows && antinode1Col >= 0 && antinode1Col < numCols) {
                        antinodes.Add((antinode1Row, antinode1Col));
                    }
                    if (antinode2Row >= 0 && antinode2Row < numRows && antinode2Col >= 0 && antinode2Col < numCols) {
                        antinodes.Add((antinode2Row, antinode2Col));
                    }
                }
            }
        }
        return antinodes.Count;
    }

    public static int PartTwo() {
        var grid = Utilities.GetInputGridChars(8);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var antennas = new Dictionary<char, List<(int row, int col)>>();

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                var curr = grid[i, j];
                if (curr != '.') {
                    if (!antennas.ContainsKey(curr)) {
                        antennas.Add(curr, new List<(int row, int col)>());
                    }
                    antennas[curr].Add((i, j));
                }
            }
        }

        var antinodes = new HashSet<(int row, int col)>();

        foreach (var (_, locations) in antennas) {
            for (int i = 0; i < locations.Count - 1; i++) {
                var (currRow, currCol) = locations[i];
                antinodes.Add((currRow, currCol));
                for (int j = i + 1; j < locations.Count; j++) {
                    var (nextRow, nextCol) = locations[j];
                    antinodes.Add((nextRow, nextCol));
                    var rowDist = nextRow - currRow;
                    var colDist = nextCol - currCol;

                    var (antinode1Row, antinode1Col) = (currRow - rowDist, currCol - colDist);
                    var (antinode2Row, antinode2Col) = (nextRow + rowDist, nextCol + colDist);

                    while (antinode1Row >= 0 && antinode1Row < numRows && antinode1Col >= 0 && antinode1Col < numCols) {
                        antinodes.Add((antinode1Row, antinode1Col));
                        antinode1Row -= rowDist;
                        antinode1Col -= colDist;
                    }

                    while (antinode2Row >= 0 && antinode2Row < numRows && antinode2Col >= 0 && antinode2Col < numCols) {
                        antinodes.Add((antinode2Row, antinode2Col));
                        antinode2Row += rowDist;
                        antinode2Col += colDist;
                    }
                }
            }
        }
        return antinodes.Count;
    }
}