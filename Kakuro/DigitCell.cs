using System.Collections.Generic;
using System.Collections.Immutable;


namespace Kakuro;

public class DigitCell : OpenCell
{
    IReadOnlySet<byte> PossibleDigits => _possibleDigits.ToImmutableHashSet();
    ISet<byte> _possibleDigits = new HashSet<byte>();

    public DigitCell(ICell? horizontal, ICell? vertical) : base(horizontal, vertical)
    {
        _possibleDigits = new HashSet<byte>(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});
    }

    public void RemoveDigit (byte digit) {
        _possibleDigits.Remove(digit);

        if (_possibleDigits.Count < 1) {
            throw new InvalidOperationException("This cell contains no more digits");
        }
    }

    public bool IsFixed { 
        get {
            return _possibleDigits.Count == 1;
        }
    }

    public byte Value {
        get {
            if (this.IsFixed) {
                return _possibleDigits.First();
            }

            throw new InvalidDataException("This cell is not fixed!");
        }
    }
}