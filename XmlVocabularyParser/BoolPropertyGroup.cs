using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlVocabularyParser
{
    class BoolPropertyGroup : IProperty
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Prompt { get; set; }
        public string Declaration { get; set; }
        public List<BoolProperty> BoolProperties { get; set; }

        public BoolPropertyGroup()
        {
            BoolProperties = new List<BoolProperty>();
        }
        public void Process(XmlNode n)
        {
            // First, Get Prompt and Declaration
            var _prompt = n["Prompt"].InnerText;
            var _declaration = n["Declaration"] != null ? n["Declaration"].InnerText : "";

            this.Id = -999;
            this.PropertyType = "BoolPropertyGroup";
            this.Prompt = _prompt;
            this.Declaration = _declaration;



            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(n.OuterXml);
            XmlNode newNode = xdoc.Clone();




            XmlNodeList boolProperties = newNode.SelectNodes("/BoolPropertyGroup/BoolProperty");
            Console.WriteLine(this.ToString());
            foreach (XmlNode bp in boolProperties)
            {
                BoolProperty prop = new BoolProperty();
                prop.Process(bp);
                Console.WriteLine(Utilities.tab1 + prop.ToString());

                BoolProperties.Add(prop);
            }

        }


        public override string ToString()
        {
            string val = "";
            val += Utilities.tab2 + "GROUP: " + this.Declaration;
            return val;
        }


    }
}
