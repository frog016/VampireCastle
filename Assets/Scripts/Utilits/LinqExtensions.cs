using System;
using System.Collections.Generic;

public static class LinqExtensions
{
    public static T MinElement<T>(this IEnumerable<T> collection, Func<T, float> func)
    {
        var first = true;
        var element = default(T);

        foreach (var e in collection)
        {
            if (first)
            {
                element = e;
                first = false;
            }

            if (func(e) < func(element))
                element = e;
        }

        return element;
    }
}
