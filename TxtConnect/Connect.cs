using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtConnect
{
    public class Connect
    {
        /// <summary>
        /// 新建一个基于共享文件夹的连接
        /// </summary>
        /// <param name="netName">网民</param>
        /// <param name="path">路径,exp:@"\\192.168.2.233\FolderShare"</param>
        public Connect(string netName, string path)
        {
            this.netName = netName;
            this.path = path;
            mypath = path + "\\" + netName;
            connectPath = mypath + "\\Connect.txt";
        }
        /// <summary>
        /// 网名
        /// </summary>
        string netName = "";
        /// <summary>
        /// exp:@"\\192.168.2.233\FolderShare"
        /// </summary>
        string path = "";
        /// <summary>
        /// exp:@"\\192.168.2.233\FolderShare\ip"
        /// </summary>
        string mypath = "";
        /// <summary>
        /// exp:@"\\192.168.2.233\FolderShare\ip\Connect.txt"
        /// </summary>
        string connectPath = "";
        /// <summary>
        /// 监控连接文件
        /// </summary>
        FileSystemWatcher Watcher = new FileSystemWatcher();
        /// <summary>
        /// 任务清单
        /// </summary>
        List<Task> tasks = new List<Task>();

        public delegate void InfoHandler();
        /// <summary>
        /// tasks发生更新,要求刷新
        /// </summary>
        public event InfoHandler ShowInfo;

        public delegate void MethodHandler(string in_methodName, string in_methodParameters, out string out_methodName,out string out_methodParameters);
        /// <summary>
        /// 向外部类请求结果
        /// </summary>
        public event MethodHandler GetMethod;

        /// <summary>
        /// 任务
        /// </summary>
        class Task
        {
            /// <summary>
            /// 发送者
            /// </summary>
            public string sender = "";
            /// <summary>
            /// 是否已经被处理
            /// </summary>
            public bool Handled = false;
            /// <summary>
            /// 方法名
            /// </summary>
            public string methodName = "";
            /// <summary>
            /// 方法参数
            /// </summary>
            public string methodParameters = "";
            public override string ToString()
            {
                return string.Format("{0};{1};{2};{3}", sender, Handled, methodName, methodParameters);
            }
        }
        /// <summary>
        /// 似乎文件发生了改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Watcher_Changed");
            Thread.Sleep(100);//睡一会,防止线程占用
            LoadConnectTxt();
            HandleTasks();
            WriteConnectTxt();
            ShowInfo();
        }
        /// <summary>
        /// 读取Connect.txt,更新任务清单
        /// </summary>
        private void LoadConnectTxt()
        {
            Console.WriteLine("LoadConnectTxt");
            tasks = GetTask(File.ReadAllLines(connectPath, Encoding.Default).ToList());
        }
        /// <summary>
        /// 将任务清单写入Connect.txt
        /// </summary>
        private void WriteConnectTxt()
        {
            Console.WriteLine("WriteConnectTxt");
            Watcher.EnableRaisingEvents = false;
            List<string> list = new List<string>();
            for (int i = 0; i < tasks.Count; i++)
            {
                list.Add(tasks[i].ToString());
            }
            File.WriteAllLines(connectPath, list);
            Watcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// 将字符串转化为任务清单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<Task> GetTask(List<string> list)
        {
            List<Task> tasks = new List<Task>();
            foreach (var item in list)
            {
                string[] s = item.Split(';');
                try
                {
                    tasks.Add(new Task { sender = s[0], Handled = bool.Parse(s[1]), methodName = s[2], methodParameters = s[3] });
                }
                catch (Exception)
                {
                }


            }
            return tasks;
        }
        /// <summary>
        /// 处理任务清单
        /// </summary>
        private void HandleTasks()
        {
            Console.WriteLine("HandleTasks");
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Handled == false && tasks[i].sender == "server")
                {
                    HandleTask(tasks[i]);
                }
            }

        }
        /// <summary>
        /// 处理单个的任务
        /// </summary>
        private void HandleTask(Task task)
        {
          GetMethod(task.methodName,task.methodParameters,out string out_methodName,out string out_methodParameters);
            //Type type = typeof(MethodCollection);
            //object[] parameters = task.methodParameters.Split(',');
            //string result = (string)type.GetMethod(task.methodName).Invoke(null, parameters);
            task.Handled = true;//已处理该任务
            Task newTask = new Task
            {
                sender = netName,
                Handled = false,
                methodName = out_methodName,
                methodParameters = out_methodParameters
            };
            tasks.Add(newTask);
        }
    }
}
