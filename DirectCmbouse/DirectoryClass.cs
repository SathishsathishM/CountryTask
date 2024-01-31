using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectCmbouse
{
   public class DirectoryClass
    {
        public bool StoreData(string path, string Content)
        {
            File.WriteAllText(path, Content);
            return true;
        }
        public string ReadData(string path)
        {
            return File.ReadAllText(path);
        }
        public string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
        public string RootFilepath(string baseFolderpath)
        {
            string rootpath = System.Environment.CurrentDirectory;
            int binindex = rootpath.IndexOf("bin");
            rootpath = rootpath.Remove(binindex);
            return Path.Join(rootpath,baseFolderpath);
        }
    }
    
}   
 
