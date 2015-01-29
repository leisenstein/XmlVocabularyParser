using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace XmlVocabularyParser
{
    class Program
    {
        public static TemplateVocabulary TV;
        static void Main(string[] args)
        {
            TV = new TemplateVocabulary();
            string filepath;
            if (args != null && args.Length == 1)
            {
                filepath = args[0];
                XmlDocument doc = Utilities.ConvertFileToXmlDocument(@filepath);
                Program programInstance = new Program();
                programInstance.ProcessRoot(doc);
            }
            else
            {
                Console.WriteLine("Usage: XmlVocabularyParser.exe <Full-Path-To-XML-File>");
            }
            
        }



        private TemplateVocabulary ProcessRoot(XmlDocument x)
        {
            var vocabularyLabels = x.GetElementsByTagName("Label");
            var firstLabel = vocabularyLabels[0].InnerText;
            
            TV.Label = firstLabel;

            XmlNodeList sections = x.GetElementsByTagName("Section");
            Console.WriteLine(TV);
            foreach (XmlNode n in sections)
            {
                var sectionLabel = n.PreviousSibling.InnerText;
                TV.Sections.Add(ProcessSection(n));
            }

            return TV;
        }

        private Section ProcessSection(XmlNode n)
        {
            Section newSection = new Section();

            XmlNodeList properties = n.ChildNodes;
            foreach (XmlNode p in properties)
            {
                if (p.Name == "Label")
                {
                    newSection.Label = p.InnerText;
                    Console.WriteLine(newSection.ToString());
                }
                else
                {
                    newSection.Properties.Add(ProcessProperty(p));
                }
                
            }

            return newSection;
        }

        private IProperty ProcessProperty(XmlNode n)
        {
            // TODO: Get the Property Type
            var propertyType = n.Name;

            IProperty prop;
            switch (propertyType)
            {
                case "BoolProperty":
                    prop = new BoolProperty();
                    prop.Process(n);
                    Console.WriteLine(prop.ToString());
                    break;
                case "IntProperty":
                    prop = new IntProperty();
                    prop.Process(n);
                    Console.WriteLine(prop.ToString());
                    break;
                case "BoolPropertyGroup":
                    prop = new BoolPropertyGroup();
                    prop.Process(n);
                    break;
                case "StringProperty":
                    prop = new StringProperty();
                    prop.Process(n);
                    Console.WriteLine(prop.ToString());
                    break;
                default:
                    prop = null;
                    break;

            }

            // TODO: Create and Process that PropertyType
            return prop;

        }
    }
}
