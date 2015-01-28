using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace XmlVocabularyParser
{
    class Program
    {
        static void Main(string[] args)
        {



        }



        private void ProcessRoot(XmlDocument x)
        {
            XmlNodeList sections = x.GetElementsByTagName("Section");

            foreach (XmlNode n in sections)
            {
                var sectionLabel = n.PreviousSibling.InnerText;
                ProcessSection(n);
            }
        }

        private void ProcessSection(XmlNode n)
        {
            XmlNodeList properties = n.ChildNodes;
            foreach (XmlNode p in properties)
            {
                ProcessProperty(p);
            }
        }

        private void ProcessProperty(XmlNode n)
        {
            
        }
    }
}
