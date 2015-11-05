using System.Collections.Generic;

namespace ExeFileTraversal
{
    using System;
    using System.Linq;
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var txtFolderPath = "D:\\Telerik\\DSA\\Homeworks\\TreesAndTraversals";

            StringReader reader = new StringReader(txtFolderPath);

            Console.SetIn(reader);

            if (Directory.Exists(txtFolderPath))
            {
                string[] files = Directory.GetFiles(txtFolderPath, "*.exe", SearchOption.AllDirectories);

                Console.WriteLine($"Total .exe files in {txtFolderPath} : {files.Count()}");
            }
            else
            {
                Console.WriteLine($" {txtFolderPath} does not exists");
            }

            var foundFiles = GetFiles(txtFolderPath, "*.exe");

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Getting alll files in stack with recursion" + foundFiles.Count());
            Console.WriteLine (new string('-', 60));
            foreach (var file in foundFiles)
            {
                Console.WriteLine(file);
            }

        }

        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);

            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;

                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }

                if (next != null && next.Length != 0)
                {
                    foreach (var file in next)
                    {
                        yield return file;
                    }
                }

                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next)
                    {
                        pending.Push(subdir);
                    }
                }
                catch { }
            }
        }
    }
}
