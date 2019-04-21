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
            int n = 1;
            double sum = 0;
            while (n < 10000)
            {
                sum += Math.Sin(Math.Sqrt(n * n + 1) * Math.PI);
                n++;
            }
            Console.WriteLine(n);
            Console.WriteLine(sum);
            Console.Read();
        }
    }

}
