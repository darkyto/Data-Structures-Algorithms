namespace GenerateAllKSubsetsFromSet
{
    using System;
    using System.Text;

    /// <summary>
    /// Write a program for generating and printing all subsets of k strings from given set of strings.
    /// Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)
    /// </summary>
    public class Startup
    {
        private static string[] set;
        private static int[] allSubsets;
        private static int k = 2;

        public static void Main(string[] args)
        {
            set = new string[] { "test", "rock", "fun" };
            allSubsets = new int[set.Length];

            string res = ""; // ref used just for the trim
            Variations(0, 0, ref res);

            Console.WriteLine(res.Trim(' ').Trim(','));
        }

        private static void Variations(int start, int depth, ref string res)
        {
            if (depth >= k)
            {
                res += Print(k, set, allSubsets);
                return;
            }

            for (int i = start; i < set.Length; i++, start++)
            {
                allSubsets[depth] = i;
                Variations(start + 1, depth + 1, ref res);
            }
        }

        private static string Print(int k, string[] set, int[] allSubsets)
        {
            var sb = new StringBuilder();

            sb.Append("{ ");
            for (int i = 0; i < k; i++)
            {
                sb.Append(set[allSubsets[i]]);
                if (i != k - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }, ");

            return sb.ToString();
        }
    }
}
