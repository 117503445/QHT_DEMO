using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Trim_temp
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\117503445\Desktop\PPT听课手册配套课件";
            foreach (var item in Directory.GetDirectories(rootPath))
            {
                foreach (var i in Directory.GetFiles(item))
                {
                    string old = i;
                    string news = i.Replace(' ','_'); 
                    File.Move(old,news);
                }
            }
            Console.Read();
        }
    }
}
