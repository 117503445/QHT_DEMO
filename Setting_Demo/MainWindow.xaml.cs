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
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Setting_Demo
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

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            MainWindow[] mainWindows = new MainWindow[9];
            Random random = new Random();
            for (int i = 0; i < mainWindows.Length; i++)
            {
                mainWindows[i] = new MainWindow();
                //   mainWindows[i].PointToScreen
                list.Add(new Windows(mainWindows[i], random.Next(), random.Next()));
            }


        }
        List<Windows> list = new List<Windows>();
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, list);
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = File.OpenRead("user.dat"))
            {
                list = binaryFormatter.Deserialize(fileStream) as List<Windows>;
            }
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("---Begin---");
            foreach (var item in list)
            {
                Console.WriteLine(item.X);
            }
            Console.WriteLine("---End---");
        }
    }
    [Serializable]
    public class Windows
    {
        [NonSerialized]
        Window window;
        int x;
        int y;

        public Windows(Window window, int x, int y)
        {
            this.window = window;
            this.x = x;
            this.y = y;
        }

        public Window Window { get => window; set => window = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
