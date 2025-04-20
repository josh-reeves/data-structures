using System.Collections;

namespace LinkedList;

public class DoublyLinkedList<T> : IEnumerable
{
    #region Fields
    private Node<T>? head;
    private Node<T>? tail;

    #endregion

    #region Constructor(s)
    public DoublyLinkedList() {}

    #endregion

    #region Methods
    public void Prepend(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null) // Add first node to head if it hasn't already been initialized.
        {
            head = node;

            return;

        }

        node.Next = head;
        head.Prev = node;
        head = node;

        tail ??= head;

    }

    public void Append(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null) // Add first node to head if it hasn't already been initialized.
        {
            head = node;

            return;

        }

        tail ??= head;

        while (tail.Next != null)
            tail = tail.Next;

        tail.Next = node;
        node.Prev = tail;
    
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new LinkedListEnum(this);

    #endregion

    #region Classes and Structs
    private class LinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly DoublyLinkedList<T> list;
        private Node<T>? iterator;

        #endregion

        #region  Constructor(s)
        public LinkedListEnum(DoublyLinkedList<T> linkedList)
        {
            list = linkedList;
            iterator = list.head;

        }

        #endregion

        #region Properties
        public object? Current { get; private set; }

        #endregion

        #region Methods
        public bool MoveNext()
        {
            if (iterator is null)
                return false;

            Current = iterator.Data;

            iterator = iterator.Next;

            return true;
        
        }

        public void Reset()
        {
            iterator = list.head;

        }

        #endregion

    }

    #endregion

}


