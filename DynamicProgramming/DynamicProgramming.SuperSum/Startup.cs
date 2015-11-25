namespace DynamicProgramming.SuperSum
{
    using System;
    using System.Linq;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/123#1
    /// SuperSum task
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int k = input[0];
            int n = input[1];
            var resultSums = SuperSum(k, n);
            Console.WriteLine(resultSums);
        }

        public static int SuperSum(int k, int n)
        {
            var result = new int[k + 1, n + 1];
            if (k == 0)
            {
                return n;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                result[k, n] = SuperSum(k - 1, n) + SuperSum(k, n - 1);
                return result[k, n];
            }
        }
    }
}
