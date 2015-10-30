namespace _13.Queue
{
    using System;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();

            var qu = new Queue<int>();

            for (int i = 0; i < 50; i++)
            {
                qu.Enqueue(i);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write($" {qu.Dequeue()} ");
            }
        }
    }
}
