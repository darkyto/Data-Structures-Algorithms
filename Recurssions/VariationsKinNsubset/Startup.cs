namespace VariationsKinNsubset
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
    /// Example: n=3, k=2, set = {hi, a, b} 
    /// → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    public class Startup
    {
        private static string[] set;
        private static int[] result;

        public static void Main(string[] args)
        {
            int n = 3; // int.Parse(Console.ReadLine()); // number of elements to variate
            result = new int[n];

            int k = 2; // int.Parse(Console.ReadLine()); // size of each variation

            set = new string[] { "hi", "a", "b" };

            FindVariations(0, k, n);
        }

        private static void FindVariations(int depth, int k, int n)
        {
            if (depth >= k)
            {
                Print(k, set, result);
                return;
            }

            for(int i = 0; i < n; i++)
            {
                result[depth] = i;
                FindVariations(depth + 1, k, n);
            }
        }

        private static void Print(int k, string[] set, int[] result)
        {
            Console.Write("{ ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(set[result[i]]);
                if (i != k - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
    }
}
