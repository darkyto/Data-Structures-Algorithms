namespace HashSet
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var hashset = new HashSetCustom<int>();

            for (int i = 5; i < 15; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    hashset.Add(i);
                }
            }

            System.Console.WriteLine(hashset);
            System.Console.WriteLine(hashset.Count);

            var hashsetTwo = new HashSetCustom<int>();

            for (int i = 0; i < 10; i++)
            {
                hashsetTwo.Add(i);
            }

            Console.WriteLine(hashsetTwo);
            Console.WriteLine(hashsetTwo.Count);
            Console.WriteLine(hashset.IntersectsWith(hashsetTwo));
            Console.WriteLine(hashset.Union(hashsetTwo));
        }
    }
}
