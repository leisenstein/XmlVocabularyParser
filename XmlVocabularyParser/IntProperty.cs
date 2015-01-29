using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlVocabularyParser
{
    class IntProperty : IProperty
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Key { get; set; }
        public string Prompt { get; set; }
        public string Declaration { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }

        public IntProperty()
        {

        }
       


        public void Process(XmlNode n)
        {
            var _type = n.Name;
            var _key = n["Key"].InnerText;
            var _prompt = n["Prompt"].InnerText;
            var _declaration = n["Declaration"] != null ? n["Declaration"].InnerText : "";
            var _rangemin = n["RangeValidator"].GetAttribute("min");
            var _rangemax = n["RangeValidator"].GetAttribute("max");

            this.Id = -999;
            this.PropertyType = "Int";
            this.Key = _key;
            this.Prompt = _prompt;
            this.Declaration = _declaration;
            this.RangeMin = Convert.ToInt32(_rangemin);
            this.RangeMax = Convert.ToInt32(_rangemax);
        }


        public override string ToString()
        {
            string val = "";
            val += Utilities.tab2 + this.Key + "|" + this.Declaration;
            return val;
        }
    }
}
