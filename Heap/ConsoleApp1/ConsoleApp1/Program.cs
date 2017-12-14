using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        private static Folder GetFolder()
        {
            var folder11 = new Folder
            {
                Names = new List<string> { }
            };
            var folder12 = new Folder
            {
                Names = new List<string> { }
            };
            var folder21 = new Folder
            {
                Names = new List<string> { "1", "2" }
            };
            var folder22 = new Folder
            {
                Names = new List<string> { }
            };

            var folder1 = new Folder
            {
                Folders = new List<Folder> { folder11, folder12 }
            };
            var folder2 = new Folder
            {
                Folders = new List<Folder> { folder21, folder22 }
            };

            var root = new Folder()
            {
                Folders = new List<Folder> { folder1, folder2 }
            };

            return root;
        }
    }
    class Folder
    {
        public List<string> Names { get; set; }
        public List<Folder> Folders { get; set; }

        public Folder()
        {
            Names = new List<string>();
            Folders = new List<Folder>();
        }

        public void DeleteEmptyFolders()
        {
            foreach (var folder in Folders)
            {
                if (folder.Folders.Count.Equals(0))
                {
                    Folders.Remove(folder);
                }
            }
        }
    }


}
