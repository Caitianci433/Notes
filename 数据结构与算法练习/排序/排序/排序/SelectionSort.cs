using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    partial class Program
    {
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="array"></param>
        private static void SelectionSort(int[] array)
        {
            int min;

            for (int i = 0; i < array.Length-1; i++)
            {
                min = i;

                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j]<array[min])
                    {
                        min = j;
                    }
                }

                Swap(array, i, min);
            }

        }
    }
}
