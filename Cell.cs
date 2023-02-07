namespace Kakuro;

public abstract class Cell : ICell
{
    public abstract bool IsOpen { get; }

    public Cell() {}

}