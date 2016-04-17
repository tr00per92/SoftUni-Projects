namespace SortableCollection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (var i = 1; i < collection.Count; i++)
            {
                var targetIndex = i;
                while (targetIndex > 0 && collection[i].CompareTo(collection[targetIndex - 1]) < 0)
                {
                    targetIndex--;
                }

                if (targetIndex < i)
                {
                    var item = collection[i];
                    collection.RemoveAt(i);
                    collection.Insert(targetIndex, item);
                }
            }
        }
    }
}