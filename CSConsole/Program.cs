using System;

namespace CSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            A a = new A();
            a.F += A_F;
            a.F += A_F;
            a.S();
        }

        private static void A_F(object sender, EventArgs e)
        {
            Console.WriteLine(1);
        }
    }
    public class A
    {
        public event EventHandler F;
        public void S()
        {
            F(null, null);
        }
    }
}
