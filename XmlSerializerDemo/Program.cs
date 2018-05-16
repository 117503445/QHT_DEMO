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
            List<int> Var_list_int = new List<int> { 2, 3, 4, 5 };
            //string xml = XmlSerializer(Var_list_int);
            //Console.WriteLine(xml);

            Dictionary<object, object> d = new Dictionary<object, object>
            {
                { "key", "value" }
            };
            //string xml = XmlSerializer(d);
            //Console.WriteLine(xml);
            People people = new People();
            GC.Collect();
            Console.Read();
        }
        /// <summary>
        ///序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serialObject"></param>
        /// <returns></returns>
        public static string XmlSerializer<T>(T serialObject) where T : class
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(serialObject.GetType());
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.UTF8;
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, serialObject, emptyNamepsaces);
                return stream.ToString();
            }
        }
        /// <summary>
        ///反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xml) where T : class
        {
            using (var str = new StringReader(xml))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var result = (T)xmlSerializer.Deserialize(str);
                return result;
            }
        }
    }
}
