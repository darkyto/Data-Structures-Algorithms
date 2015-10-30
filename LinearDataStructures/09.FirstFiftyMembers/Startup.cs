namespace _09.FirstFiftyMembers
{
    using System;
    using System.Collections.Generic;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();

            Console.WriteLine("Task 9 : ENTER an integer to specify the starting point (example: 2)");
            Console.WriteLine(".. Using the Queue<T> class write a program to print its first 50 members for given N. ..");

            int inputNumber = int.Parse(Console.ReadLine());

            var queue = GeneratQueueeElements(inputNumber, 50);

            PrintQueueElemenets(queue);
        }

        /// <summary>
        /// Generating elements by the following formula: S1 = inputNumber; S2 = S1 + 1; S3 = 2*S1 + 1; S4 = S1 + 2;
        /// </summary>
        /// <param name="inputNumber"> Starting point</param>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static Queue<int> GeneratQueueeElements(int inputNumber, int count)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(inputNumber); // the starting point element

            for (int i = 1; i <= count; i++)
            {
                queue.Enqueue(inputNumber + 1);
                queue.Enqueue((2 * inputNumber) + 1);
                queue.Enqueue(inputNumber + 2);

                inputNumber++;
            }

            return queue;
        }

        internal static void PrintQueueElemenets(Queue<int> queue)
        {
            while (queue.Count > 0)
            {
                Console.Write($"{queue.Dequeue(), 4} ");
            }
        }
    }
}
