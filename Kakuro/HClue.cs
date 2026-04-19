namespace Kakuro;

public class HClue : OpenCell
{
    private Entry _entry {get; init;}

    public HClue(Entry entry, ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
        _entry = entry;
    }
}