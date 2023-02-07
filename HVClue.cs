namespace Kakuro;

public class HVClue : OpenCell {
    public byte HorizontalClue {get; init;}

    public byte VerticalClue {get; init;}

    public HVClue(byte hclue, byte vclue, ICell? horizontalNeighbor, ICell? verticalNeighbor) : base(horizontalNeighbor, verticalNeighbor)
    {
        if (hclue < 1 || hclue > 9 ) {
            throw new ArgumentOutOfRangeException(nameof(hclue));
        }
        if (vclue < 1 || vclue > 9 ) {
            throw new ArgumentOutOfRangeException(nameof(vclue));
        }

        HorizontalClue = hclue;

        VerticalClue = vclue;
    }
}