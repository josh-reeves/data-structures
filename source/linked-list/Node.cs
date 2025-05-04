namespace LinkedList;

public class Node<T> : INode<T>
{
    #region Constructor(s)
    public Node(T data)
    {
        Data = data;

    }

    #endregion

    #region Properties
    public INode<T>? Prev {get; set; }
    public INode<T>? Next { get; set; }
    public T Data { get; set;}

    #endregion
    
}