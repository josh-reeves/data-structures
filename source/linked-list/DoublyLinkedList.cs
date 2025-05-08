using System.Collections;

namespace LinkedList;

public class DoublyLinkedList<T> : ILinkedList<T>, IEnumerable
{
    #region Fields
    private EqualityComparer<T> comparer;
    private INode<T>? head;
    private INode<T>? tail;

    #endregion

    #region Constructor(s)
    public DoublyLinkedList()
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

        temp.Prev = head;

        tail ??= head;

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

        INode<T> temp = tail;

        tail.Next = new Node<T>(data)
        {
            Prev = tail

        };

        tail = tail.Next;

        tail.Prev = temp;
    
    }

    public void Remove(INode<T> node)
    {
        if (node == head)
        {
            RemoveFirst();

            return;
            
        }

        if (node == tail)
        {
            RemoveLast();

            return;

        }

        if (node.Next is not null)
            node.Next.Prev = node.Prev;

        if (node.Prev is not null)
            node.Prev.Next = node.Next;

    }

    public void Remove(T value)
    {        
        if (head is null)
            return;

        INode<T>? iterator = head;

        while (iterator is not null && !comparer.Equals(value, iterator.Data))
            iterator = iterator.Next;
        
        if (iterator is not null)
            Remove(iterator);

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

    public void Replace (INode<T> oldNode, INode<T> newNode)
    {
        // Uncommenting null assignment operator will allow the Next and Previous values from newNode to be used, but could result in loops.
        newNode.Prev /*??*/= oldNode.Prev; 
        newNode.Next /*??*/= oldNode.Next;

        if (newNode.Prev is not null)
            newNode.Prev.Next = newNode;
        else
            head = newNode;
        
        if (newNode.Next is not null)
            newNode.Next.Prev = newNode;
        else
            tail = newNode;

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
        if (head is null || tail is null)
            return;

        if (tail.Prev is not null)
        {
            tail = tail.Prev;

            return;
        }

        tail = null;

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
        private INode<T>? iterator;

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


