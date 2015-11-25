namespace AlogrithmsExamples
{
    using System;

    public class MergeSort
    {
        private static void DoMerge<T>(T[] numbers, int left, int mid, int right) where T : IComparable
        {
            T[] temp = new T[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left].CompareTo(numbers[mid]) <= 0)
                {
                    temp[tmp_pos++] = numbers[left++];
                }
                else
                {
                    temp[tmp_pos++] = numbers[mid++];
                }
            }

            while (left <= left_end)
            {
                temp[tmp_pos++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[tmp_pos++] = numbers[mid++];
            }

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        public static void MergeSortRecursive<T>(T[] numbers, int left, int right) where T : IComparable
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortRecursive(numbers, left, mid);
                MergeSortRecursive(numbers, (mid + 1), right);
                DoMerge(numbers, left, (mid + 1), right);
            }
        }
    }
}
