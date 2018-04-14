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
            int length = 6;
            bool[] a = new bool[6];
            int n = 0;
            Console.WriteLine("***0414卷子15题***");
            Console.WriteLine("数字顺序是这样的");
            Console.WriteLine("0 3 5");
            Console.WriteLine("1 4");
            Console.WriteLine("2");
            Console.WriteLine("***开始枚举***");
     
            for (int i1 = 0; i1 < length; i1++)
            {
                //a[i1] = true;
                //Console.WriteLine(Check(i1, a));
                if (!Check(i1, a))
                {
                    continue;
                }
                for (int i2 = 0; i2 < length; i2++)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (i == i1)
                        {
                            a[i] = true;
                        }
                        else
                        {
                            a[i] = false;
                        }
                    }
                    if (!Check(i2, a))
                    {
                        continue;
                    }
                    for (int i3 = 0; i3 < length; i3++)
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (i == i1 | i == i2)
                            {
                                a[i] = true;
                            }
                            else
                            {
                                a[i] = false;
                            }
                        }
                        if (!Check(i3, a))
                        {
                            continue;
                        }
                        for (int i4 = 0; i4 < length; i4++)
                        {
                            for (int i = 0; i < a.Length; i++)
                            {
                                if (i == i1 | i == i2 | i == i3)
                                {
                                    a[i] = true;
                                }
                                else
                                {
                                    a[i] = false;
                                }
                            }
                            if (!Check(i4, a))
                            {
                                continue;
                            }
                            for (int i5 = 0; i5 < length; i5++)
                            {
                                for (int i = 0; i < a.Length; i++)
                                {
                                    if (i == i1 | i == i2 | i == i3 | i == i4)
                                    {
                                        a[i] = true;
                                    }
                                    else
                                    {
                                        a[i] = false;
                                    }
                                }
                                if (!Check(i5, a))
                                {
                                    continue;
                                }
                                for (int i6 = 0; i6 < length; i6++)
                                {
                                    for (int i = 0; i < a.Length; i++)
                                    {
                                        if (i == i1 | i == i2 | i == i3 | i == i4 | i == i5)
                                        {
                                            a[i] = true;
                                        }
                                        else
                                        {
                                            a[i] = false;
                                        }
                                    }
                                    if (!Check(i6, a))
                                    {
                                        continue;
                                    }
                                    Console.WriteLine($"{i1},{i2},{i3},{i4},{i5},{i6}");
                                    n++;
                                }

                            }
                        }
                    }
                }
            }
            Console.WriteLine("***结束枚举***");
            Console.WriteLine("共计 "+n);
            Console.Read();
        }
        static bool Check(int i, bool[] a)
        {
            if (a[i] == true)
            {
                return false;
            }
            switch (i)
            {
                case 0:
                    if (a[1] == false)
                    {
                        return false;
                    }
                    break;
                case 1:
                    if (a[2] == false)
                    {
                        return false;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    if (a[4] == false)
                    {
                        return false;
                    }
                    break;
                case 4:
                    break;
                case 5: break;
                default:
                    break;
            }
            return true;
        }
    }
}
