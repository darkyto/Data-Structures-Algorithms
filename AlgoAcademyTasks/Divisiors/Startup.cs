namespace Divisiors
{
    using System;

    public class Startup
    {
        private static int answer;
        private static int bestDivisorsCount;
        private static int[] numbers;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bestDivisorsCount = int.MaxValue;
            numbers = new int[n];
            answer = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            GeneratePerm(numbers, 0);
            Console.WriteLine(answer);
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int FindDivisorCount(int number)
        {
            int divisorCount = 0;

            for (int i = 1; i < (number + 2) / 2; i++)
            {
                if (number % i == 0)
                {
                    divisorCount++;
                }
            }

            return divisorCount + 1;
        }

        public static void GeneratePerm(int[] numbers, int k)
        {
            if (k >= numbers.Length)
            {
                int number = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    number += numbers[i] * (int)Math.Pow(10, i);
                }

                int currentDiv = FindDivisorCount(number);

                if (currentDiv < bestDivisorsCount)
                {
                    bestDivisorsCount = currentDiv;
                    answer = number;
                }
                else if (currentDiv == bestDivisorsCount)
                {
                    if (answer > number)
                    {
                        answer = number;
                    }

                    //best = number;
                }
            }
            else
            {
                GeneratePerm(numbers, k + 1);
                for (int i = k + 1; i < numbers.Length; i++)
                {
                    Swap(ref numbers[k], ref numbers[i]);
                    GeneratePerm(numbers, k + 1);
                    Swap(ref numbers[k], ref numbers[i]);
                }
            }
        }
    }
}
