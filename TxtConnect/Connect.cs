﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtConnect
{
    public class Connect
    {
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
        /// 任务清单
        /// </summary>
        List<Task> tasks = new List<Task>();
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

            Type type = typeof(MethodCollection);
            object[] parameters = task.methodParameters.Split(',');
            // MethodCollection methodCollection = new MethodCollection();
            string result = (string)type.GetMethod(task.methodName).Invoke(null, parameters);

            task.Handled = true;//已处理该任务


            Task newTask = new Task
            {
                sender = netName,
                Handled = false,
                methodName = "return",
                methodParameters = result
            };
            tasks.Add(newTask);
        }
    }
}
