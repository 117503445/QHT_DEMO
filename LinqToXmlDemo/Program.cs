using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace LinqToXmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("1.xml");
            var i =( from x in d.Root.Elements() where x.Attribute("checkKind").Value== "NightStudy"&&x.Attribute("dayOfWeek").Value=="3" select x).Last();
            //i.SetAttributeValue("missId", "1,2,3");
            // d.Save("1.xml");
            if (i==null)
            {
                Console.WriteLine(78);
            }
            Console.Read();
          
        }
    }
}
