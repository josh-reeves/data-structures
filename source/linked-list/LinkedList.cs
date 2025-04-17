using System.Collections;

namespace LinkedList;

public class LinkedList<T> : IEnumerable
{
    #region Fields
    private Node<T>? head;
    private Node<T>? tail;

    #endregion

    #region Constructor(s)
    public LinkedList() {}

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
        private readonly LinkedList<T> list;
        private Node<T>? iterator;

        #endregion

        #region  Constructor(s)
        public LinkedListEnum(LinkedList<T> linkedList)
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


