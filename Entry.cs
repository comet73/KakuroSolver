namespace Kakuro;

public class Entry {

    public byte Clue {get; init;}

    public byte Cells {get; init;}

    public ISet<byte> PossibleDigits {get; init;} = new SortedSet<byte>();

    public IEnumerable<ISet<byte>> PossibleCombinations {get;init;} = new List<ISet<byte>>();

    private static readonly string[] DIGIT_WORDS = new string [] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    public Entry(byte clue, byte cells)
    {
        if (clue < 0 || clue > 45) throw new ArgumentOutOfRangeException(nameof(clue));
        if (cells < 1 || cells > 9) throw new ArgumentOutOfRangeException(nameof(cells));
        Clue = clue;
        Cells = cells;

        // In diesem Array erstellen wir verschiedene Kombinationen
        byte[] array = new byte[Cells];

        for (byte i = 1; i <= 10 - Cells; i++) {
            byte start = i;
            for (byte a = 0; a < Cells; a++) {
                array[a] = start++;
            }
            for (byte j = Cells; j > 0; j--) {
                while (array[j] < 10) {
                    var combination = new HashSet<byte>(array);
                    if (combination.Count == Cells) { // legal combination
                        Console.WriteLine(string.Join(' ', combination.Order())); // Kontrolle 
                        if (combination.Sum(i => i) == Clue) { // satisfies the clue:
                            PossibleCombinations.Append(combination);
                            break; // Weitere Permutationen auf dieser Stelle unnötig.
                        }
                    }
                    array[j]++;
                }
                array[j] = array.Min();
                array[j]++;
                if (array[j] > 9) break;
            }
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