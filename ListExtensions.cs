using System.Collections.Generic;

public static class ListExtensions
{
    public static bool AddIfMissing<T>(this List<T> list, T value)
    {
        if (list.Contains(value))
        {
            return true;
        }
        else
        {
            list.Add(value);
            return false;
        }
    }
}