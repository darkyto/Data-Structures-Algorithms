namespace AlogrithmsExamples
{
    using System;

    public class InsertionSort
    {
        public static void InsertSortGeneric<T>(T[] array) where T : IComparable
        {
            int i, j;

            for (i = 1; i < array.Length; i++)
            {
                T value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = value;
            }
        }
    }
}
