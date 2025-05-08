using LinkedList;

namespace Queue;

public class Queue<T>
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
    public void Enqueue(T value)
    {
        linkedList.Append(value);

    }

    public void Dequeue()
    {
        linkedList.RemoveFirst();

    }

    public T? Read()
    {
        if (linkedList.First is not null)
            return linkedList.First.Data;

        return default;

    }

    #endregion

}
