using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.KnapsackProblem
{

    /// <summary>
    /// Write a program based on dynamic programming to solve the "Knapsack Problem": 
    /// you are given N products, each has weight Wi and costs Ci and a knapsack of capacity M 
    /// and you want to put inside a subset of the products with highest cost and weight ≤ M. 
    /// The numbers N, M, Wi and Ci are integers in the range [1..500].
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            //int n = int.Parse(Console.ReadLine());

            //Item[] items = new Item[n];

            //for (int i = 0; i < n; i++)
            //{
            //    var args = Console.ReadLine().Split(' ').ToArray();
            //    var item = new Item(args[0], int.Parse(args[1]), int.Parse(args[2]));
            //    items[i] = item;
            //}

            //int capacity = int.Parse(Console.ReadLine());

            Item[] items = new Item[]{
                                    new Item("beer", 3, 2),
                                    new Item("vodka", 8, 12),
                                    new Item("cheese", 4, 5),
                                    new Item("nuts", 1, 4),
                                    new Item("ham", 2, 3),
                                    new Item("whiskey", 8, 13)
            };

            int capacity = 10;

            Console.WriteLine("Best choice: ");

            var result = Knapsack(items, capacity);
            var bestTotalWeight = 0;
            var bestTotalCost = 0;
            foreach (var item in result)
            {
                bestTotalWeight += item.Weight;
                bestTotalCost += item.Cost;
                Console.Write(item.Name + " ");
            }
            Console.WriteLine();
            Console.WriteLine(bestTotalWeight);
            Console.WriteLine(bestTotalCost);
        }

        public static List<Item> Knapsack(Item[] items, int capacity)
        {
            if (capacity == 0)
            {
                return new List<Item>();
            }

            if (items.Length == 0)
            {
                return new List<Item>();
            }

            int[,] costArray = new int[items.Length, capacity + 1];
            int[,] bagArray = new int[items.Length, capacity + 1];

            for (int x = 0; x <= items.Length - 1; x++)
            {
                costArray[x, 0] = 0;
                bagArray[x, 0] = 0;
            }

            for (int y = 1; y <= capacity; y++)
            {
                if (items[0].Weight <= y)
                {
                    costArray[0, y] = items[0].Cost;
                    bagArray[0, y] = 1;
                }
                else
                {
                    costArray[0, y] = 0;
                    bagArray[0, y] = 0;
                }
            }

            for (int x = 0; x <= items.Length - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentItem = items[x + 1];
                    
                    if (currentItem.Weight > y)
                    {
                        costArray[x + 1, y] = costArray[x, y];
                        continue;
                    }

                    int valueWhenDropping = costArray[x, y];

                    int valueWhenTaking = costArray[x, y - currentItem.Weight] + currentItem.Cost;

                    if (valueWhenTaking > valueWhenDropping)
                    {
                        costArray[x + 1, y] = valueWhenTaking;
                        bagArray[x + 1, y] = 1;
                    }
                    else
                    {
                        costArray[x + 1, y] = valueWhenDropping;
                        bagArray[x + 1, y] = 0;
                    }
                }
            }

            var bestItems = new List<Item>();

            int remainingSpace = capacity;
            int item = items.Length - 1;

            while (item >= 0 && remainingSpace >= 0)
            {
                if (bagArray[item, remainingSpace] == 1)
                {
                    bestItems.Add(items[item]);
                    remainingSpace -= items[item].Weight;
                    item -= 1;
                }
                else
                {
                    item -= 1;
                }
            }

            return bestItems;
        }
    }

    public class Item
    {
        public Item(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }
    }
}
