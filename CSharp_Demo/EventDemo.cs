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
            c.PEvent += Handle;
            c.Call("");
            Console.ReadLine();
        }
        static string Handle(string s) { return Hello(); }
        static string Hello() { return "Hello"; }
    }
    class Clicent
    {
        public delegate string P(string s);
        public event P PEvent;
        public void Call(string receive)
        {
            string result = PEvent(receive);
            Console.WriteLine(result);
        }


    }
}
