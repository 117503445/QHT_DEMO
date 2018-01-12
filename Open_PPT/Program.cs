using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_PPT
{
    class Program
    {
        static void Main(string[] args)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Office\root\Office16\POWERPNT.EXE";
            cmd.StartInfo.Arguments = @"C:\Users\117503445\Desktop\1.ppt";
            cmd.Start();

        }
    }
}
