namespace Lists;

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

    public override void Add(int value)
    {
        if (_contains(value))
        {
            throw new ElementAlreadyExistException();
        }

        base.Add(value);
    }

    public override bool Replace(int value, int index)
    {
        if (_contains(value))
        {
            throw new ElementAlreadyExistException();
        }

        return base.Replace(value, index);
    }

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