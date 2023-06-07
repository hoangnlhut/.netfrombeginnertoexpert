public class SimpleQueue<T>
{
    private readonly T[] _queueArray;
    private int _indexCurrent = -1;

    public int Count => _indexCurrent + 1;
    public SimpleQueue()
    {
        _queueArray = new T[10];
    }

    public void Push(T item)
    {
        _queueArray[++_indexCurrent] = item;
    }

    public T Pop(int index)
    {
        return _queueArray[index];
    }


}