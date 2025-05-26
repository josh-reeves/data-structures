using System.Collections;

namespace LinkedList;

public abstract class LinkedList<TList> : ILinkedList<TList>, IEnumerable
{
    protected INode<TList>? head,
                            tail;

    public LinkedList() {}

    #region Properties
    public INode<TList>? First { get => head; }

    public INode<TList>? Last { get => tail; }

    public abstract void Remove (INode<TList> node);

    public abstract void Remove (TList value);

    public abstract void RemoveFirst();

    public abstract void RemoveLast();

    public abstract void Replace (TList oldValue, TList newValue);

    public abstract void Replace (INode<TList> oldNode, INode<TList> newNode);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

    public IEnumerator GetEnumerator() => 
        new LinkedListEnum(this);

    #endregion

    #region Classes 
    public class Node<TNode> : INode<TNode>
    {
        #region Constructor(s)
        public Node(TNode data)
        {
            Data = data;

        }

        #endregion

        #region Properties
        public INode<TNode>? Prev {get; set; }
        public INode<TNode>? Next { get; set; }
        public TNode Data { get; set; }

        #endregion
        
    }

    private class LinkedListEnum : IEnumerator
    {
        #region Fields
        private readonly LinkedList<TList> list;
        private INode<TList>? iterator;

        #endregion

        #region  Constructor(s)
        public LinkedListEnum(LinkedList<TList> linkedList)
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
