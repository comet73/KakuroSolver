namespace Kakuro;

public class Entry {

    public byte Clue {get; init;}

    public byte Cells {get; init;}

    public ISet<byte> PossibleDigits {get; init;} = new SortedSet<byte>();

    public IList<IList<byte>> PossibleCombinations {get;init;} = new List<IList<byte>>();

    private static readonly string[] DIGIT_WORDS = new string [] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    public Entry(byte clue, byte cells)
    {
        if (clue < 0 || clue > 45) throw new ArgumentOutOfRangeException(nameof(clue));
        if (cells < 1 || cells > 9) throw new ArgumentOutOfRangeException(nameof(cells));
        Clue = clue;
        Cells = cells;

        // In diesem Array erstellen wir verschiedene Kombinationen
        byte[] array = new byte[Cells];

        // Hier zählen wir pro Stelle welche Ziffer wir gerade probieren.
        byte[] iteration = new byte[Cells];
        for (var i = 0; i < iteration.Length; i++) iteration[i] = 0;

        var index = 0;
        var availableDigits = new SortedSet<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        while (index < Cells)
        {
            iteration[index]++;
            if (iteration[index] > 9)
            {
                iteration[index] = 0;
                index--;
                if (index < 0)
                    break;
                else
                    continue;
            }
            if (availableDigits.Contains(iteration[index]))
            {
                if (array[index] > 0) availableDigits.Add(array[index]);
                array[index] = iteration[index];
                availableDigits.Remove(iteration[index]);
            } else
            {
                continue; // An gleicher Stelle nächste Ziffer probieren
            }
            if (index == Cells-1)
            {
                var sum = array.Sum(x => x);
                if (sum == Clue)
                {
                    var combination = new List<byte>(array);
                    PossibleCombinations.Add(combination);
                }
                else if (sum > Clue)
                {
                    // Mit der aktuellen Ziffer an dieser Stelle schon zu groß, können den Rest überspringen.
                    iteration[index] = 9;
                }
                continue; // An gleicher Stelle nächste Ziffer probieren
            }
            index++; // Weiter zur nächsten Stelle, wir sind noch nicht am Ende.
        }

        foreach (var c in PossibleCombinations) {
            PossibleDigits.UnionWith(c);
        }
    }

    public override string ToString() {
        if (Clue >= 43) {
            return $"{Clue}";
        }

        return $"{Clue}-in-{DIGIT_WORDS[Cells]}";
    }
}