﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PageDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (LsteCheck.IsSelected)
            //{
            //    FrameMain.Content = new Page1();
            //}
            //else if (LsteAbout.IsSelected)
            //{
            //    FrameMain.Content = new Page2();
            //}
          
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            //FrameMain.Content = new Page1();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            //FrameMain.Content = new Page2();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            //FrameMain.Content = new Page3();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            I.Strokes.Clear();
        }
    }
}
