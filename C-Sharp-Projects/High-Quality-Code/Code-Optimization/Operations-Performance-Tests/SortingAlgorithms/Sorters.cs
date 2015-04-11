namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public static class Sorters
    {
        public static List<int> SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int oldValue = 0;
                    oldValue = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = oldValue;
                }
            }

            return list;
        }

        public static List<double> SelectionSort(List<double> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    double oldValue = 0;
                    oldValue = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = oldValue;
                }
            }

            return list;
        }

        public static List<string> SelectionSort(List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (string.Compare(list[j], list[minIndex], StringComparison.InvariantCulture) != 1)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    string oldValue = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = oldValue;
                }
            }

            return list;
        }

        public static List<string> QuickSort(List<string> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list.Count / 2;
            string pivotValue = list[pivot];
            list.RemoveAt(pivot);
            List<string> lesser = new List<string>();
            List<string> greater = new List<string>();

            foreach (string element in list)
            {
                if (string.Compare(element, pivotValue, StringComparison.InvariantCulture) < 0)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<string> result = new List<string>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public static List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list.Count / 2;
            int pivotValue = list[pivot];
            list.RemoveAt(pivot);
            List<int> lesser = new List<int>();
            List<int> greater = new List<int>();

            foreach (int element in list)
            {
                if (element < pivotValue)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<int> result = new List<int>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public static List<double> QuickSort(List<double> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list.Count / 2;
            double pivotValue = list[pivot];
            list.RemoveAt(pivot);
            List<double> lesser = new List<double>();
            List<double> greater = new List<double>();

            foreach (double element in list)
            {
                if (element < pivotValue)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<double> result = new List<double>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public static List<int> InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int oldValue = list[i];
                int position = i - 1;
                while (position >= 0 && list[position] > oldValue)
                {
                    list[position + 1] = list[position];
                    position--;
                }

                list[position + 1] = oldValue;
            }

            return list;
        }

        public static List<double> InsertionSort(List<double> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                double oldValue = list[i];
                int position = i - 1;
                while (position >= 0 && list[position] > oldValue)
                {
                    list[position + 1] = list[position];
                    position--;
                }

                list[position + 1] = oldValue;
            }

            return list;
        }

        public static List<string> InsertionSort(List<string> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                string oldValue = list[i];
                int position = i - 1;
                while (position >= 0 && string.CompareOrdinal(list[position], oldValue) > 0)
                {
                    list[position + 1] = list[position];
                    position--;
                }

                list[position + 1] = oldValue;
            }

            return list;
        }
    }
}
