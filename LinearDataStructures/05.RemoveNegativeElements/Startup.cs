namespace _05.RemoveNegativeElements
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

            Console.WriteLine("Task 5 : Enter sequence of Interegers (like: '1 2 -2 2 -3' or '1, 2, -2, 2, -3')");
            Console.WriteLine("To remove all negavtive occurances in the sequence");

            var digits = SequenceParser.StringNumberSequenceToList(Console.ReadLine());

            RemoveAllNegativeElements(digits);

            //// digits = RemoveAllNegativeWithFind(digits); // variant with linq FindAll()

            //// digits = RemoveAllNegativeWithWhere(digits); // variant with Linq Where() clause

            digits.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }

        internal static void RemoveAllNegativeElements(List<int> numbers)
        {
            numbers.RemoveAll(x => x < 0);
        }

        internal static List<int> RemoveAllNegativeWithFind(List<int> numbersList)
        {
            return numbersList.FindAll(x => x >= 0);
        }

        internal static List<int> RemoveAllNegativeWithWhere(List<int> numbersList)
        {
            return numbersList.Where(x => x > 0).ToList();
        }
    }
}
