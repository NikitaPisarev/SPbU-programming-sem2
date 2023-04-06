namespace MapFilterFold;

public static class MapFilterFold
{
    public static List<TOut> Map<TInp, TOut>(List<TInp> list, Func<TInp, TOut> function)
    {
        var result = new List<TOut>();
        foreach (var i in list)
        {
            result.Add(function(i));
        }

        return result;
    }

    public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
    {
        var result = new List<T>();
        foreach (var i in list)
        {
            if (function(i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    public static TOut Fold<TInp, TOut>(List<TInp> list, TOut accumulate, Func<TOut, TInp, TOut> function)
    {
        foreach (var i in list)
        {
            accumulate = function(accumulate, i);
        }

        return accumulate;
    }
}