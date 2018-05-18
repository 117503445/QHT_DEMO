using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializableDictionary<object, object> d2 = new SerializableDictionary<object, object>
            {
                { "var_str_hello", "hello" }
            };

            //SerializableDictionary<object, object> d = new SerializableDictionary<object, object>
            //{
            //    { "key", "value" }
            //};

            List<int> list = new List<int> { 2, 3 ,4};

            //d2.Add("DICT", d);
            //d2.Add("TList", list);
            d2.Add("int_123","123");
            d2.Add("int_456", 456);
            d2.Add("int_789", 789);

            //using (FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write))
            //using (FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write))
            //{
            //    //在进行XML序列化的时候，在类中一定要有无参数的构造方法(要使用typeof获得对象类型)
            //    XmlSerializer xml = new XmlSerializer(typeof(SerializableDictionary<object, object>));
            //    xml.Serialize(fs, d);
            //}
            using (FileStream fs = new FileStream("2.xml", FileMode.Create, FileAccess.Write))
            {
                //在进行XML序列化的时候，在类中一定要有无参数的构造方法(要使用typeof获得对象类型)
                XmlSerializer xml = new XmlSerializer(typeof(SerializableDictionary<object, object>));
                xml.Serialize(fs, d2);
            }
            
            SerializableDictionary<object, object> i;
            using (FileStream fs = new FileStream("2.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(SerializableDictionary<object, object>));
                i = (SerializableDictionary<object, object>)xml.Deserialize(fs);
            }
            foreach (var item in i)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }

            //string xml = XmlSerializer(d);
            //Console.WriteLine(xml);
            Console.Read();
        }

    }
}
