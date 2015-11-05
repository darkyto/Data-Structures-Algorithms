namespace CountOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that counts in a given array of double values 
    /// the number of occurrences of each value. Use Dictionary with TKey TValue
    ///  Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    /// -2.5 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            var array = new double[] {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};

            var result = array
                .GroupBy(x => x)
                .OrderBy(x => x.Key)
                .ToList();

            result.ForEach(x => Console.WriteLine($"{x.Key} is seen {x.Count()} times"));
        }
    }
}
