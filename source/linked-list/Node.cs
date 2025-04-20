namespace LinkedList;

public class Node<T>
{
    #region Constructor(s)
    public Node(T data)
    {
        Data = data;

    }

    #endregion

    #region Properties
    public Node<T>? Prev {get; set; }
    public Node<T>? Next { get; set; }
    public T Data { get; set;}

    #endregion
    
}