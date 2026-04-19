namespace Kakuro;

public class VClue : OpenCell
{
    private Entry _entry {get; init;}

    public VClue(Entry entry, ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
        _entry = entry;
    }
}