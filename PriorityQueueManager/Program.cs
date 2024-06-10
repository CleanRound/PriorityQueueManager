public class PriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> _queues;
    private int _count;

    public PriorityQueue()
    {
        _queues = new SortedDictionary<int, Queue<T>>();
        _count = 0;
    }

    public void Enqueue(T item, int priority)
    {
        if (!_queues.ContainsKey(priority))
        {
            _queues[priority] = new Queue<T>();
        }

        _queues[priority].Enqueue(item);
        _count++;
    }

    public T Dequeue()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
            {
                _count--;
                return queue.Value.Dequeue();
            }
        }

        throw new InvalidOperationException("The queue is empty.");
    }

    public T Peek()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
            {
                return queue.Value.Peek();
            }
        }

        throw new InvalidOperationException("The queue is empty.");
    }

    public int Count
    {
        get { return _count; }
    }

    public bool IsEmpty
    {
        get { return _count == 0; }
    }
}


class Program
{
    static void Main()
    {
        var pq = new PriorityQueue<string>();

        pq.Enqueue("Low priority task", 3);
        pq.Enqueue("Medium priority task", 2);
        pq.Enqueue("High priority task", 1);

        Console.WriteLine($"Peek: {pq.Peek()}");
        Console.WriteLine($"Dequeue: {pq.Dequeue()}");
        Console.WriteLine($"Dequeue: {pq.Dequeue()}");
        Console.WriteLine($"Dequeue: {pq.Dequeue()}");

        Console.WriteLine($"IsEmpty: {pq.IsEmpty}");
    }
}
