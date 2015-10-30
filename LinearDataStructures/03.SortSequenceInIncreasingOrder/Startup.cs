namespace _03.SortSequenceInIncreasingOrder
{
    using System;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();
            Console.WriteLine("Task 3 : Enter sequence of Interegers (like: '1 -2 3' or '1,-2,3') to sort in increasing order");

            var digits = SequenceParser.StringNumberSequenceToList(Console.ReadLine());

            //// digits.Sort();

            var instance = new SelectionSort();
            instance.Sort(digits);

            Console.WriteLine("Ordered : ");
            digits.ForEach(x => Console.Write(x + " "));
            Console.WriteLine("Done! ");
        }
    }
}
