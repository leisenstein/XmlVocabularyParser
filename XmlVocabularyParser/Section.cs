using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class Section
    {
        public Section()
        {
            Properties = new List<IProperty>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public List<IProperty> Properties { get; set; }


        public override string ToString()
        {
            string val = "";
            val += Utilities.tab1 + "Section: " + this.Label;
            return val;
        }
    }
}
