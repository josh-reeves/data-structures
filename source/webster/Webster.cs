using System.ComponentModel;
using System.Diagnostics;

namespace Webster;

public class Webster<TKey, TValue> where TKey : notnull
{
    #region Fields
    private LinkedList<KeyValuePair<TKey, TValue>>[] entries;

    #endregion

    #region  Constructor(s)
    public Webster(uint capacity = 50)
    {
        Capacity = capacity;
        
        entries = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];

    }

    #endregion

    #region Properties
    public uint Capacity { get; set; }

    #endregion

    #region Methods
    private uint Hash(TKey key) =>
        (uint)key.GetHashCode() % Capacity;

    public void Add(TKey key, TValue value)
    {
        try
        {
            uint index = Hash(key);

            entries[index] ??= new LinkedList<KeyValuePair<TKey, TValue>>();

            if (Contains(key))
            {
                Trace.WriteLine("Insertion skipped due to duplicate key");

                return;
            }

            entries[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                                    
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);

        }

    }

    public TValue? Retrieve(TKey key)
    {
        foreach (KeyValuePair<TKey, TValue> kvp in entries[Hash(key)])
            if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                return kvp.Value;

        throw new KeyNotFoundException();

    }

    public bool Contains(TKey key)
    {
        foreach (KeyValuePair<TKey, TValue> kvp in entries[Hash(key)])
            if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                return true;

        return false;

    }

    #endregion


}
