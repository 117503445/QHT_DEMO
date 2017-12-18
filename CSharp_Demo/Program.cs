using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people.age = 1;
            Hi(people); Console.WriteLine(people.age);
            Console.ReadLine();
        }
       static void Hi(People people) {
            people.age = 2;
        }
    }
    public class People {
        public int age;
    }
}
