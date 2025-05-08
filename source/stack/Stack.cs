using LinkedList;

namespace Stack;

public class Stack<T>
{
    #region Fields
    private readonly DoublyLinkedList<T> linkedList;

    #endregion

    #region Constructors
    Stack()
    {
        linkedList = new DoublyLinkedList<T>();

    }

    #endregion

    #region Methods
    public void Push(T value)
    {
        linkedList.Append(value);

    }

    public void Pop()
    {
        linkedList.RemoveLast();

    }

    public T? Read()
    {
        if (linkedList.Last is not null)
            return linkedList.Last.Data;

        return default;

    }

    #endregion

}
