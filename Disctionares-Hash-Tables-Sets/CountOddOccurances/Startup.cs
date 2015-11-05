namespace CountOddOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings 
    /// all elements that present in it odd number of times. 
    /// Example: {"C#", " SQL", "PHP", "PHP", "SQL", "SQL"}
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {

            var input = "{C#, SQL, PHP, PHP, SQL, SQL } ";

            Regex.Matches(input, "[A-Za-z0-9#]+")
                .Cast<Match>()
                .Select(m => m.Value.ToUpper())
                .GroupBy(x => x)
                .ToList()
                .ForEach(x =>
                {
                    if (x.Count() % 2 == 1)
                    {
                        Console.WriteLine("Odd occurances word : {0} => {1} ", x.Key, x.Count());
                    }
                });


            var result = new List<string>();

            input.Split(new[] { ' ', ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x)
                .ToList()
                .ForEach(x =>
                {
                    if (x.Count() % 2 == 1)
                    {
                        result.Add(x.Key);
                        Console.Write(x.Key + " ");
                    }
                });
            Console.WriteLine();
        }
    }
}
