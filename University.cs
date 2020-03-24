using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2
{
    public class University
    {
        [XmlAttribute(attributeName: "createdAt")]
        public string createdAt { get; set; }
        [XmlAttribute(attributeName: "author")]
        public string author { get; set; }
        public HashSet<Student> students { get; set; }

        
        public StudyCount activeStudies { get; set; }

        

    }
}
