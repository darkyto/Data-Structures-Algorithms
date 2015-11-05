using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountWordOccurance
{
    /// <summary>
    /// Write a program that counts how many times each word from given text 
    /// file words.txt appears in it. The character casing differences should be ignored. 
    /// The result words should be ordered by their number of occurrences in the text. 
    /// Example:
    /// This is the TEXT.Text, text, text – THIS TEXT! Is this the text?
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            var text = "This is the TEXT.Text, text, text – THIS TEXT! Is this the text?";

            Regex.Matches(text, "[A-Za-z0-9]+")
                .Cast<Match>()
                .Select(m => m.Value.ToUpper())
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ToList()
                .ForEach(x =>
                {
                    Console.WriteLine($"Occurances in text for word : {x.Key, -5} ==> {x.Count()} ");
                });
        }
    }
}
