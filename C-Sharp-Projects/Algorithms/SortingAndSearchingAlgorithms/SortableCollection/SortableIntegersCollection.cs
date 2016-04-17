namespace SortableCollection
{
    using System.Collections.Generic;

    public class SortableIntegersCollection : SortableCollection<int>
    {
        public SortableIntegersCollection(IEnumerable<int> items)
            : base(items)
        {
        }

        public SortableIntegersCollection(params int[] items)
            : base(items)
        {
        }

        public int InterpolationSearch(int key)
        {
            var low = 0;
            var high = this.Items.Count - 1;
            if (low > high)
            {
                return -1;
            }

            while (this.Items[low] <= key && this.Items[high] >= key)
            {
                var mid = low + ((key - this.Items[low]) * (high - low)) / (this.Items[high] - this.Items[low]);
                if (this.Items[mid] < key)
                {
                    low = mid + 1;
                }
                else if (this.Items[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (this.Items[low] == key)
            {
                return low;
            }

            return -1;
        }
    }
}