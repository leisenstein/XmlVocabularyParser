using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class IProperty
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Key { get; set; }
        public string Prompt { get; set; }
        public string Declaration { get; set; }


    }
}
