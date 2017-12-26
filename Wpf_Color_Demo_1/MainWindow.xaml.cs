﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using Drawing = System.Drawing;
using System.ComponentModel;

namespace Wpf_Color_Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BackGroundWindow backGroundWindow = new BackGroundWindow();
            backGroundWindow.Show();


            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();


        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //    InBlackStyle(this);
        }

        /// <summary>
        /// true-黑色字体,false-白色字体
        /// </summary>
        /// <returns></returns>
        public static bool InBlackStyle(Window window)
        {
            Console.WriteLine("InBlackStyle");
            if (!window.IsVisible)
            {
                return false;
            }
            bool[] b = new bool[3];

            b[0] = IsBlack(window, 0, 0);

            b[1] = IsBlack(window, (int)window.Width / 2, (int)window.Height / 2);

            b[2] = IsBlack(window, (int)window.Width, (int)window.Height);


            int count = 0;
            foreach (var item in b)
            {
                if (item)
                {
                    count++;
                }
            }
            return count > 1;
        }
        /// <summary>
        /// true-黑色字体,false-白色字体
        /// </summary>
        /// <returns></returns>
        private static bool IsBlack(Window window, int deltaX, int deltaY)
        {
            int Settings_Default_dpi = 1;
            Drawing.Rectangle rc = new Drawing.Rectangle((int)window.Left + deltaX, (int)window.Top + deltaY, 1, 1);
            var bitmap = new Drawing.Bitmap(1, 1);
            using (Drawing.Graphics g = Drawing.Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen((int)(rc.X * Settings_Default_dpi), (int)(rc.Y * Settings_Default_dpi), 0, 0, rc.Size);
            }
            Drawing.Color color = bitmap.GetPixel(0, 0);
            bitmap.Dispose();
            if (color.R + color.G + color.B > 384)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //声明
            BackgroundWorker worker = new BackgroundWorker();

            // worker 要做的事情 使用了匿名的事件响应函数
            worker.DoWork += (o, ea) =>
            {
                //WPF中线程只能控制自己创建的控件，
                //如果要修改主线程创建的MainWindow界面的内容,
                //可以委托主线程的Dispatcher处理。
                //在这里，委托内容为一个匿名的Action对象。
                Dispatcher.Invoke((Action)(() =>
                {

                    Console.WriteLine("start");
                }));

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                   Console.WriteLine(InBlackStyle(this));
                }

            };
            // worker 完成事件响应
            worker.RunWorkerCompleted += (o, ea) =>
            {
                Dispatcher.Invoke((Action)(() =>
                {



                }));
            };

            //注意：运行了下面这一行代码，worker才真正开始工作。上面都只是声明定义而已。
            worker.RunWorkerAsync();
            Console.WriteLine("总" + sw.ElapsedMilliseconds);
        }
    }
}
