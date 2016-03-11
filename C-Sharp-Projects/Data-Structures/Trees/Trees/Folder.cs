namespace Trees
{
    using System.Collections.Generic;
    using System.Numerics;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; private set; }

        public ICollection<File> Files { get; private set; }

        public ICollection<Folder> ChildFolders { get; private set; }

        public BigInteger TotalSize
        {
            get
            {
                BigInteger size = 0;
                foreach (var file in this.Files)
                {
                    size += file.Size;
                }

                foreach (var folder in this.ChildFolders)
                {
                    size += folder.TotalSize;
                }

                return size;
            }
        }
    }
}