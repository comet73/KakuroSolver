namespace Kakuro;

public abstract class Cell : ICell
{
    public bool IsOpen { get; }

    public ICell? HorizontalNeighbor { get; init; }

    public ICell? VerticalNeighbor { get; init; }

    public byte HorizontalLength
    {
        get
        {
            if (HorizontalNeighbor is IOpenCell)
            {
                return (byte)(1 + ((IOpenCell)HorizontalNeighbor).HorizontalLength);
            }
            else
            {
                return 1;
            }
        }
    }

    public byte VerticalLength
    {
        get
        {
            if (VerticalNeighbor is IOpenCell)
            {
                return (byte)(1 + ((IOpenCell)VerticalNeighbor).VerticalLength);
            }
            else
            {
                return 1;
            }
        }
    }

    public Cell() {
        HorizontalNeighbor = null;
        VerticalNeighbor = null;
        IsOpen = false;
    }

    public Cell(ICell? horizontalNeighbour, ICell? verticalNeighbour)
    {
        HorizontalNeighbor = horizontalNeighbour;
        VerticalNeighbor = verticalNeighbour;
        IsOpen = HorizontalNeighbor != null || VerticalNeighbor != null;
    }

}