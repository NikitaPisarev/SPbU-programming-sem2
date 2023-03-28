namespace Lists;

/// <summary>
/// An exception occurs after an attempt to add an element that already exists.
/// </summary>
[Serializable]
public class ElementAlreadyExistException : InvalidOperationException
{
    public ElementAlreadyExistException() { }

    public ElementAlreadyExistException(string message) : base(message) { }

    public ElementAlreadyExistException(string message, Exception inner)

    : base(message, inner) { }

    protected ElementAlreadyExistException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
    : base(info, context) { }
}