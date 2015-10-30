namespace _11.LinkedListImplementation
{
    using System;
    using Commons;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SequenceParser.WarningMessage();

            LinkedList<int> sampleList = new LinkedList<int>();

            sampleList.Add(-33);
            sampleList.Add(2);
            sampleList.Add(100);
            sampleList.Add(4);

            foreach (var item in sampleList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"First element : {sampleList.FirstElement.Value}");
            Console.WriteLine($"Last element : {sampleList.LastElement.Value}");
            Console.WriteLine($"Count of all elements added : {sampleList.Count}");
            Console.WriteLine(new string('=', 40));

            var head = sampleList.GetFirstNode();
            Console.WriteLine(head.Value);
            Console.WriteLine(head.NextItem.Value);
            Console.WriteLine(head.NextItem.NextItem.Value);
            Console.WriteLine(head.NextItem.NextItem.NextItem.Value);
            Console.WriteLine(new string('=', 40));

            var head2 = head.GetNextNode();
            Console.WriteLine(head2.Value);

            Console.WriteLine(new string('=', 40));
            var containsCheckOne = sampleList.Contains(-33);
            var containsCheckTwo = sampleList.Contains(-3300);
            Console.WriteLine($"do sample list contains -33 : {containsCheckOne}");
            Console.WriteLine($"do sample list contains -3300 : {containsCheckTwo}");

            sampleList.Remove(-33);
            Console.WriteLine(sampleList.GetFirst());
            Console.WriteLine(sampleList.LastElement.Value);
        }
    }
}
