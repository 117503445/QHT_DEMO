using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Demo
{
    class EventDemo
    {
        public static void Main()
        {
            Clicent c = new Clicent();
            c.Shijian += Handle1;
            c.Shijian += Handle2;
            c.Call();
            Console.ReadLine();
        }
        static void Handle2(out string s1, out string s2)
        {
            s1 = "Handle2,s1";
            s2 = "Handle2,s2";
        }
        static void Handle1(out string s1, out string s2)
        {
            s1 = "Handle1,s1";
            s2 = "Handle1,s2";
        }
        static string Hello() { return "Hello"; }
    }
    class Clicent
    {
        public delegate void weituo(out string s1, out string s2);
        public event weituo Shijian;
        public void Call()
        {
            Shijian(out string s1, out string s2);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }


    }
}
