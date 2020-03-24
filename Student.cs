using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2
{
     public class Student
    {
        [XmlAttribute(attributeName: "indexNumber")]
        public int StudentIndex { get; set; }
        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }
        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }
        private string _email;
        public string Email {
            get { return _email; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                _email = value;
             }
        }
        public DateTime birthdate { get; set; }
        public string mothersName { get; set; }
        public string fathersName    { get; set; }
        public Studies studies { get; set; }



    }
}
