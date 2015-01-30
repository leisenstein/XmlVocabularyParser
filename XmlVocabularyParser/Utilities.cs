using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XmlVocabularyParser
{
    public static class Utilities
    {
        public static string tab1 = "   ";
        public static string tab2 = "      ";
        public static string tab3 = "         ";
        public static string tab4 = "            ";
        public static XmlDocument ConvertStringToXmlDocument(string xml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);

            return xd;
        }

        public static XmlDocument ConvertFileToXmlDocument(string filename)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(filename);

            return xd;
        }

        public static string GetXmlFromFile(string filename)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(filename);
            string xmlcontent = xd.InnerXml;
            return xmlcontent;
        }

        public static void WriteToOutput(string content) 
        {
            Console.WriteLine(content);
        }

        public static void WriteToOutput(string content, string filepath)
        {
            WriteStringToFile(content, filepath);
        }
        public static void WriteStringToFile(string content, string filepath)
        {
                String[] arrContent = { content };
                System.IO.File.AppendAllLines(filepath, arrContent);
            
        }

    }
}
