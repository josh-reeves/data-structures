using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace LinkedList;

public class SinglyLinkedList<T> : ILinkedList<T>, IEnumerable
{
    #region Fields
    private EqualityComparer<T> comparer;
    private INode<T>? head;
    private INode<T>? tail;

    #endregion

    #region Constructor(s)
    public SinglyLinkedList()
    {
        comparer = EqualityComparer<T>.Default;

    }

    #endregion

    #region Properties
    public INode<T>? First { get => head; }
    public INode<T>? Last { get => tail; }

    #endregion

    #region Methods
    public void Prepend(T data)
    {
        if (head == null) // Add first node to head if it hasn't already been initialized.
        {
            head = new Node<T>(data);

            return;

        }

        INode<T> temp = head;

        head = new Node<T>(data) 
        {
            Next = temp
            
        };

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

        tail.Next = new Node<T>(data);
    
    }

    public void Remove(INode<T> node)
    {
        if (head is null) // Return if the list hasn't been initialized.
            return;

        INode<T>? iterator = head,
                 previous = iterator;

        while (iterator is not null && node != iterator) // Walk list until iterator is null or we find the specified node.
        {
            previous = iterator;
            iterator = iterator.Next;

        }

        if (iterator is null)
            return;

        previous.Next = iterator.Next;
        
        if (iterator == tail)
            tail = previous;
        
    }

    public void Remove(T value)
    {
        if (head is null) // Return if the list hasn't been initialized.
            return;

        INode<T>? iterator = head,
                  previous = iterator;

        while (iterator is not null && !comparer.Equals(value, iterator.Data)) // Walk list until iterator is null or we find the specified value.
        {
            previous = iterator;
            iterator = iterator.Next;

        }

        if (iterator is null)
            return;

        previous.Next = iterator.Next;
        
        if (iterator == tail)
            tail = previous;

    }

    public void Replace(T oldValue, T newValue)
    {
        if (head is null) // Return if the list hasn't been initialized.
            return;

        INode<T>? iterator = head; // Create iterator and set it to head.

        while (iterator is not null && !comparer.Equals(oldValue, iterator.Data)) // Walk list until iterator is null or we find the specified value.
            iterator = iterator.Next;

        if (iterator is not null) // If iterator isn't null, we can assume the value was in the list and replace it.
            iterator.Data = newValue; 

    }

    public void Replace(INode<T> oldNode, INode<T> newNode)
    {
        if (head is null) // Return if the list hasn't been initialized.
            return;

        if (newNode.Next is null)
            newNode.Next = oldNode.Next;

        INode<T>? iterator = head,
                  previous = iterator; // Create iterator and set it to head.

        while (iterator.Next is not null && iterator != oldNode)
        {
            previous = iterator;
            iterator = iterator.Next;

        }

        previous.Next = newNode;

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

    public void RemoveLast()
    {
        if (head is null) // Return if the list hasn't been initialized.
            return;

        INode<T>? iterator = head; // Create iterator and set it to head.

        while (iterator.Next is not null && iterator.Next != tail) // Walk list until the next node is the tail or we reach the end.
            iterator = iterator.Next;

        tail = iterator;

    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new SinglyLinkedListEnum(this);

    #endregion

    #region Classes and Structs
    private class SinglyLinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly SinglyLinkedList<T> list;
        private INode<T>? iterator;

        #endregion

        #region  Constructor(s)
        public SinglyLinkedListEnum(SinglyLinkedList<T> linkedList)
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


