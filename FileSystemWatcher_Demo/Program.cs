using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcher_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher f = new FileSystemWatcher
            {
                Path = @"E:\Project\QHT_DEMO\FileSystemWatcher_Demo\bin\Debug",
                Filter = "*.txt",
                IncludeSubdirectories = true,
                EnableRaisingEvents = true
            };
           
            f.Changed += F_Changed;
            f.Created += F_Created;
            Console.Read();
        }

        private static void F_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Created");
        }

        private static void F_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed");
        }
    }
}
