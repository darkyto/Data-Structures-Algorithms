namespace AlogrithmsExamples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
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
            SelectionSort.SelectionSortGeneric(arr);
            Console.WriteLine(" Selection Sort time: " + (DateTime.Now - start));
            arr.ToList().ForEach(x => Console.WriteLine(x + " < "));
            PrintLine('-');
            PrintLine('=');

            arr = arrOriginal.ToArray();
            arr.ToList().ForEach(x => Console.WriteLine(x + " : "));
            PrintLine('-');
            start = DateTime.Now;
            BubbleSort.BubbleSortGeneric(arr);
            Console.WriteLine(" BubbleSort time: " + (DateTime.Now - start));
            arr.ToList().ForEach(x => Console.WriteLine(x + " < "));
            PrintLine('-');
            PrintLine('=');

            arr = arrOriginal.ToArray();
            arr.ToList().ForEach(x => Console.WriteLine(x + " : "));
            PrintLine('-');
            start = DateTime.Now;
            InsertionSort.InsertSortGeneric(arr);
            Console.WriteLine(" InsertionSort time: " + (DateTime.Now - start));
            arr.ToList().ForEach(x => Console.WriteLine(x + " < "));
            PrintLine('-');
            PrintLine('=');

            arr = arrOriginal.ToArray();
            arr.ToList().ForEach(x => Console.WriteLine(x + " : "));
            PrintLine('-');
            start = DateTime.Now;
            QuickSort.QuicksortGeneric(arr, 0, arr.Length - 1);
            Console.WriteLine(" QuickSort time: " + (DateTime.Now - start));
            arr.ToList().ForEach(x => Console.WriteLine(x + " < "));
            PrintLine('-');
            PrintLine('=');

            arr = arrOriginal.ToArray();
            arr.ToList().ForEach(x => Console.WriteLine(x + " : "));
            PrintLine('-');
            start = DateTime.Now;
            MergeSort.MergeSortRecursive(arr, 0, arr.Length - 1);
            Console.WriteLine(" MergeSort time: " + (DateTime.Now - start));
            arr.ToList().ForEach(x => Console.WriteLine(x + " < "));
            PrintLine('-');
            PrintLine('=');
        }

        public static void PrintLine(char symbol)
        {
            Console.WriteLine();
            Console.WriteLine(new string(symbol, 40));
        }

        public static int[] GenerateArray()
        {
            int[] arr = new int[1 << 3];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next();
            }
            return arr;
        }
    }
}
