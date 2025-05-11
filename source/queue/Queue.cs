using LinkedList;

namespace Queue;

public class Queue<T> : IQueue<T>
{
    #region Fields
    private DoublyLinkedList<T> linkedList;

    #endregion

    #region Constructor(s)
    public Queue()
    {
        linkedList = new DoublyLinkedList<T>();

    }

    #endregion

    #region Methods
    /// <summary>
    /// Adds a new value to the end of the queue.
    /// </summary>
    /// <param name="value">The value to be enqueued</param>
    public void Enqueue(T value) =>
        linkedList.Append(value);

    /// <summary>
    /// Removes the value at the front of the queue.
    /// </summary>
    public T? Dequeue()
    {
        if (linkedList.First is null)
            return default;

        T? value = linkedList.First.Data;

        linkedList.RemoveFirst();

        return value;
        
    }

    /// <summary>
    /// Reads the value at the front of the queue.
    /// </summary>
    /// <returns>The value at the front of the stack</returns>
    public T? Peek()
    {
        if (linkedList.First is  null)
            return default;

        return linkedList.First.Data;

    }

    #endregion

}
