using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    //快速排序
    partial class Program
    {
        private static void QuicSort(int[] array)
        {
            QSort(array, 0, array.Length-1);         
        }
        private static void QSort(int[] array, int low, int high)
        {
            int pivot;

            if (low < high)
            {
                pivot = Partition(array, low, high);

                QSort(array, low, pivot-1);

                QSort(array, pivot + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high) 
        {
            int pivotkey = array[low];

            while (low < high)
            {
                while (low < high && array[high] >= pivotkey)
                {
                    high--;
                }
                Swap(array, low, high);

                while (low < high && array[low] <= pivotkey)
                {
                    low++;
                }
                Swap(array, low, high);
            }
            return low;      
        }
    }
}
