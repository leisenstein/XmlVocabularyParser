﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlVocabularyParser
{
    class BoolProperty : IProperty
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Key { get; set; }
        public string Prompt { get; set; }
        public string Declaration { get; set; }
        public string Explanation { get; set; }

        public BoolProperty()
        {

        }
      

        public void Process(XmlNode n)
        {
            var _type = n.Name;
            var _key = n["Key"].InnerText;
            var _prompt = n["Prompt"].InnerText;
            var _explanation = n["Explanation"] != null ? n["Explanation"].InnerText : "";
            var _declaration = n["Declaration"] != null ? n["Declaration"].InnerText : "";

            this.Id = -999;
            this.PropertyType = "Bool";
            this.Key = _key;
            this.Prompt = _prompt;
            this.Declaration = _declaration;
            this.Explanation = _explanation;


            // return this;
        }

        public override string ToString()
        {
            // if in BoolPropertyGroup, add and extra tab
            string val = "";

            val += Utilities.tab2 + this.Key + "|" + this.Declaration + "|" + this.Explanation;

            return val;
        }
        
    }
}
