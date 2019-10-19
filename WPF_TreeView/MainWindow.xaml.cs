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

namespace WPF_TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTreeView();
        }
        /// <summary>
        /// 加载tree数据
        /// </summary>
        private void ShowTreeView()
        {
            List<propertyNodeItem> listItem = new List<propertyNodeItem>();
            propertyNodeItem mainNode = new propertyNodeItem()
            {
                DisplayName = "功能菜单",
                Name = "主目录--功能菜单"
            };

            propertyNodeItem systemNode = new propertyNodeItem()
            {
                DisplayName = "系统设置",
                Name = "当前菜单--系统设置"
            };
            propertyNodeItem pwdTag = new propertyNodeItem()
            {
                DisplayName = "密码修改",
                Name = "当前选项--密码修改"
            };
            systemNode.Children.Add(pwdTag);
            mainNode.Children.Add(systemNode);
            listItem.Add(mainNode);
            this.tvProperty.ItemsSource = listItem;
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public List<Location> childern { get; set; }
    }

    public class propertyNodeItem
    {
        public string Icon { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<propertyNodeItem> Children { get; set; }
        public propertyNodeItem()
        {
            Children = new List<propertyNodeItem>();
        }
    }
}
