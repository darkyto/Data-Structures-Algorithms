namespace ColorfulBunnies
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/132#1
    /// </summary>
    public class Startup
    {
        internal static void Main(string[] args)
        {
            Dictionary<int, int> rabbits = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                var currentAnswer = int.Parse(Console.ReadLine());

                if (!rabbits.ContainsKey(currentAnswer))
                {
                    rabbits.Add(currentAnswer, 0);
                }

                if (rabbits[currentAnswer] != currentAnswer + 1)
                {
                    rabbits[currentAnswer]++;
                }
                else
                {
                    rabbits[currentAnswer] = 1;
                    
                    count += currentAnswer + 1;
                }
            }

            foreach (var bunny in rabbits)
            {
                if (bunny.Value > 0)
                {
                    count += bunny.Key + 1;
                }
            }

            Console.WriteLine(count);
        }
    }
}
