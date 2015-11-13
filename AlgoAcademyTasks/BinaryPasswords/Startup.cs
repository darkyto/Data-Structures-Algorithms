namespace BinaryPasswords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();//Console.ReadLine();

            var stars = input.Where(x => (x == '*'));

            var starsCount = stars.Count();

            ulong res = 1;
            for (int i = 0; i < starsCount; i++)
            {
                res *= 2 ;
            }

            Console.WriteLine(res);
        }
    }
}
