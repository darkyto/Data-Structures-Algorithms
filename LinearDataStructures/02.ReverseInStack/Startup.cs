namespace _02.ReverseInStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commons;

    public class Startup
    {
        // Write a program that reads N integers from the console and reverses them using a stack.
        // Use the Stack<int> class.
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();
            Console.WriteLine("Task 2 : Enter Interegers (like: '1 2 3' or '1,2,3') to stack and reverse");

            var digits = SequenceParser.StringNumberSequenceToList(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            foreach (var item in digits)
            {
                stack.Push(item);
            }

            Console.WriteLine("Stack BEFORE reversal :");
            foreach (var item in stack)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            ReverseStackRecursive(stack);

            Console.WriteLine("Stack AFTER reversal :");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }

        internal static void ReverseStackRecursive(Stack<int> stack)
        {
            int temp = stack.Pop();

            if (stack.Count != 1)
            {
                ReverseStackRecursive(stack);
            }

            PushInStack(stack, temp);
        }

        internal static void PushInStack(Stack<int> stack, int tempMember)
        {
            int temp = (int)stack.Pop();

            if (stack.Count != 0)
            {
                PushInStack(stack, tempMember);
            }
            else
            {
                stack.Push(tempMember);
            }

            stack.Push(temp);
        }
    }
}
