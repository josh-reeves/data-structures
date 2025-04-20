using System.Collections;

namespace LinkedList;

public class SinglyLinkedList<T> : IEnumerable
{
    #region Fields
    private Node<T>? head;
    private Node<T>? tail;

    #endregion

    #region Constructor(s)
    public SinglyLinkedList() {}

    #endregion

    #region Methods
    public void Prepend(T data)
    {
        if (head == null) // Add first node to head if it hasn't already been initialized.
        {
            head = new Node<T>(data);

            return;

        }

        Node<T> temp = head;

        head = new Node<T>(data) 
        {
            Next = temp
            
        };

    }

    public void Append(T data)
    {
        if (head == null) // Add first node to head if it hasn't already been initialized.
        {
            head = new Node<T>(data);

            return;

        }

        if (tail is null)
            tail = head;

        while (tail.Next != null)
            tail = tail.Next;

        tail.Next = new Node<T>(data);
    
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new LinkedListEnum(this);

    #endregion

    #region Classes and Structs
    private class LinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly SinglyLinkedList<T> list;
        private Node<T>? iterator;

        #endregion

        #region  Constructor(s)
        public LinkedListEnum(SinglyLinkedList<T> linkedList)
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


