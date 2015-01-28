using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class TemplateVocabulary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public List<Section> Sections { get; set; }



    }
}
