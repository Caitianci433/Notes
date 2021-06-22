namespace 排序
{
    partial class Program
    {
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="array"></param>
        private static void InsertSort(int[] array)
        {
            int pre;
            int current;

            for (int i = 1; i < array.Length; i++)
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
    }
}
