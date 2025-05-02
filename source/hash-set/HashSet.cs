using System.Collections;
using System.Diagnostics;
using LinkedList;

namespace HashSet;

public class HashSet<TValue> : IEnumerable
{
    #region Fields
    private double loadFactor;

    private DoublyLinkedList<TValue>[] entries; // Internal data structure (i.e. "buckets").

    #endregion

    #region Constructor(s)
    public HashSet(uint initialCapacity = 2)
    {
        entries = new DoublyLinkedList<TValue>[initialCapacity];

    }

    #endregion

    #region Properites
    /// <summary>
    /// The total number of elements in the set.
    /// </summary>
    public int Count{ get; private set; }

    /// <summary>
    /// The capacity of the internal data structure. Setting will trigger a rehash.
    /// </summary>
    public uint Capacity
    {
        get => (uint)(entries?.Length ?? 0);

        set
        {
            if (value == Capacity) // No point in rehashing if the capacity didn't actually change.
                return;

            if (entries is null)
            {
                entries = new DoublyLinkedList<TValue>[value];

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
        DoublyLinkedList<TValue>[] temp = new DoublyLinkedList<TValue>[newCapacity];

        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i] is not null)
                foreach (TValue entry in entries[i])
                {
                    temp[(uint)entry.GetHashCode() % newCapacity] ??= new DoublyLinkedList<TValue>();

                    temp[(uint)entry.GetHashCode() % newCapacity].Append(entry);

                }

        }
                
        entries = temp;

    }

    /// <summary>
    /// Obtains the hashcode of the specified value using .GetHashCode() and then returns the remainder of the hash code divided by the capacity of the internal data structure.
    /// If the value is null, 0 is used for the hash, as null cannot have an implementation of .GetHashCode(); 
    /// </summary>
    /// <param name="value">The value to index.</param>
    /// <returns>The index of the internal data sctructure in which the provided value will be stored.</returns>
    private uint Index(TValue value) =>
        value == null ? 0 : (uint)value.GetHashCode() % (uint)entries.Length;

    /// <summary>
    /// Adds a new value to the set, checking to ensure that the value is unique and discarding it otherwise.
    /// </summary>
    /// <param name="value">The value to add to the set.</param>
    public void Add(TValue value)
    {
        try
        {
            entries[Index(value)] ??= new DoublyLinkedList<TValue>();

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

    public TValue? Retrieve(TValue value)
    {
        foreach (TValue entry in entries[Index(value)])
            if (EqualityComparer<TValue>.Default.Equals(entry, value))
                return entry;

        throw new KeyNotFoundException();

    }

    public void Remove(TValue value)
    {
        entries[Index(value)].Remove(value);
    
    }

    /// <summary>
    /// Checks whether or not the provided value is contained within the set.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if the provided value is contained within the set. Otherwise false.</returns>
    public bool Contains(TValue value)
    {
        foreach (TValue entry in entries[Index(value)])
            if (EqualityComparer<TValue>.Default.Equals(entry, value))
                return true;

        return false;

    }

    public IEnumerator GetEnumerator() => 
        new HashSetEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => 
        (IEnumerator) GetEnumerator();

    #endregion

    #region Classes and Structs
    private class HashSetEnumerator : IEnumerator
    {
        #region Fields
        private int index;

        private Node<TValue>? iterator;
        private HashSet<TValue> set;

        #endregion

        #region Constructor
        public HashSetEnumerator(HashSet<TValue> hashSet)
        {
            index = 0;

            set = hashSet;

        }

        #endregion

        #region Properties
        public object? Current { get; set; }

        #endregion

        #region Methods
        public bool MoveNext()
        {
            while (index < set.entries.Length && set.entries[index] is null)
                index ++;

            if (index >= set.entries.Length)
                return false;

            iterator ??= set.entries[index].First ?? throw new NullReferenceException();

            Current = iterator.Data;

            iterator = iterator.Next;

            if (iterator is null)
                index ++;

            return true;

        }

        public void Reset()
        {
            index = 0;
            iterator = null;

        }

        #endregion

    }

    #endregion

}
