namespace Kakuro;

public class OpenCell : Cell, IOpenCell {

    public OpenCell(ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
    }

}