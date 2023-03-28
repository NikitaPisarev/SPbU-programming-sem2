namespace Lists;

/// <summary>
/// An exception occurs after an attempt to delete an element that does not exist.
/// </summary>
[Serializable]
public class RemoveNonexistentElementException : InvalidOperationException
{
    public RemoveNonexistentElementException() { }

    public RemoveNonexistentElementException(string message) : base(message) { }

    public RemoveNonexistentElementException(string message, Exception inner)

    : base(message, inner) { }

    protected RemoveNonexistentElementException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
    : base(info, context) { }
}