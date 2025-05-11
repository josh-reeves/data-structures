using LinkedList;

namespace Stack;

public class Stack<T> : IStack<T>
{
    #region Fields
    private readonly DoublyLinkedList<T> linkedList;

    #endregion

    #region Constructors
    public Stack()
    {
        linkedList = new DoublyLinkedList<T>();

    }

    #endregion

    #region Methods
    /// <summary>
    /// Adds a new value to the top of the stack.
    /// </summary>
    /// <param name="value">The value to add to the stack.</param>
    public void Push(T value)
    {
        linkedList.Append(value);

    }

    /// <summary>
    /// Removes the top value from the stack.
    /// </summary>
    public T? Pop()
    {
        if (linkedList.Last is null)
            return default;

        T? value = linkedList.Last.Data;

        linkedList.RemoveLast();

        return value;

    }

    /// <summary>
    /// Reads the top value from the stack.
    /// </summary>
    /// <returns>The top value from the stack.</returns>
    public T? Peek()
    {
        if (linkedList.Last is null)
            return default;

        return linkedList.Last.Data;

    }

    #endregion

}
