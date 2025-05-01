using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    #region Properties
    public Node<T>? First { get => head; }
    public Node<T>? Last { get => tail; }

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

        temp.Prev = head;

    }

    public void Append(T data)
    {
        if (head is null) // Add first node to head if it hasn't already been initialized.
        {
            head = new Node<T>(data);

            return;

        }

        tail ??= head;

        while (tail.Next != null)
            tail = tail.Next;

        Node<T> temp = tail;

        tail.Next = new Node<T>(data)
        {
            Prev = tail

        };

        tail = tail.Next;

        tail.Prev = temp;
    
    }

    public void Remove(Node<T> node)
    {
        if (node.Next is not null)
            node.Next.Prev = node.Prev;

        if (node.Prev is not null)
            node.Prev.Next = node.Next;

    }

    public void Remove(T value)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        
        if (head is null)
            return;

        if (comparer.Equals(value, head.Data))
        {
            RemoveFirst();

            return;
            
        }

        Node<T>? iterator = head;

        while (!EqualityComparer<T>.Default.Equals(value, iterator.Data) && iterator.Next is not null)
            iterator = iterator.Next;
        
        Remove(iterator);

    }

    public void RemoveFirst()
    {
        if (head is null)
            return;

        if (head.Next is not null)
        {
            head = head.Next;

            return;
        }

        head = null;

    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new DoublyLinkedListEnum(this);

    #endregion

    #region Classes and Structs
    private class DoublyLinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly DoublyLinkedList<T> list;
        private Node<T>? iterator;

        #endregion

        #region  Constructor(s)
        public DoublyLinkedListEnum(DoublyLinkedList<T> linkedList)
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


