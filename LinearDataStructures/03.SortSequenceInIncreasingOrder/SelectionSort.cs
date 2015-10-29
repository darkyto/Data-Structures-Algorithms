namespace _03.SortSequenceInIncreasingOrder
{
    using System.Collections.Generic;

    public class SelectionSort
    {
        /// <summary>
        ///  O(n2) complexity of selection sort algorithm
        /// </summary>
        /// <param name="list"></param>
        public void Sort(IList<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var minimalValue = i;
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minimalValue])
                    {
                        minimalValue = j;
                    }              
                }

                if (minimalValue != i)
                {
                    var tempValue = list[i];
                    list[i] = list[minimalValue];
                    list[minimalValue] = tempValue;
                }
            }
        }
    }
}
