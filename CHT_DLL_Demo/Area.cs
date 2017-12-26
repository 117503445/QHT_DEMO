using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
namespace CHT_DLL_Demo
{
    public static class Area
    {
        public static string LocalFolder => AppDomain.CurrentDomain.BaseDirectory;
         static Settings settings = new Settings();
        public static Settings Settings => settings;

        public static MainWindow MainWindow { get => mainWindow; set => mainWindow = value; }

        static MainWindow mainWindow;

    }
    public sealed class Settings
    {

        //实现自动保存设置的类声明.
        public class Property<TValue> : UProperty<TValue>
        {
            protected override string Folder => Area.LocalFolder;
            protected override string RootName => "Settings";
            public Property(string name, TValue value) : base(name, value)
            {
            }
        }
        public Property<int> test = new Property<int>("test", 10);
        public int Test { get => test.Value; set => test.Value = value; }

        public void Flush()
        {
            test.UPropertyChanged += Area.MainWindow.PropertyChanged;
            dynamic t;
            t = Test;
        }
    }
}
