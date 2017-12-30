using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventArgsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people.Fuck += People_Fuck;
            people.Say();
            Console.ReadLine();
        }

        private static void People_Fuck(object sender, People.FuckEventArgs e)
        {
            Console.WriteLine(e.a1);
        }
    }
    class People
    {
        public delegate void FuckHandler(object sender, FuckEventArgs e);
        public event FuckHandler Fuck;
        public void Say()
        {
            Fuck(this, new FuckEventArgs(1, 2, 0, 0));
            Console.WriteLine("Said");
        }
        public class FuckEventArgs : EventArgs
        {
            public int a1;
            int a2;
            int a3;
            int a4;

            public FuckEventArgs(int a1, int a2, int a3, int a4)
            {
                this.a1 = a1;
                this.a2 = a2;
                this.a3 = a3;
                this.a4 = a4;
            }
        }
    }
}
