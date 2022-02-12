using CsvHelper;
using FileIOBasics.Binary;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics.CSV
{
    public class CsvFileHelper
    {
        //Perform Write Operation on Csv File.
        public static void CsvSerialization(string csvFilePath)
        {
            //Initialze list of Objects
            List<Person> records = new List<Person>()
            {
                new Person() { Name = "Saurav", Age = 25, Country = "India" ,Email = "sdgjhsagdah@mail.com",Mobile = 485678456 },
                new Person() { Name = "Rohit", Age = 26, Country = "India" ,Email = "fdhgjkfdhg@mail.com",Mobile = 455776564 }
            };
            try
            {
                //Writer Stream to Write on csv File.
                using (var writer = new StreamWriter(csvFilePath))
                using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWrite.WriteRecords(records);
                }
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        //Method to Read From Csv File.
        public static List<Person> CsvDeserialization(string csvFilePath)
        {
            StreamReader reader = null;
            try
            {              
                reader = new StreamReader(csvFilePath);
                var csvRead = new CsvReader(reader, CultureInfo.InvariantCulture);
                var result = csvRead.GetRecords <Person>().ToList();
                if (result.Count != 0)
                {
                    foreach (Person person in result)
                    {
                        Console.WriteLine(person);
                    }
                }
                return result;
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                reader.Close();
            }
            
        }
        //Method to Read From Csv File And Write On Json File
        public static void ReadFromCsvAndWriteIntoJson(string csvFilePath)
        {
            string jsonFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\CSV\JsonData.json";
            var csvData = CsvDeserialization(csvFilePath);
            string res = JsonConvert.SerializeObject(csvData);
            File.WriteAllText(jsonFilePath, res);
        }
        //Method to Read From Csv File And Write On Json File
        public static void ReadFromJsonAndWriteIntoCsv()
        {
            string jsonFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\CSV\JsonData.json";
            string csvFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\CSV\CsvData.csv";
            var result = File.ReadAllText(jsonFilePath);
            List<Person> res = JsonConvert.DeserializeObject<List<Person>>(result);
            //Writer Stream to Write on csv File.
            using (var writer = new StreamWriter(csvFilePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(res);
            }
        }

    }
    //Person Class
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Country {get; set; }
        public long Mobile { get; set; }
        //Override ToString Method
        public override string ToString()
        {
            return ($"Name={Name}\tAge={Age}\tEmail={Email}\tCountry={Country}\tMobile={Mobile}");
        }
    }
}
