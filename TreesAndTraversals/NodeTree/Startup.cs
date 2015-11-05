namespace NodeTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = @"7
                        2 4
                        3 2
                        5 0
                        3 5
                        5 6
                        5 1";

            StringReader reader = new StringReader(input);

            Console.SetIn(reader);

            List<NodeTree<int>> nodes = ReadAndParseInput();
           
            Console.WriteLine();
            foreach (var nodeTree in nodes)
            {
                nodeTree.TraversePrint(nodeTree , Console.WriteLine, 4);
            }

            Console.WriteLine("Root: " + GetRootNode(nodes).Value);

            Console.WriteLine("Leaf count: " + string.Join(", ", GetLeafNodes(nodes).Count));
            Console.WriteLine("Leaf nodes : ");
            foreach (var nodeTree in GetLeafNodes(nodes))
            {
                nodeTree.TraversePrint(nodeTree, Console.WriteLine, 4);
            }

            Console.WriteLine("Middle count: " + string.Join(", ", GetMiddleNodes(nodes).Count));
            Console.WriteLine("Midle nodes : ");
            foreach (var nodeTree in GetMiddleNodes(nodes))
            {
                nodeTree.TraversePrint(nodeTree, Console.WriteLine, 4);
            }

            int sumForPath = 9;

            var pathsWithSum = GetPathsWithSum(sumForPath, nodes);

            var pathsWithSumString = pathsWithSum.Select(path => "[" + string.Join(" -> ", path.Reverse()) + "]").ToArray();
            Console.WriteLine("Paths with sum {0}: {1}", 20, string.Join(", ", pathsWithSumString));

            int sumForSubtree = 21;
            var rootsOfSubtrees = GetRootsOfSubtreesWithSum(sumForSubtree, nodes);
            foreach (var root in rootsOfSubtrees)
            {
                Console.WriteLine("GetRootsOfSubtreesWithSum: {0}", sumForSubtree);
                StringBuilder sb = new StringBuilder();
                Console.WriteLine(sb);
                Console.WriteLine(new string('_', 30));
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Longest path");
            var longestPath = GetLongestPath(nodes);
            var line = "";
            foreach (var nodeTree in longestPath)
            {
                Console.WriteLine(line);
                foreach (var tree in nodeTree)
                {
                    line += "-";
                    Console.WriteLine($"{line}{tree.Value}");
                }
            }
        }

        private static List<NodeTree<int>> ReadAndParseInput()
        {
            List<NodeTree<int>> nodes = new List<NodeTree<int>>();

            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges - 1; i++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(value => int.Parse(value))
                    .ToArray();

                var parent = nodes.FirstOrDefault(node => values[0] == node.Value);
                if (parent == null)
                {
                    parent = new NodeTree<int>(values[0]);
                    nodes.Add(parent);
                }

                var child = nodes.FirstOrDefault(node => values[1] == node.Value);
                if (child == null)
                {
                    child = new NodeTree<int>(values[1]);
                    nodes.Add(child);
                }

                parent.AddChild(child);
            }

            return nodes;
        }

        private static List<NodeTree<int>> GetRootsOfSubtreesWithSum(int sum, List<NodeTree<int>> nodes)
        {
            List<NodeTree<int>> roots = new List<NodeTree<int>>();

            var root = GetRootNode(nodes);
            GetSubtreeSum(sum, root, roots);
            return roots;
        }

        private static int GetSubtreeSum(int sum, NodeTree<int> node, List<NodeTree<int>> roots)
        {
            if (!node.HasChildren)
            {
                if (node.Value == sum) roots.Add(node);
                return node.Value;
            }
            else
            {
                int subtreeSum = node.Value;
                foreach (var child in node.Children)
                {
                    subtreeSum += GetSubtreeSum(sum, child, roots);
                }
                if (subtreeSum == sum) roots.Add(node);
                return subtreeSum;
            }
        }

        private static List<NodeTree<int>[]> GetPathsWithSum(int sum, List<NodeTree<int>> nodes)
        {
            List<NodeTree<int>[]> paths = new List<NodeTree<int>[]>();
            foreach (var node in nodes)
            {
                GetPathsFromNode(node, new Stack<NodeTree<int>>(), paths);
            }
            return paths.Where(path => path.Sum(node => node.Value) == sum).ToList();
        }

        private static void GetPathsFromNode(NodeTree<int> node, Stack<NodeTree<int>> stack, List<NodeTree<int>[]> paths)
        {
            stack.Push(node);
            paths.Add(stack.ToArray());

            foreach (var child in node.Children)
            {
                GetPathsFromNode(child, stack, paths);
            }

            stack.Pop();
        }

        private static List<NodeTree<int>[]> GetLongestPath(List<NodeTree<int>> nodes)
        {
            List<NodeTree<int>[]> paths = new List<NodeTree<int>[]>();
            GetPath(GetRootNode(nodes), new Stack<NodeTree<int>>(), paths);
            paths = paths.OrderByDescending(path => path.Length).GroupBy(path => path.Length).First().ToList();
            return paths;
        }

        private static void GetPath(NodeTree<int> node, Stack<NodeTree<int>> path, List<NodeTree<int>[]> paths)
        {
            path.Push(node);

            foreach (var child in node.Children)
            {
                GetPath(child, path, paths);
            }

            if (!node.HasChildren) paths.Add(path.ToArray());

            path.Pop();
        }

        private static List<NodeTree<int>> GetMiddleNodes(List<NodeTree<int>> nodes)
        {
            return nodes.Where(node => node.HasParent && node.HasChildren).ToList();
        }

        private static List<NodeTree<int>> GetLeafNodes(List<NodeTree<int>> nodes)
        {
            if (nodes.Count(node => node.HasChildren == false) < 1)
            {
                throw new Exception("Something's wrong! This tree has no leaves.");
            }

            return nodes.Where(node => node.HasChildren == false).ToList();
        }

        private static NodeTree<int> GetRootNode(List<NodeTree<int>> nodes)
        {
            if (nodes.Count(node => node.HasParent == false) != 1)
            {
                throw new ArgumentException("No root element found");
            }

            return nodes.First(node => node.HasParent == false);
        }
    }
}
