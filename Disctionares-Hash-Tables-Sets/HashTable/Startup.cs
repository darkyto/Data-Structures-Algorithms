namespace HashTable
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var table = new HashTableCustom<int, string>();

            for (int i = 0; i < 50; i++)
            {
                table.Add(i, "record#" + i.ToString());
            }

            Console.WriteLine(table.Keys.Count);
            Console.WriteLine(table);

            var res = "";
            Console.WriteLine("Finding result at index 5");
            table.Find(5, out res);
            Console.WriteLine(res);Console.WriteLine();

            Console.WriteLine("Removing at index 5");
            table.Remove(5);
            string res1, res2;
            table.Find(4, out res);
            table.Find(5, out res1);
            table.Find(6, out res2);
            Console.WriteLine(res);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine();

            Console.WriteLine("Adding at index 5");
            table.Add(5, "NEW RECORD ADDED");
            table.Find(5, out res);
            Console.WriteLine(res); Console.WriteLine();

            table.Clear();
            Console.WriteLine(table.Count);
        }
    }
}
