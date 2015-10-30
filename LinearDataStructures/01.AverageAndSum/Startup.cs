namespace _01.AverageAndSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();
            Console.WriteLine("Task 1 : Enter a sequence of positive integer digits (like: '1 2 3' or '1,2,3') \nto get sum and average");

            List<int> list = SequenceParser.StringNumberSequenceToList(Console.ReadLine());

            Console.WriteLine($"Sum: {list.Sum()}");
            Console.WriteLine($"Average: {list.Average()}");
        }
    }
}
