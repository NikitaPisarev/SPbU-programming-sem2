namespace QueueTests;

using PriorityQueue;

public class QueueTests
{
    [Test]
    public void EnqueueAndDequeue_CorrectInput_CorrectResult()
    {
        var queue = new PriorityQueue<int>();
        var expected = new int[5] { 1, 2, 3, 4, 5 };

        queue.Enqueue(1, 10);
        queue.Enqueue(4, 1);
        queue.Enqueue(5, 1);
        queue.Enqueue(3, 5);
        queue.Enqueue(2, 10);

        var actual = new List<int>();
        while (!queue.Empty)
        {
            actual.Add(queue.Dequeue());
        }

        Assert.That(expected, Is.EqualTo(actual.ToArray()));
    }

    [Test]
    public void Dequeue_EmptyQueue_InvalidOperationException()
    {
        var queue = new PriorityQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
}