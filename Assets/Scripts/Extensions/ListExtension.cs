using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
    {
        return source == null || !source.Any();
    }
}
