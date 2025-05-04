namespace LinkedList;

public interface INode<T>
{
    public INode<T>? Prev { get; set; }
    public INode<T>? Next { get; set; }
    public T Data { get; set; }

}