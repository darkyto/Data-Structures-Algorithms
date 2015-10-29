namespace _07.NumberOfOccuranceForEachElement
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

            Console.WriteLine("Task 7 : Enter sequence of Interegers (example: ' 3, 4, 4, 2, 3, 3, 4, 3, 2 ')");
            Console.WriteLine(" Program that finds in given array of integers\n (all belonging to the range [0..1000]) how many times each of them occurs.");

            var digits = SequenceParser.StringNumberSequenceToArray(Console.ReadLine());

            var result = CountNumberOfOccuranceGroupBy(digits);

            //// var result = CountNumberOfOccuranceForeach(digits); // second "manual" variant

            foreach (var record in result)
            {
                Console.WriteLine($"{record.Key} is seen {record.Value} times");
            }
        }

        public static IDictionary<int, int> CountNumberOfOccuranceGroupBy(IEnumerable<int> arr)
        {
            return arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }

        internal static IDictionary<int, int> CountNumberOfOccuranceForeach(IEnumerable<int> arr)
        {
            IDictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (var number in arr)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 0);
                }

                dictionary[number]++;
            }

            return dictionary;
        }
    }
}
