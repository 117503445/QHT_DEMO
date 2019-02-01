using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct s = new MyStruct();
            s.num++;
            Console.WriteLine(s.num);
        }
    }
    struct MyStruct
    {
        public double num;
    }
}
