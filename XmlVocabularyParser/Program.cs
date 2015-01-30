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
        public static string _INPUTFILEPATH;
        public static string _OUTPUTFILEPATH;

        static void Main(string[] args)
        {
            TV = new TemplateVocabulary();
            if (args != null && args.Length == 1)
            {
                _INPUTFILEPATH = args[0];
                _OUTPUTFILEPATH = args[0] + ".OUT";
                XmlDocument doc = Utilities.ConvertFileToXmlDocument(@_INPUTFILEPATH);
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
            Utilities.WriteToOutput(TV.ToString(), @_OUTPUTFILEPATH);
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
                    Utilities.WriteToOutput(newSection.ToString(), @_OUTPUTFILEPATH);
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
                    Utilities.WriteToOutput(prop.ToString(), @_OUTPUTFILEPATH);
                    break;
                case "IntProperty":
                    prop = new IntProperty();
                    prop.Process(n);
                    Utilities.WriteToOutput(prop.ToString(), @_OUTPUTFILEPATH);
                    break;
                case "BoolPropertyGroup":
                    prop = new BoolPropertyGroup();
                    prop.Process(n);
                    break;
                case "StringProperty":
                    prop = new StringProperty();
                    prop.Process(n);
                    Utilities.WriteToOutput(prop.ToString(), @_OUTPUTFILEPATH);
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
