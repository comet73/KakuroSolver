namespace Kakuro;

public class HVClue : OpenCell {
    public Entry _horizontalEntry {get; init;}

    public Entry _verticalEntry {get; init;}

    public HVClue(Entry hEntry, Entry vEntry, ICell? horizontalNeighbor, ICell? verticalNeighbor) : base(horizontalNeighbor, verticalNeighbor)
    {
        _horizontalEntry = hEntry;

        _verticalEntry = vEntry;
    }
}