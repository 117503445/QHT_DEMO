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
        D de = new D(IsBlack);
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
            Thread.Sleep(5000);
            bool b = true;
            window.Dispatcher.Invoke(new Action(delegate
                {

                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    int Settings_Default_dpi = 3;

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
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                }));
            return b;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool d = false;
            if (d)
            {
                for (int i = 0; i < 20; i++)
                {
                    InBlackStyle(this);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                de.BeginInvoke(this, 0, 0, new AsyncCallback(Done), null);
                }



            }
            Console.WriteLine("总" + sw.ElapsedMilliseconds);
        }
        void Done(IAsyncResult itfAR)
        {
            AsyncResult ar = (AsyncResult)itfAR;
            D b = (D)ar.AsyncDelegate;
            Console.WriteLine(b.EndInvoke(itfAR));
        }
        public delegate bool D(Window window, int x, int y);
    }
}
