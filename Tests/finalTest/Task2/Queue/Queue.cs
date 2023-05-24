namespace PriorityQueue;

/// <summary>
/// Priority queue with generic type.
/// </summary>
/// <typeparam name="T"> Type of queue elements.</typeparam>
public class PriorityQueue<T>
{
    private QueueElement? _head;

    private class QueueElement
    {
        public QueueElement(T value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
        }

        public T Value { get; private set; }

        public int Priority { get; private set; }

        public QueueElement? NextElement { get; set; }
    }

    /// <summary>
    /// Method to add value to priority queue.
    /// </summary>
    /// <param name="value"> Value. </param>
    /// <param name="priority"> Priority of value. </param>
    public void Enqueue(T value, int priority)
    {
        var newElement = new QueueElement(value, priority);

        if (_head is null)
        {
            _head = newElement;
            return;
        }

        var elementToAddTheCurrentOneAfter = LastElementWithPriorityNotLessThanGiven(priority);

        if (elementToAddTheCurrentOneAfter == null)
        {
            newElement.NextElement = _head;
            _head = newElement;
        }
        else
        {
            newElement.NextElement = elementToAddTheCurrentOneAfter.NextElement;
            elementToAddTheCurrentOneAfter.NextElement = newElement;
        }
    }

    /// <summary>
    /// Method for getting the item with the highest priority from the queue.
    /// </summary>
    /// <returns> The value of the element with the highest priority. </returns>
    /// <exception cref="InvalidOperationException"> Сannot get an value from an empty queue. </exception>
    public T Dequeue()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Cannot get an value from an empty queue.");
        }

        var result = _head.Value;
        _head = _head.NextElement;

        return result;
    }

    /// <summary>
    /// Checking if the queue is empty.
    /// </summary>
    public bool Empty => _head is null;

    private QueueElement? LastElementWithPriorityNotLessThanGiven(int priority)
    {
        if (_head is null)
        {
            return null;
        }

        var currentElement = _head;
        QueueElement? previousElement = null;

        while (currentElement != null && currentElement.Priority >= priority)
        {
            previousElement = currentElement;
            currentElement = currentElement.NextElement;
        }

        return previousElement;
    }
}
