using System;
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
using Library;
namespace CHT_DLL_Demo
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Area.MainWindow = this;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Area.Settings.Flush();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Txt.Text = Area.Settings.Test.ToString();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Area.Settings.Test += 1;
        }

        public void PropertyChanged(object sender, UPropertyChangedEventargs e)
        {
            if (sender.Equals(Area.Settings.test))
            {
                Txt.Text = ((int)e.Newvalue).ToString();

            }

        }
    }
}
