namespace NestedLoopsRecursive
{
    using System;

    /// <summary>
    /// Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            var inputs = new int[] { 11, 8, 5 , 63, 23, 107 ,1 ,91 ,17 ,45};

            SimulateLoops(5, 7, inputs);
        }

        private static void SimulateLoops(int end, int depth, int[] values)
        {
            if (depth == 0)
            {
                Console.WriteLine(string.Join(" ", values));
                return;
            }

            for (int i = 1; i <= end; i++)
            {
                values[depth - 1] = i;
                SimulateLoops(end, depth - 1, values);
            }
        }
    }
}
