namespace AlogrithmsExamples
{
    using System;
    using System.Collections;

    public class SelectionSort
    {
        public static void SelectionSortGeneric<T>(T[] a) where T : IComparable
        {
            for (int sortedSize = 0; sortedSize < a.Length; sortedSize++)
            {
                int minElementIndex = sortedSize;
                T minElementValue = a[sortedSize];
                for (int i = sortedSize + 1; i < a.Length; i++)
                {
                    if (a[i].CompareTo(minElementValue) < 0)
                    {
                        minElementIndex = i;
                        minElementValue = a[i];
                    }
                }
                a[minElementIndex] = a[sortedSize];
                a[sortedSize] = minElementValue;
            }
        }

        public static void selectionSortObjects(object[] a, IComparer comparer)
        {
            for (int sortedSize = 0; sortedSize < a.Length; sortedSize++)
            {
                int minElementIndex = sortedSize;
                object minElementValue = a[sortedSize];
                for (int i = sortedSize + 1; i < a.Length; i++)
                {
                    if (comparer.Compare(a[i], minElementValue) < 0)
                    {
                        minElementIndex = i;
                        minElementValue = a[i];
                    }
                }
                a[minElementIndex] = a[sortedSize];
                a[sortedSize] = minElementValue;
            }
        }
    }
}
