using System.ComponentModel;
using System.Diagnostics;

namespace Oxford;

public class Oxford<TKey, TValue> where TKey : notnull
{
    private LinkedList.LinkedList<Entry>[] entries;
    
    public Oxford(uint capacity = 50)
    {
        Capacity = capacity;

        entries = new LinkedList.LinkedList<Entry>[Capacity];

    }

    public uint Capacity { get; set; }

    private uint Hash(TKey key)
    {
        uint hash = (uint)key.GetHashCode() % Capacity;

        return hash;

    }

    public void Add(TKey key, TValue value)
    {
        try
        {
            entries[Hash(key)] ??= new LinkedList.LinkedList<Entry>();

            if (Contains(key))
            {
                Trace.WriteLine("Insertion skipped due to duplicate key");

                return;
            }

            entries[Hash(key)].Append(new Entry(key, value));
                 
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);

        }

    }

    public TValue? Retrieve(TKey key)
    {
        foreach (Entry entry in entries[Hash(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return entry.Value;

        throw new KeyNotFoundException();

    }

    public bool Contains(TKey key)
    {
        foreach (Entry entry in entries[Hash(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return true;

        return false;

    }

    #region Classes & Structs
    public struct Entry
    {
        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;

        }

        public TKey Key { get; set ;}
        public TValue Value { get; set; }

    }

    #endregion

}
