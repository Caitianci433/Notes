namespace 排序
{
    partial class Program
    {
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="array"></param>
        private static void ShellSort(int[] array)
        {
            int gap = 1;

            while (gap < array.Length)
            {
                gap = gap * 3 + 1;
            }

            while (gap > 0)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int tmp = array[i];
                    int j = i - gap;

                    while (j>=0&&array[j]>tmp)
                    {
                        array[j + gap] = array[j];
                        j -= gap;
                    }

                    array[j + gap] = tmp;
                }
                gap /= 3;
            }
        }
    }
}
