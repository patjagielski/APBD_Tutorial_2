using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Tutorial2
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            var path = @"Data\dane.csv";

            var universities = new List<University>();
            var studies = new List<Studies>();
            var listOfStudents = new HashSet<Student>(new CustomComparer());

            //Read from the file
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead())) 
            {
                string line = null;


                var compsci = 0;
                var newmedia = 0;
                while ((line = stream.ReadLine()) != null)
                {
                    
                    string[] columns = line.Split(',');
                    var fname = columns[0];
                    var lname = columns[1];
                    var subject = columns[2];
                    var studytime = columns[3];
                    var studentnum = int.Parse(columns[4]);
                    var date1 = DateTime.Parse(columns[5]);
                    var email = columns[6];
                    var mothername = columns[7];
                    var fathername = columns[8];
                    Console.WriteLine(line);
                    var studysub = new Studies
                    {
                        name = subject,
                        mode = studytime
                    };
                    foreach(string x in columns)
                    {
                        if (x.Contains("Informatyka"))  {
                            compsci++;
                        }
                        else
                        {
                            newmedia++;
                        }

                    }
                    var studyCount = new StudyCount
                    {
                        compSci = compsci,
                        newMedia = newmedia

                    };


                    var st = new Student
                    {
                        FirstName = fname,
                        LastName = lname,
                        Email = email,
                        birthdate = date1,
                        StudentIndex = studentnum,
                        mothersName = mothername,
                        fathersName = fathername,
                        studies = studysub

                    };
                    listOfStudents.Add(st);
                    if (!listOfStudents.Add(st))
                    {
                        using var sw = new StreamWriter(@"log.txt");
                        sw.WriteLine($"element with index numver: {st.StudentIndex}  already exists");
                    }
                    var uni = new University
                    {
                        createdAt = "08.03.2020",
                        author = "Patrik Jagielski",
                        students = listOfStudents,
                        activeStudies = studyCount
                    };
                    universities.Add(uni);
                    


                }

            }
            var str = string.Empty;
           
            
            if (string.IsNullOrEmpty(str)) { }
            if (string.IsNullOrWhiteSpace(str)) { }
            







       

          
            

            //Console.WriteLine($"The number of students in the list is {listOfStudents.Count}");


            var writer = new FileStream(@"result.xml", FileMode.Create);  
            var serializer = new XmlSerializer(typeof(List<University>), new XmlRootAttribute("university"));        
            serializer.Serialize(writer, universities);

            var jsonString = JsonSerializer.Serialize(universities);
            File.WriteAllText("data.json", jsonString);
             
        
        }


    }
}
