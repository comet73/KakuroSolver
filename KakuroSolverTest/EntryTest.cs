namespace KakuroSolverTest;

public class EntryTest
{
    [Fact]
    public void TestSimpleEntry()
    {
        var e = new Entry(3, 2);
        Assert.Equal(2, e.Cells);
        Assert.Equal(3, e.Clue);
        Assert.Equal(2, e.PossibleCombinations.Count());
        Assert.Equal(2, e.PossibleDigits.Count());
        Assert.True(e.PossibleDigits.Contains(1));
        Assert.True(e.PossibleDigits.Contains(2));
    }
}
