using System.Text.RegularExpressions;

namespace Kakuro;

public class Builder {

    private static readonly Regex RE_BARRED = new Regex("B");
    private static readonly Regex RE_HORIZONTAL = new Regex("H(\\d{1,2})");
    private static readonly Regex RE_VERTICAL = new Regex("V(\\d{1,2})");
    private static readonly Regex RE_HV = new Regex("H(\\d{1,2})V(\\d{1,2})");
    private static readonly Regex RE_OPERAND = new Regex("_");

    public Builder(IList<IList<string>> grid)
    {
        IList<IList<ICell>> CellGrid = new List<IList<ICell>>();

        for (var y = grid.Count -1; y >= 0; y--) {
            IList<string> row = grid[y];
            ICell[] cellRow = new ICell[row.Count];
            for (var x = row.Count -1; x >= 0; x--) {
                var horizontalNeighbor = x < row.Count-1 ? cellRow[x+1] : null;
                var verticalNeighbor = y < grid.Count-1 ? CellGrid[y+1][x] : null;
                ICell cell = createCell(grid[y][x], horizontalNeighbor, verticalNeighbor);
            }
        }
    }

    private ICell createCell(string description, ICell? horizontalNeighbor, ICell? verticalNeighbor) {
        if (RE_BARRED.IsMatch(description)) {
            return new BarredCell();
        }
        if (RE_OPERAND.IsMatch(description)) {
            return new DigitCell(horizontalNeighbor, verticalNeighbor);
        }

        Match m;
        if ((m = RE_HV.Match(description)).Success) {
            return new HVClue(byte.Parse(m.Groups[1].Value), byte.Parse(m.Groups[2].Value), horizontalNeighbor, verticalNeighbor);
        }
        if ((m = RE_HORIZONTAL.Match(description)).Success) {
            return new HClue(byte.Parse(m.Groups[1].Value), horizontalNeighbor, verticalNeighbor);
        }
        if ((m = RE_VERTICAL.Match(description)).Success) {
            return new VClue(byte.Parse(m.Groups[1].Value), horizontalNeighbor, verticalNeighbor);
        }

        throw new InvalidDataException($"{description} cannot be parsed to a cell");
    }
}