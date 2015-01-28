using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class Section
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<IProperty> Properties { get; set; }
    }
}
