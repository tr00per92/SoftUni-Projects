using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_CustomLINQMethods
{
    public static class CustomLINQMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(item => !predicate(item));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count) 
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            var result = collection;
            for (int i = 1; i < count; i++)
            {
                result = result.Concat(collection);
            }
            return result;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            return collection.Where(item => (suffixes.Any(suffix => item.EndsWith(suffix))));
        } 
    }
}
