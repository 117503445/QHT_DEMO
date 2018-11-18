using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            F();
            Console.Read();
        }
        static async void F()
        {
            List<Task<int>> a = new List<Task<int>>();
            for (int i = 10; i >= 1; i--)
            {
                a.Add(Sleep(i));
            }
            int n = 0;
            while (true)
            {
                if (n > 60)
                { break; }
                foreach (var item in a)
                {
                    if (item.IsCompleted)
                    {
                        Console.WriteLine(item.Result);
                    }
                }
                System.Threading.Thread.Sleep(100);
                n++;
            }

            Console.WriteLine("F End");
        }
        static async Task<int> Sleep(int time)
        {

            Console.WriteLine($"begin sleep {time} s");
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(time * 1000);
            });
            Console.WriteLine($"end sleep {time} s");
            return time;
        }
    }
}
