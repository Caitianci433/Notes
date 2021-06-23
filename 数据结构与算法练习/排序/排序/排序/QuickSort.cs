namespace 排序
{
    //快速排序
    partial class Program
    {
        private static void QuicSort(int[] array)
        {
            QSort(array, 0, array.Length - 1);
        }
        private static void QSort(int[] array, int low, int high)
        {
            int pivot;

            //三数取中 使array[low]尽可能在中间
            int m = low + (high - low) / 2;
            if (array[low] > array[high])
            {
                Swap(array, low, high);
            }
            if (array[m] > array[high])
            {
                Swap(array, high, m);
            }
            if (array[m] > array[low])
            {
                Swap(array, m, low);
            }

            if ((high - low) > 7)
            {
                pivot = Partition(array, low, high);

                QSort(array, low, pivot - 1);

                QSort(array, pivot + 1, high);
            }
            else
            {
                InsertSort(array, low, high);
            }
        }
        private static void InsertSort(int[] array, int start, int end)
        {
            int pre;
            int current;

            for (int i = start + 1; i < end + 1; i++)
            {
                pre = i - 1;
                current = array[i];

                while (pre >= 0 && array[pre] > current)
                {
                    array[pre + 1] = array[pre];
                    pre--;
                }
                array[pre + 1] = current;
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int temp = array[low];

            while (low < high)
            {
                while (low < high && array[high] >= temp)
                {
                    high--;
                }
                array[low] = array[high];

                while (low < high && array[low] <= temp)
                {
                    low++;
                }
                array[high] = array[low];
            }
            array[low] = temp;

            return low;
        }
    }
}
