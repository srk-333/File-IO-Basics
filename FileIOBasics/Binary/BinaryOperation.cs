using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics.Binary
{
    public class BinaryOperation
    {
        //BinarySerialization
        public static void BinarySerialization(string path)
        {
            //Initialze list of Objects
            List<Employee> list = new List<Employee>()
            {
            new Employee() { Name = "Saurav", Id = 102, Age = 25, Address = "Bihar" },
            new Employee() { Name = "Rohit", Id = 25, Age = 44, Address = "jharkhand" }
            };
            //Create the File Stream
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            //Serialize Object
            binary.Serialize(stream, list);
            stream.Close();
        }
        //BinaryDeSerialization
        public static void BinaryDeSerialization(string path)
        {
            try
            {
                //Create the File Stream
                BinaryFormatter binary = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                //DeSerialize Object
                List<Employee> list = (List<Employee>)binary.Deserialize(stream);
                if (list != null)
                {
                    foreach (Employee emp in list)
                    {
                        Console.WriteLine(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }       
    }
    //Employee Class
    [Serializable]
    public class Employee
    {
        //Proerties
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        //Override Tostring method
        public override string ToString()
        {
            return ($"Name={Name},Id={Id},Age={Age},Address={Address}");
        }
    }
}