using System.Collections;

namespace LinkedList;

public abstract class LinkedList<ListType> : ILinkedList<ListType>, IEnumerable
{
    protected INode<ListType>? head,
                            tail;

    public LinkedList() {}

    #region Properties
    public INode<ListType>? First { get => head; }

    public INode<ListType>? Last { get => tail; }

    public abstract void Append(INode<ListType> node);

    public abstract void Append(ListType value);

    public abstract void Remove(INode<ListType> node);

    public abstract void Remove (ListType value);

    public abstract void RemoveFirst();

    public abstract void RemoveLast();

    public abstract void Replace (ListType oldValue, ListType newValue);

    public abstract void Replace (INode<ListType> oldNode, INode<ListType> newNode);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new LinkedListEnum(this);

    #endregion

    #region Classes 
    public class Node<NodeType> : INode<NodeType>
    {
        #region Constructor(s)
        public Node(NodeType data)
        {
            Data = data;

        }

        #endregion

        #region Properties
        public INode<NodeType>? Prev {get; set; }
        public INode<NodeType>? Next { get; set; }
        public NodeType Data { get; set; }

        #endregion
        
    }

    private class LinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly LinkedList<ListType> list;
        private INode<ListType>? iterator;

        #endregion

        #region  Constructor(s)
        public LinkedListEnum(LinkedList<ListType> linkedList)
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
