using System;

namespace Heap
{
    public class Program
    {
        private static Random rand = new Random();

        public static void Main(string[] args)
        {
            var heap = new MinHeap<int>();

            for (int i = 0; i < 15; i++)
            {
                if (i % 2 == 0)
                {
                    i *= -1;
                }
                heap.Insert(i);
                
            }
            Console.WriteLine(heap.Count);
            Console.WriteLine(heap.ExtractMin());
            Console.WriteLine();
        }
    }
}
