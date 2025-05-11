namespace Queue;

public interface IQueue<T>
{
    public void Enqueue(T value);

    public T? Dequeue();

    public T? Peek();

}