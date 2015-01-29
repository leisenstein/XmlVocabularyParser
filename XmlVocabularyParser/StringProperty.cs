using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlVocabularyParser
{
    class StringProperty : IProperty
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Key { get; set; }
        public string Prompt { get; set; }
        public string Declaration { get; set; }  // Optional

        public StringProperty()
        {

        }

        public void Process(XmlNode n)
        {
            StringProperty sp = new StringProperty();
            var _type = n.Name;
            var _key = n["Key"].InnerText;
            var _prompt = n["Prompt"].InnerText;

            var _declaration = n["Declaration"] != null ? n["Declaration"].InnerText : "";
            

            this.Id = -999;
            this.PropertyType = "String";
            this.Key = _key;
            this.Prompt = _prompt;
            this.Declaration = _declaration;
        }


        public override string ToString()
        {
            string val = "";
            val += Utilities.tab2 + this.Key + "|" + this.Declaration;
            return val;
        }
    }
}
