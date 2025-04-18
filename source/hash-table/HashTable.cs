using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HashTable;

public class HashTable<TKey, TValue> where TKey : notnull
{
    #region Fields
    private int elements;
    private double loadFactor;

    private LinkedList.LinkedList<Entry>[] entries;
    
    #endregion

    public HashTable(uint capacity = 4)
    {
        Capacity = capacity;
        entries = new LinkedList.LinkedList<Entry>[Capacity];

    }

    public uint Capacity { get; set; }

    private void Rehash()
    {
        Capacity = Convert.ToUInt32(entries.Length * 2);

        LinkedList.LinkedList<Entry>[] temp = new LinkedList.LinkedList<Entry>[Capacity];

        for (int i = 0; i < entries.Length - 1; i++)
        {
            if (entries[i] is not null)
                foreach (Entry entry in entries[i])
                {
                    temp[Index(entry.Key)] ??= new LinkedList.LinkedList<Entry>();

                    temp[Index(entry.Key)].Append(entry);

                }
        }
                
        entries = temp;

    }

    private uint Index(TKey key) =>
        (uint)key.GetHashCode() % Capacity;

    public void Add(TKey key, TValue value)
    {
        try
        {
            entries[Index(key)] ??= new LinkedList.LinkedList<Entry>();

            if (Contains(key))
            {
                Trace.WriteLine("Insertion skipped due to duplicate key");

                return;
            }

            entries[Index(key)].Append(new Entry(key, value));

            elements ++;

            loadFactor = elements / entries.Length; 

            if (loadFactor > 0.75)
                Rehash();
                 
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);

        }

    }

    public TValue? Retrieve(TKey key)
    {
        foreach (Entry entry in entries[Index(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return entry.Value;

        throw new KeyNotFoundException();

    }

    public bool Contains(TKey key)
    {
        foreach (Entry entry in entries[Index(key)])
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
