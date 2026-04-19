namespace Kakuro;

public class BarredCell : Cell
{
    public BarredCell() : base()
    {
    }

    public override bool IsOpen => false;
}