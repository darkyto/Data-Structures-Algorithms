namespace _06.RemoveAllOddTimesOccurances
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

            Console.WriteLine("Task 6 : Enter sequence of Interegers (like: ' 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 ')");
            Console.WriteLine("Program that removes from given sequence all numbers that occur odd number of times.");

            var digits = SequenceParser.StringNumberSequenceToList(Console.ReadLine());
            digits = RemoveAllOddTimesOccuranceElementsWithFind(digits);

            digits.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }

        public static List<int> RemoveAllOddTimesOccuranceElements(List<int> inputList)
        {
            return inputList.Where(x => inputList.Count(y => y == x) % 2 == 0).ToList();
        }

        public static List<int> RemoveAllOddTimesOccuranceElementsWithFind(List<int> inputList)
        {
            return inputList.FindAll(x => inputList.Count(y => y == x) % 2 == 0);
        }
    }
}
