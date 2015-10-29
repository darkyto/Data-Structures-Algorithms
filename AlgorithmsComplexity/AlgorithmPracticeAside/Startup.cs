namespace AlgorithmPracticeAside
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int[] arr = { 2, 42, 5 };

            Console.WriteLine(GetMaxElement(arr));
        }

        internal static int GetMaxElement(int[] arr)
        {
            var n = arr.Length;

            // if we ignore the loop body, the number of instructions this algorithm needs is 4 + 2n. 
            // That is, 4 instructions at the beginning of the for loop and 2 instructions at the end of
            // each iteration of which we have n. 
            // We can now define a mathematical function f( n ) that, given an n,
            // gives us the number of instructions the algorithm needs. 
            // For an empty for body, we have f( n ) = 4 + 2n.
            var maxElement = arr[0];

            for (var i = 0; i < n; i++)
            {
                if (maxElement < arr[i])
                {
                    maxElement = arr[i];
                }
            }

            return maxElement;
        }

        internal static void SelectionSort(int[] arr)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }
    }
}
