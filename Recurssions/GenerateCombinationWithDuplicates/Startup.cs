namespace GenerateCombinationWithDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a recursive program for generating and printing all the 
    /// combinations with duplicatesof k elements from n-element set. Example:
    /// n=3, k=2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = 2;

            var combination = new int[n];

            var elementsCount = 4;

            var count = 0;

            GenerateCombination(combination, elementsCount, ref count);
            Console.WriteLine( "{2} Total combinations (duplicates also) for {1} elements in {0}-set ", n, elementsCount, count);
        }

        public static void GenerateCombination(int[] combination, int n, ref int count, int depth = 1, int start = 1)
        {
            if (depth - 1 == combination.Length)
            {
                count += 1;
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                combination[depth - 1] = i;

                GenerateCombination(combination, n, ref count, depth + 1, i );
            }
        }
    }
}
