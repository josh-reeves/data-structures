using System.Diagnostics;
using LinkedList;

namespace HashSet;

public class HashSet<TValue>
{
    #region Fields
    private double loadFactor;

    private SinglyLinkedList<TValue>[] entries; // Internal data structure (i.e. "buckets").
    
    #endregion

    #region Constructor(s)
    public HashSet(uint initialCapacity = 2)
    {
        entries = new SinglyLinkedList<TValue>[initialCapacity];

    }

    #endregion

    #region Properites
    public int Count{ get; private set; }

    public uint Capacity
    {
        get => (uint)(entries?.Length ?? 0);

        set
        {
            if (value == Capacity) // No point in rehashing if the capacity didn't actually change.
                return;

            if (entries is null)
            {
                entries = new SinglyLinkedList<TValue>[value];

                return;

            }
            
            Rehash(value); // Rehash table to maintain performance whenever a new capacity is externally set.

        }

    }

    #endregion

    #region Methods
    /// <summary>
    /// Resizes the internal data-structure and redistributes its existing elements accordingly. This is prevents the linked-list in each "bucket" from becoming too long, which would negatively impact performance.
    /// </summary>
    /// <param name="newCapacity">
    /// The new capacity for the data table.
    /// </param>
    private void Rehash(uint newCapacity)
    {
        SinglyLinkedList<TValue>[] temp = new SinglyLinkedList<TValue>[newCapacity];

        for (int i = 0; i < entries.Length - 1; i++)
        {
            if (entries[i] is not null)
                foreach (TValue entry in entries[i])
                {
                    temp[(uint)entry.GetHashCode() % newCapacity] ??= new SinglyLinkedList<TValue>();

                    temp[(uint)entry.GetHashCode() % newCapacity].Append(entry);

                }

        }
                
        entries = temp;

    }


    /// <summary>
    /// Obtains the hashcode of the specified value using .GetHashCode() and then returns the remainder of the hash code divided by the capacity of the internal data structure.
    /// If the value is null, 0 is used for the hash, as null cannot have an implementation of .GetHashCode(); 
    /// </summary>
    /// <param name="value"></param>
    /// The value to index.
    /// <returns></returns>
    private uint Index(TValue value) =>
        value == null ? 0 : (uint)value.GetHashCode() % (uint)entries.Length;

    public void Add(TValue value)
    {
        try
        {
            entries[Index(value)] ??= new SinglyLinkedList<TValue>();

            if (Contains(value))
            {
                Trace.WriteLine("Insertion skipped due to duplicate key");

                return;

            }

            entries[Index(value)].Append(value);

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

    public bool Contains(TValue value)
    {
        foreach (TValue entry in entries[Index(value)])
            if (EqualityComparer<TValue>.Default.Equals(entry, value))
                return true;

        return false;

    }

    public TValue? Retrieve(TValue value)
    {
        foreach (TValue entry in entries[Index(value)])
            if (EqualityComparer<TValue>.Default.Equals(entry, value))
                return entry;

        return default;

    }

    #endregion


}
