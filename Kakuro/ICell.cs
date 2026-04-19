namespace Kakuro;

public interface ICell {
    bool IsOpen {get;}

    ICell? HorizontalNeighbor { get; }
    ICell? VerticalNeighbor { get; }

    byte HorizontalLength { get; }
    byte VerticalLength { get; }

}

