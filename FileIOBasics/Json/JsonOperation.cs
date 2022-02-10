using FileIOBasics.Binary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics.Json
{
    public class JsonOperation
    {
        //Json Serialization
        public static void JsonSerialization(string path)
        {
            //Initialze list of Objects
            List<Employee> list = new List<Employee>()
            {
            new Employee() { Name = "Vikash", Id = 102, Age = 25, Address = "Bihar" },
            new Employee() { Name = "Ritesh", Id = 25, Age = 44, Address = "jharkhand" }
            };
            //Conerting List of Object into Json string.
            string result = JsonConvert.SerializeObject(list);
            //Append in Json File.
            File.AppendAllText(path, result);
        }
        //Json DeSerialization
        public static void JsonDeSerialization(string path)
        {
            //Read Data From json File
            String result = File.ReadAllText(path);
            //Convert Json String into List of Object.
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(result);
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp);
            }
        }
    }
}