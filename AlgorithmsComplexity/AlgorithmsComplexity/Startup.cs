namespace AlgorithmsComplexity
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var nums = new[] { 1, 1, 3, 1 };

            Console.WriteLine(Compute(nums));

            var matrix = new int[,] { { 1, 2 }, { 3, 4 } };

            Console.WriteLine(CalcCount(matrix));

            Console.WriteLine(CalcSum(matrix, 0));
        }

        /// <summary>
        /// Alogrithm complexity O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        internal static long Compute(int[] arr)
        {
            long count = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Alogrithm complexity O(n * m)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        internal static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Algorithm Complexity O(n + log(n)) ?!
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        internal static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;

            for (var col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < matrix.GetLength(1))
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }
    }
}
