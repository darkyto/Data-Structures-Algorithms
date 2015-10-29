namespace _04.SubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n This homework uses C# 6 syntax and VS2015 ! \n");

            Console.WriteLine("Task 4 : Enter sequence of Interegers (like: '1 2 2 2 3' or '1, 2, 2, 2, 3')");
            Console.WriteLine("To find the longest subsequence of equal digits (like: 2 2 2)");

            var digits = SequenceParser.StringNumberSequenceToList(Console.ReadLine());

            var result = MaximalSubsequenceOfEquals(digits);

            result.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }

        internal static List<int> MaximalSubsequenceOfEquals(List<int> seqence)
        {
            return seqence.Select((n, i) => new { Value = n, Index = i })
                    .OrderBy(s => s.Value)
                    .Select((o, i) => new { Val = o.Value, Diff = i - o.Index })
                    .GroupBy(s => new { s.Val, s.Diff })
                    .OrderBy(g => g.Count())
                    .Last()
                    .Select(f => f.Val)
                    .ToList();
        }
    }
}
