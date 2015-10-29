namespace _10.ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n This homework uses C# 6 syntax and VS2015 ! \n");

            Console.WriteLine("Task 10 : ENTER an integer to specify the START point (example: 5) \n and then ENTER ENDING POINT");
            Console.WriteLine(" .. N2 = N+1 ; N3 = N+2; N4 = N*2 .. Write a program that finds the shortest sequence of operations \nfrom the list above that starts from N and finishes in M.. ..");

            Console.WriteLine("Enter N :");
            var start = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M : ");
            var end = int.Parse(Console.ReadLine());

            var queue = GeneratQueueeElements(start, end);

            PrintQueueElemenets(queue);
        }

        internal static Queue<int> GeneratQueueeElements(int start, int end)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);

            var current = start;
            while (current < end)
            {
                queue.Enqueue(current + 1);
                current = current + 1;
                queue.Enqueue(current + 2);
                current = current + 2;
                queue.Enqueue(current * 2);
                current = current * 2;
            }

            return queue;
        }

        internal static void PrintQueueElemenets(Queue<int> queue)
        {
            while (queue.Count > 0)
            {
                Console.Write($"{queue.Dequeue(),4} ");
            }

            Console.WriteLine();
        }
    }
}
