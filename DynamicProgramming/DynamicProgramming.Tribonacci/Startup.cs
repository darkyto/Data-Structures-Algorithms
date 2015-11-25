namespace DynamicProgramming.Tribonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/123#0
    /// task 1 - Tribonacci
    /// </summary>
    public class Startup
    {
        private static long[] memo;
        private static DateTime start;

        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
            long[] tribonacci;

            memo = new long[input[3]   + 1];

            var searchedElement = (int)input[3];
            if (searchedElement < 3)
            {
                tribonacci = new long[3];
            }
            else
            {
                tribonacci = new long[searchedElement];
            }


            tribonacci[0] = input[0];
            tribonacci[1] = input[1];
            tribonacci[2] = input[2];

            // to get the right index of serachedElement remove 1
            if (searchedElement <= 3)
            {
                Console.WriteLine(tribonacci[searchedElement - 1]);
            }
            else
            {
                start = DateTime.Now;
                Console.WriteLine(FindTribonacci(tribonacci, searchedElement - 1, 3));
                Console.WriteLine(" Finding tribonacii naive method time: " + (DateTime.Now - start));
                start = DateTime.Now;
                Console.WriteLine(TribonachiDynamic(tribonacci, searchedElement - 1, 3));
                Console.WriteLine(" Memorisation method time: " + (DateTime.Now - start));
            }
        }
        public static long TribonachiDynamic(long[] triMembers, int searched, int current)
        {
            if (memo[searched] != 0)
            {
                return memo[searched];
            }

            if ((searched == 0) || (searched == 1) || (searched == 2))
            {
                return triMembers[searched];
            }

            memo[searched] = TribonachiDynamic(triMembers, searched - 1, current + 1) + TribonachiDynamic(triMembers, searched - 2, current + 1) + TribonachiDynamic(triMembers, searched - 3, current + 1);

            return memo[searched];
        }

        public static long FindTribonacci(long[] triMembers, int searched, int current)
        {
            triMembers[current] = triMembers[current - 1] + triMembers[current - 2] + triMembers[current - 3];
            if (searched == current)
            {
                return triMembers[current];
            }
            else
            {
                return FindTribonacci(triMembers, searched, current + 1);
            }
        }
    }
}
