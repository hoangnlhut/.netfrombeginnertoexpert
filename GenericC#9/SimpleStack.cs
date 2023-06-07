using System.Transactions;

public class SimpleStack<T>
{
    public readonly T[] _item;
    private int _currentIndex = -1;
    public SimpleStack()
    {
        _item = new T[10];
    }

    public void Push(T item)
    {
        _item[++_currentIndex] = item;
    }

    public int Count
    {
        get { return _currentIndex + 1; }
    } 
   
    public T Pop()
    { 
        return _item[_currentIndex--]; 
    }

}