namespace SearchAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static int[] arrOriginal = GenerateArray();
        private static int[] arr;
        private static DateTime start;

        public static void Main(string[] args)
        {
            arr = arrOriginal.ToArray();
            arr.ToList().ForEach(x => Console.WriteLine(x + " : "));
            PrintLine('-');
            start = DateTime.Now;
            var key = 25;
            var result = BinarySearch.BinarySearchRecursive(arr, key, 0, arr.Length);
            Console.WriteLine(" Binary Search time: " + (DateTime.Now - start));
            Console.WriteLine("Search for number {0} in random genarated array : \n{1}", key, result);
            PrintLine('-');
            PrintLine('=');
        }

        public static int[] GenerateArray()
        {
            int[] arr = new int[1 << 4];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(2, 50);
            }
            return arr;
        }

        public static void PrintLine(char symbol)
        {
            Console.WriteLine();
            Console.WriteLine(new string(symbol, 40));
        }
    }
}
