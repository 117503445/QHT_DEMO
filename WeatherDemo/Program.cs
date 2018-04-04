using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s = WeatherDemo.cn.com.webxml.www;
namespace WeatherDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            s.WeatherWebService weather = new s.WeatherWebService();
            string[] s = weather.getWeatherbyCityName("杭州");
            int i = 0;
            foreach (var item in s)
            {
                Console.WriteLine(i + " " + item);
                i++;
            }
            Console.Read();
        }
    }
}
