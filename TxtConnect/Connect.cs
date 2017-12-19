using System;
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
        /// 任务清单
        /// </summary>
        List<Task> tasks = new List<Task>();
        /// <summary>
        /// 读取Connect.txt,更新任务清单
        /// </summary>
        private void LoadConnectTxt()
        {
            tasks = GetTask(File.ReadAllLines(connectPath, Encoding.Default).ToList());
           
        }
        /// <summary>
        /// 将任务清单写入Connect.txt
        /// </summary>
        private void WriteConnectTxt()
        {
            List<string> list = new List<string>(tasks.Count);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = tasks[i].ToString();
            }
            File.WriteAllLines(connectPath, list);
            LoadConnectTxt();
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
    }
}
