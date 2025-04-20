using System.Diagnostics;
using LinkedList;

namespace HashTable;

public class HashTable<TKey, TValue> where TKey : notnull
{
    #region Fields
    private double loadFactor;

    private SinglyLinkedList<Entry>[] entries;
    
    #endregion

    #region Constructor(s)
    public HashTable(uint initialCapacity = 2)
    {
        entries = new SinglyLinkedList<Entry>[initialCapacity];

    }

    #endregion

    #region Properites
    public int Count { get; private set; }

    public uint Capacity
    {
        get => (uint)(entries?.Length ?? 0);

        set
        {
            if (value == Capacity) // No point in rehashing if the capacity didn't actually change.
                return;

            if (entries is null)
            {
                entries = new SinglyLinkedList<Entry>[value];

                return;

            }
            
            Rehash(value); // Rehash table to maintain performance whenever a new capacity is externally set.

        }

    }

    public TValue? this [TKey key] 
    {
        get => GetValue(key);

    }

    #endregion

    #region Methods
    /// <summary>
    /// Resizes the internal data-structure and redistributes its existing elements accordingly. This is prevents the linked-list in each "bucket" of entries from becoming too long, which would negatively impact performance.
    /// </summary>
    /// <param name="newCapacity">
    /// The new capacity for the data table.
    /// </param>
    private void Rehash(uint newCapacity)
    {
        SinglyLinkedList<Entry>[] temp = new SinglyLinkedList<Entry>[newCapacity];

        for (int i = 0; i < entries.Length - 1; i++)
        {
            if (entries[i] is not null)
                foreach (Entry entry in entries[i])
                {
                    temp[(uint)entry.Key.GetHashCode() % newCapacity] ??= new SinglyLinkedList<Entry>();

                    temp[(uint)entry.Key.GetHashCode() % newCapacity].Append(entry);

                }

        }
                
        entries = temp;

    }

    /// <summary>
    /// Obtains the hashcode of the specified key using .GetHashCode() and then returns the remainder of the hash code divided by the capacity of the internal data structure.
    /// </summary>
    /// <param name="key">The key to index.</param>
    /// <returns>
    /// The index of the internal data structure in which to store the key and value.
    /// </returns>
    private uint Index(TKey key) =>
        (uint)key.GetHashCode() % (uint)entries.Length;

    /// <summary>
    /// Adds a new key value pair to the data structure, checking to confirm that the key is unique.
    /// </summary>
    /// <param name="key">The key to add to the hash table.</param>
    /// <param name="value">The value to add to the hash table.</param>
    public void Add(TKey key, TValue value)
    {
        try
        {
            entries[Index(key)] ??= new SinglyLinkedList<Entry>();

            if (Contains(key))
            {
                Trace.WriteLine("Insertion skipped due to duplicate key");

                return;

            }

            entries[Index(key)].Append(new Entry(key, value));

            Count ++;

            loadFactor = Count / entries.Length; 

            if (loadFactor > 0.75)
                Rehash(Convert.ToUInt32(entries.Length * 2));
                 
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);

        }

    }

    public bool Contains(TKey key)
    {
        foreach (Entry entry in entries[Index(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return true;

        return false;

    }

    public TValue? GetValue(TKey key)
    {
        foreach (Entry entry in entries[Index(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return entry.Value;

        throw new KeyNotFoundException();

    }

    public TValue? GetKey(TKey key)
    {
        foreach (Entry entry in entries[Index(key)])
            if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                return entry.Value;

        throw new KeyNotFoundException();

    }

    #endregion

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
