
namespace LinkedList;

public interface ILinkedList<T>
{
    public INode<T>? First { get; }
    public INode<T>? Last { get; }

    public void Append(INode<T> node);

    public void Append(T value);

    public void Remove(INode<T> node);

    public void Remove(T value);

    public void Replace (T oldValue, T newValue);

    public void Replace(INode<T> oldNode, INode<T> newNode);

    public void RemoveFirst();

    public void RemoveLast();

}