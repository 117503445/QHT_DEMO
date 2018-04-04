using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = a(System.Math.Sqrt(2), 0);
            Console.WriteLine(i);
            Console.Read();
        }
        static double a(double b,int n) {
            if (n==2016)
            {
                return b;
            }
            n++;
            b = b + 1 / b;
            return a(b, n);
        }
    }
}
