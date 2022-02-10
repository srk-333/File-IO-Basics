using FileIOBasics.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileIOBasics.Xml
{
    public class XmlOperation
    {
        //Xml Serialization
        public static void XmlSerialization(string path)
        {
            //Initialze list of Objects
            List<Employee> list = new List<Employee>()
            {
            new Employee() { Name = "Vikash", Id = 102, Age = 25, Address = "Bihar" },
            new Employee() { Name = "Ritesh", Id = 25, Age = 44, Address = "jharkhand" }
            };
            //Create Xml Stream
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter writer = new StreamWriter(path);
            //Serialize Object
            serializer.Serialize(writer, list);
            writer.Close();
        }
        //Xml DeSerialization
        public static void XmlDeSerialization(string path)
        {
            //Create Xml Stream
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Employee>));
            TextReader reader = new StreamReader(path);
            //DeSerialize Object
            List<Employee> list = (List<Employee>)deserializer.Deserialize(reader);
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp);
            }
        }
    }
}