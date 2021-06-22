using System;

namespace 排序
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var data = GetUnSortData(10);
            Console.WriteLine("-----排序前-----");
            Console.WriteLine(string.Join(',', data));
            //BubbleSort(data);
            //QuicSort(data);
            //SelectionSort(data);
            //InsertSort(data);
            ShellSort(data);
            Console.WriteLine("-----排序后-----");
            Console.WriteLine(string.Join(',', data));
        }

        #region Swap
        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="array"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void Swap(int[] array, int x, int y)
        {
            if (x!=y)
            {
                //原地交换
                array[x] = array[x] + array[y];
                array[y] = array[x] - array[y];
                array[x] = array[x] - array[y];

                //Console.WriteLine(string.Join(',', array));
            }
        }
        #endregion

        #region GetData
        private static int[] GetUnSortData(int length)
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, length);
            }

            return array;
        }
        #endregion
    }
}
