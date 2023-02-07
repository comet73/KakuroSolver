namespace Kakuro;

public class VClue : OpenCell
{
    private byte VerticalClue {get; init;}

    public VClue(byte clue, ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
        if (clue < 1 || clue > 9) {
            throw new ArgumentOutOfRangeException(nameof(clue));
        }

        VerticalClue = clue;
    }
}