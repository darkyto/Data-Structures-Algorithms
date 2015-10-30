namespace _12.Stack
{
    using System;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();

            var stack = new Stack<int>();

            for (int i = 0; i < 200; i++)
            {
                stack.Push(i);  
            }

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("PUSHING to stack");
            foreach (var st in stack)
            {
                Console.Write($"{st} ");
            }

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("POPING from stack");
            for (var i = 0; i < 200; i++)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
