namespace _08.TheMajorant
{
    using System;
    using System.Linq;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();

            Console.WriteLine("Task 8 : Enter sequence of Interegers (example: ' 2, 2, 3, 3, 2, 3, 4, 3, 3 ')");
            Console.WriteLine(" Write a program to find the majorant of given array (if exists).");

            var digits = SequenceParser.StringNumberSequenceToArray(Console.ReadLine());

            var result = _07.NumberOfOccuranceForEachElement.Startup.CountNumberOfOccuranceGroupBy(digits);

            result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            if (result.First().Value > result.Count / 2)
            {
                Console.WriteLine($"The majorant is the number : {result.First().Key}");
                Console.WriteLine($"NUmber of occurances : {result.First().Value}");
            }
            else
            {
                Console.WriteLine("No majorant element in this sequence");
            }
        }
    }
}
