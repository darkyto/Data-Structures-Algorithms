using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Startup
    {
        private static long[] memo;

        public static long Trees(int n)
        {
            long res = 0;

            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            for (int i = 0; i < n; i++)
            {
                res += Trees(i) * Trees(n - i - 1);
                memo[n] = res;
            }

            return res;
        }

        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int n = input.Length;
            var groups = new int[26];

            memo = new long[n + 1];

            foreach (var ball in input)
            {
                groups[ball - 'A']++; 
            }

            var fact = new long[n + 1];
            fact[0] = 1;

            for (int i = 0; i < n; i++)
            {
                fact[i + 1] = fact[i] * (i + 1);
            }

            BigInteger result = fact[n];

            foreach (var x in groups)
            {
                result /= fact[x];
            }

            Console.WriteLine(result * Trees(n));
        }
    }
}
