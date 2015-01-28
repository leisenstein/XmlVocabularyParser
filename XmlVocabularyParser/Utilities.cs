using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlVocabularyParser
{
    public static class Utilities
    {
        public static XmlDocument ConvertToXmlDocument(string xml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);

            return xd;
        }






    }
}
