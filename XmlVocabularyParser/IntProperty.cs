using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlVocabularyParser
{
    class IntProperty : IProperty
    {
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
    }
}
