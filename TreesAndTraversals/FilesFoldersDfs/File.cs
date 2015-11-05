namespace FilesFoldersDfs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class File : IDiretory
    {
        public string Name { get; set; }

        public long Size { get; set; }
    }
}
