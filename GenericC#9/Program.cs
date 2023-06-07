public class Program
{
    private static void Main(string[] args)
    {
        //StackDouble();
        //StackString();
        //StackInt();
        QueueInt();
        QueueString();
    }

    private static void QueueInt()
    {
        Console.WriteLine("Simple Queue in int");
        var queueInt = new SimpleQueue<int>();
        queueInt.Push(5);
        queueInt.Push(10);
        queueInt.Push(15);

        int sumInt = 0;

        for (int i = 0; i < queueInt.Count; i++) {
            int itemInt = queueInt.Pop(i);
            Console.WriteLine($"Item poped: {itemInt}");
            sumInt += itemInt;
        }
        Console.WriteLine($"Sum: {sumInt}");
        Console.WriteLine("--------End of Simple Queue in int---------");
    }

    private static void QueueString()
    {
        Console.WriteLine("Simple Queue in string");
        var queue = new SimpleQueue<string>();
        queue.Push("Nguyen");
        queue.Push("Le");
        queue.Push("Hoang");

        string sumString = "";

        for (int i = 0; i < queue.Count; i++)
        {
            string item = queue.Pop(i);
            Console.WriteLine($"Item poped: {item}");
            sumString += item + " ";
        }
        Console.WriteLine($"Sum: {sumString}");
        Console.WriteLine("--------End of Simple Queue in string---------");
    }

    private static void StackInt()
    {
        Console.WriteLine("Simple Stack in int");
        var stackInt = new Stack<int>();
        stackInt.Push(5);
        stackInt.Push(10);
        stackInt.Push(15);

        int sumInt = 0;

        while (stackInt.Count > 0)
        {
            int itemInt = stackInt.Pop();
            Console.WriteLine($"Item poped: {itemInt}");
            sumInt += itemInt;
        }

        Console.WriteLine($"Sum: {sumInt}");
        Console.WriteLine("--------End of Simple Stack in int---------");
    }

    private static void StackString()
    {
        Console.WriteLine("Simple Stack in string");
        var stackString = new Stack<string>();
        stackString.Push("Hoang");
        stackString.Push("Trang");
        stackString.Push("Viet");

        string sumString = "";

        while (stackString.Count > 0)
        {
            string itemString = stackString.Pop();
            Console.WriteLine($"Item poped: {itemString}");
            sumString += itemString + " ";
        }

        Console.WriteLine($"Sum: {sumString}");
        Console.WriteLine("--------End of Simple Stack in string---------");
    }

    private static void StackDouble()
    {
        Console.WriteLine("Simple Stack in double");
        var stack = new Stack<double>();
        stack.Push(1.2);
        stack.Push(2.4);
        stack.Push(4.0);

        double sum = 0;

        while (stack.Count > 0)
        {
            double item = stack.Pop();
            Console.WriteLine($"Item poped: {item}");
            sum += item;
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine("--------End of Simple Stack in double---------");
    }
}