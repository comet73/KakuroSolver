namespace Kakuro;

public class OpenCell : Cell, IOpenCell {

    public ICell? HorizontalNeighbor {get; init;}

    public ICell? VerticalNeighbor {get; init;}

    public override bool IsOpen => true;

    public OpenCell(ICell? horizontal, ICell? vertical)
    {
        HorizontalNeighbor = horizontal;

        VerticalNeighbor = vertical;
    }


}