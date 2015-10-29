namespace _11.LinkedListImplementation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            LinkedList<int> sampleList = new LinkedList<int>();
            sampleList.AddNode(-33);
            sampleList.AddNode(2);
            sampleList.AddNode(3);
            sampleList.AddNode(4);
            int initialValue = sampleList.GetFirstAdded();

            Console.WriteLine(initialValue);
        }
    }
}
