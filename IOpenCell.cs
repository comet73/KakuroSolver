namespace Kakuro;

public interface IOpenCell : ICell {
    ICell? HorizontalNeighbor {get;}
    ICell? VerticalNeighbor {get;}

}