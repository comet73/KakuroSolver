using System.Collections.Concurrent;

namespace Kakuro;

public static class EntryFactory {

    private static readonly ConcurrentDictionary<string, Entry> _entries = new ConcurrentDictionary<string, Entry>();
    
    public static Entry Create(byte clue, byte cells) {
        string key = $"{clue}_{cells}";
        return _entries.GetOrAdd(key, key => new Entry(clue, cells));
    }
}