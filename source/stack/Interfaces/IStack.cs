namespace Stack;

public interface IStack<T>
{
    public void Push(T value);

    public T? Pop();

    public T? Peek();

}