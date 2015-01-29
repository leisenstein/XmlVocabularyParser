using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class TemplateVocabulary
    {
        public TemplateVocabulary()
        {
            Sections = new List<Section>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public List<Section> Sections { get; set; }



        public override string ToString()
        {
            string val = "";
            val += this.Label;
            return val;
        }
    }
}
