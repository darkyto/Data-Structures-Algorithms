namespace GenerateCombinationNonDuplicates
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = 2;

            var combination = new int[n];

            var elementsCount = 4;

            var count = 0;

            GenerateCombination(combination, elementsCount, ref count);
            Console.WriteLine("{2} Total combinations (NON duplicates) for {1} elements in {0}-set ", n, elementsCount, count);
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

                GenerateCombination(combination, n, ref count, depth + 1, i + 1);
            }
        }
    }
}
