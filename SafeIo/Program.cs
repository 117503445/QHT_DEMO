using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SafeIo
{
    class Program
    {
        static void Main(string[] args)
        {
            //RubbishIo rubbishIo = new RubbishIo();
            //  rubbishIo.Hold();
            SafeIO.OverTime = 10000;
            SafeIO.SafeWriteAllText("1.txt", "I am safe");
            string r = "";
            while (r != "1")
            {
                r = Console.ReadLine();
                if (r == "c")
                {
                    //rubbishIo.LetItGo();
                }
            }

        }

    }
    class RubbishIo
    {
        FileStream fileStream;
        public void Hold()
        {
            string path = "1.txt";
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None);
        }
        public void LetItGo()
        {
            fileStream.Close();
            Console.WriteLine("Let it go ~");
        }
    }
    static class SafeIO
    {
        /// <summary>
        /// 最大超时时间(ms)
        /// </summary>
        private static int overTime = 3000;
        /// <summary>
        /// 每次尝试的时间间隔(ms)
        /// </summary>
        private static int interval = 500;

        public static int OverTime { get => overTime; set => overTime = value; }
        public static int Interval { get => interval; set => interval = value; }

        /// <summary>
        /// 安全的WriteAllText
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void SafeWriteAllText(string path, string text)
        {
            if (WaitUntilSafe(path))
            {
                File.WriteAllText(path, text);
            }
        }
        /// <summary>
        /// 直到文件可访问才放弃控制(同步),若文件可用则返回true
        /// </summary>
        private static bool WaitUntilSafe(string path)
        {

            int nowTime = 0;
            while (IsFileInUse(path))
            {
                Console.WriteLine("It's Using!!!");
                Thread.Sleep(Interval);
                nowTime += Interval;
                if (nowTime > OverTime)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }
    }
}
