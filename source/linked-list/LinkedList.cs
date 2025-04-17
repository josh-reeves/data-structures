using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace LinkedList;

public class LinkedList<T> : IEnumerable
{
    private Node<T>? head;
    private Node<T>? tail;

    public LinkedList() {}

    public void Prepend(T Data)
    {


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

    private class LinkedListEnum : IEnumerator
    {
        LinkedList<T> list;
        Node<T>? iterator;

        public LinkedListEnum(LinkedList<T> linkedList)
        {
            list = linkedList;
            iterator = list.head;

        }

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

        public object? Current { get; private set; }

    }

}


