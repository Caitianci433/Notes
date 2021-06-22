namespace 排序
{
    partial class Program
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array"></param>
        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }
    }
}
