namespace DynamicProgramming.MinimumEditDistance
{
    using System;
    using System.Linq;

    /// <summary>
    /// Write a program to calculate the "Minimum Edit Distance between two words. MED(x, y) 
    /// is the minimal sum of costs of edit operations used to transform x to y.
    /// 
    /// Sample costs:
    /// cost(replace a letter) = 1
    /// cost(delete a letter) = 0.9
    /// cost(insert a letter) = 0.8
    /// 
    /// Example:
    /// x = "developer", y = "enveloped" → cost = 2.7
    /// delete ‘d’: "developer" → "eveloper", cost = 0.9
    /// insert ‘n’: "eveloper" → "enveloper", cost = 0.8
    /// replace ‘r’ → ‘d’: "enveloper" → "enveloped", cost = 1
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            string[] input = "developer enveloped".Split(' ').ToArray();

            var result = MinimumEditDistance(input[0], input[1]);
            Console.WriteLine(result);
        }

        public static decimal MinimumEditDistance(string firstWord, string secondWord)
        {
            const decimal CostDelete = 0.9M;
            const decimal CostInsert = 0.8M;
            const decimal CostReplace = 1M;

            int n = firstWord.Length;
            int m = secondWord.Length;
            decimal[,] matrix = new decimal[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int row = 0; row <= n; row++)
            {
                matrix[row, 0] = row * CostDelete;
            }

            for (int col = 0; col <= m; col++)
            {
                matrix[0, col] = col * CostInsert;
            }

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= m; col++)
                {
                    decimal cost;
                    if (secondWord[col - 1] == firstWord[row - 1])
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = CostReplace;
                    }

                    decimal delete = matrix[row - 1, col] + CostDelete;
                    decimal replace = matrix[row - 1, col - 1] + cost;
                    decimal insert = matrix[row, col - 1] + CostInsert;


                    matrix[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            return matrix[n, m];
        }

    }
}
