﻿namespace SortableCollection.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(List<T> collection);
    }
}