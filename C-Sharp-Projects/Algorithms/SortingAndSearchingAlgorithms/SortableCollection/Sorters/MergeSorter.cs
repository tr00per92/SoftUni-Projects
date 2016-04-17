namespace SortableCollection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            var leftList = collection.Take(collection.Count / 2).ToList();
            var rightList = collection.Skip(collection.Count / 2).ToList();
            this.MergeSort(leftList);
            this.MergeSort(rightList);
            this.Merge(collection, leftList, rightList);
        }

        private void Merge(IList<T> collection, IList<T> leftList, IList<T> rightList)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (leftList.Any() && rightList.Any())
                {
                    if (leftList[0].CompareTo(rightList[0]) <= 0)
                    {
                        collection[i] = leftList[0];
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        collection[i] = rightList[0];
                        rightList.RemoveAt(0);
                    }
                }
                else if (leftList.Any())
                {
                    collection[i] = leftList[0];
                    leftList.RemoveAt(0);
                }
                else if (rightList.Any())
                {
                    collection[i] = rightList[0];
                    rightList.RemoveAt(0);
                }
            }
        }
    }
}