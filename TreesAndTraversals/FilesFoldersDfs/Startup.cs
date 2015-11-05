namespace FilesFoldersDfs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            Folder root = new Folder { Name = "D:\\Telerik\\DSA\\" };

            var result = GetFiles(root, "*.js");

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Getting all files in stack with recursion" + result.Count());
            Console.WriteLine(new string('-', 60));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(result.Count());
        }


        public static IEnumerable<string> GetFiles(IDiretory root, string searchPattern)
        {
            Stack<IDiretory> pendingFolders = new Stack<IDiretory>();
            pendingFolders.Push(root);

            while (pendingFolders.Count != 0)
            {
                var path = pendingFolders.Pop();
                string[] next = null;

                try
                {
                    next = Directory.GetFiles(path.Name, searchPattern);
                }
                catch { }

                if (next != null && next.Length != 0)
                {
                    foreach (var file in next)
                    {
                        File newFile = new File() {Name = file, Size = new FileInfo(file).Length};
                        pendingFolders.Push(newFile);

                        yield return file;
                    }
                }

                try
                {
                    next = Directory.GetDirectories(path.Name);
                    foreach (var subdir in next)
                    {
                        Folder folder = new Folder() {Name = subdir};
                        pendingFolders.Push(folder);
                    }
                }
                catch { }
            }
        }
    }
}
