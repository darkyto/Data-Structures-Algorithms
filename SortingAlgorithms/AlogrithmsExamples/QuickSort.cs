namespace AlogrithmsExamples
{
    using System;

    public class QuickSort
    {
        public static void QuicksortGeneric<T>(T[] elements, int left, int right) where T : IComparable
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortGeneric(elements, left, j);
            }

            if (i < right)
            {
                QuicksortGeneric(elements, i, right);
            }
        }

    }
}
