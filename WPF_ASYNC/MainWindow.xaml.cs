using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_ASYNC
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = (await Do()).ToString();
        }
        private Task<bool> Do()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                Txt.Dispatcher.Invoke(()=> {   Txt.Text = "Hello";});
              
                Thread.Sleep(3000);
                return false;
            });

        }
    }
}
