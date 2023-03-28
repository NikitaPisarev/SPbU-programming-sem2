namespace Lists;

/// <summary>
/// List data structure that does not store duplicate value.
/// </summary>
public class UniqueList : List
{
    private bool _contains(int value)
    {
        if (Head is null)
        {
            return false;
        }

        var currentNode = Head;
        while (currentNode.Value != value && currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value == value;
    }

    /// <summary>
    /// Method of adding an element to the list.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <exception cref="ElementAlreadyExistException"> This element is already in the list. </exception>
    public override void Add(int value)
    {
        if (_contains(value))
        {
            throw new ElementAlreadyExistException();
        }

        base.Add(value);
    }

    /// <summary>
    /// The method replaces the element under the index "index" with the value "value".
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <param name="index"> The index. </param>
    /// <returns> If the replacement is successful, it returns True, otherwise False. </returns>
    /// <exception cref="ElementAlreadyExistException"> This element is already in the list. </exception>
    public override bool Replace(int value, int index)
    {
        if (_contains(value))
        {
            throw new ElementAlreadyExistException();
        }

        return base.Replace(value, index);
    }

    /// <summary>
    /// Method for getting all the items in the list.
    /// </summary>
    /// <returns> Array of elements. </returns>
    public int[] GetList()
    {
        var result = new List<int>();
        var currentNode = Head;
        while (currentNode != null)
        {
            result.Add(currentNode.Value);
            currentNode = currentNode.Next;
        }

        return result.ToArray();
    }
}