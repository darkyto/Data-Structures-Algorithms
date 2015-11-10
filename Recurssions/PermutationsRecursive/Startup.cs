namespace PermutationsRecursive
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all permutations 
    /// of the numbers 1, 2, ..., n for given integer number n. Example:
    /// n=3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.Write("Input String>");
            string inputLine = Console.ReadLine();

            Recursion rec = new Recursion();
            rec.InputSet = rec.MakeCharArray(inputLine);
            rec.CalcPermutation(0);

            Console.Write("# of Permutations: " + rec.PermutationCount);
        }
    }
}
