using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        string filePath = @"D:\MyServiceLog.txt";
        protected override void OnStart(string[] args)
        {
            File.AppendAllText(filePath,"OK"+DateTime.Now.ToString());
        }

        protected override void OnStop()
        {
            File.AppendAllText(filePath, "Stop" + DateTime.Now.ToString());
        }
    }
}
