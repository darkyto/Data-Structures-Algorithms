
namespace AlogrithmsExamples
{
    using System;

    public class BubbleSort
    {
        public static void BubbleSortGeneric<T>(T[] array) where T : IComparable
        {
            int i, j;
            T temp;
            for (i = array.Length - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

    }


}
