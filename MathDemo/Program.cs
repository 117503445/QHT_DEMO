﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //for (int a = 1; a < 10; a++)
            //{
            //    for (int b = 1; b < 10; b++)
            //    {
            //        for (int c = 1; c < 10; c++)
            //        {
            //            bool r = (a + b + c > 0) &&
            //                (a - b + c > 0) &&
            //                (2 * a > b) &&
            //                (b * b - 4 * a * c > 0);
            //            if (r)
            //            {
            //                //Console.WriteLine("{0},{1},{2}",a,b,c);
            //            }

            //        }
            //    }
            //}


            //for (double a = 0.1; a < 10; a += 0.1)
            //{

            //    for (double b = 0.1; b < 10; b += 0.1)
            //    {
            //        double d = (3 * a + b) * (3 * b + a) / (a * b);
            //        if (d <= 16)
            //        {
            //            //Console.WriteLine(d);
            //        }

            //    }
            //}
            ////int maxz = 0, maxx = 0, maxy = 0;
            ////for (int x = 0; x < 20; x++)
            ////{
            ////    for (int y = 0; y < 20; y++)
            ////    {
            ////        bool r = (1000 * x + 600 * y <= 8000) &&
            ////            (18 * x + 15 * y <= 180);
            ////        if (r)
            ////        {
            ////            int z = 200 * x + 150 * y;
            ////            if (z > maxz)
            ////            {
            ////                maxz = z;
            ////                maxx = x;
            ////                maxy = y;
            ////            }
            ////        }
            ////    }
            ////}
            ////Console.WriteLine("{0},{1},{2}", maxz, maxx, maxy);
            //int max=0;string s = "";
            //for (int x = 0; x < 100; x++)
            //{
            //    for (int y = 0; y < 100; y++)
            //    {
            //        bool r = x >= 0 && y >= 0 && 100 - x - y >= 0 && x + 3 * y <= 200;
            //        if (r)
            //        {
            //            int w = 300+2*x+3*y;
            //            if (w>max)
            //            {
            //                max = w;
            //                s = x.ToString() + y.ToString();
            //            }

            //        }
            //    }
            //}
            //Console.WriteLine(max);
            //Console.WriteLine(s);
            double[] a = new double[200];
            a[1] = 2;
            for (int i = 1; i < a.Length-1; i++)
            {
                a[i + 1] = Math.Sqrt(a[i] *a[i] + 4);
                //Console.WriteLine(a[i]);
            }
            double[] b = new double[200];
            for (int i = 2; i < 200; i++)
            {
                b[i] = 1 / (a[i - 1] + a[i]);
            }
            double sum = 0;
            for (int i = 0; i < b.Length; i++)
            {
                sum += b[i];
                Console.WriteLine(sum);
                if (Math.Abs( sum-5)<0.0001)
                {
                    Console.WriteLine("!====!");
                    Console.WriteLine(i);
                }
            }
            Console.Read();
        }
    }
}