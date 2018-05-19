using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DEMO1");
            //   XmlReader reader = XmlReader.Create();
            XmlReader reader = XmlReader.Create(@"C:\User\File\Project_qht\QHT_DEMO\XmlSerializerDemo\bin\Debug\2.xml");

            SerializableDictionary<string, object> Variables = new SerializableDictionary<string, object>();
            Variables.Add("int_1", 1);
            Variables.Add("str_s", "s");
            Variables.Add("list", new List<int>() { 2, 3 });
            Variables.Add("p",new People() { Age=1});
            using (FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write))
            {
                //在进行XML序列化的时候，在类中一定要有无参数的构造方法(要使用typeof获得对象类型)
                XmlSerializer xml = new XmlSerializer(typeof(SerializableDictionary<string, object>));
                xml.Serialize(fs, Variables);
            }
            using (FileStream fs = new FileStream("1.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(SerializableDictionary<string, object>));
                Variables = (SerializableDictionary<string, object>)xml.Deserialize(fs);
            }
            foreach (var item in Variables)
            {
                Console.WriteLine(item.Key + "  " + item.Value);
                if (item.Value is List<int> list)
                {
                    foreach (var i in list)
                    {
                        Console.WriteLine(i);

                    }
                }
                if (item.Value is People people)
                {
                    Console.WriteLine(people.Age);
                }
            }
            //using (FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write))
            //{
            //    XmlSerializer xml = new XmlSerializer(typeof(int));
            //    var i = 2;
            //    xml.Serialize(fs, i);
            //}

            //using (FileStream fs = new FileStream("1.xml", FileMode.Open, FileAccess.Read))
            //{
            //    XmlSerializer xml = new XmlSerializer(typeof(int));
            //    var i = (int)xml.Deserialize(fs); Console.WriteLine(i);
            //}




            Console.Read();
        }


    }        public class People
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
}
