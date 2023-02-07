namespace Kakuro;

public class HClue : OpenCell
{
    private byte HorizontalClue {get; init;}

    public HClue(byte clue, ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
        if (clue < 1 || clue > 9) {
            throw new ArgumentOutOfRangeException(nameof(clue));
        }

        HorizontalClue = clue;
    }
}