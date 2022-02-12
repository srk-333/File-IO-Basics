using System;
using FileIOBasics.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIOBasics.Json;
using FileIOBasics.Xml;
using FileIOBasics.CSV;

namespace FileIOBasics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to File Io Operations");
            //string path = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Files\sample.txt";
            //string binaryFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Binary\binary.txt";
            //string jsonFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Json\JsonData.Json";
            //string xmlFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Xml\xmlData.xml";
            //FileOperations(path);
            //BinaryOps(binaryFilePath);
            //JsonOps(jsonFilePath);
            //XmlOps(xmlFilePath);
            Program.CsvFileOps();
            Console.ReadKey();
        }
        //Method to call all methods of FileOperation class.
        public static void FileOperations(string path)
        {
            FileOperations file = new FileOperations();
            file.CheckFile(path);
            file.ReadAllLinesFromFile(path);
            file.ReadAllTextFromFile(path);
            file.CopyFileSourceToDest(path);
            file.FileReadUsingStream(path);
            file.FileWriteUsingStream(path);
            file.RenameFileName();
        }
        //Method to call BinaryOperation class methods
        public static void BinaryOps(string path)
        {
            BinaryOperation.BinarySerialization(path);
            BinaryOperation.BinaryDeSerialization(path);
            JsonOperation.JsonSerialization(path);
        }
        //Method to call JsonOperation class methods
        public static void JsonOps(string path)
        {
            JsonOperation.JsonSerialization(path);
            JsonOperation.JsonDeSerialization(path);
        }
        //Method to call XmlOperation class methods
        public static void XmlOps(string path)
        {
            XmlOperation.XmlSerialization(path);
            XmlOperation.XmlDeSerialization(path);         
        }
        //Method to call JsonOperation class methods
        public static void CsvFileOps()
        {
            string csvFilePath = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\CSV\CsvData.csv";
            CsvFileHelper.CsvSerialization(csvFilePath);
            CsvFileHelper.CsvDeserialization(csvFilePath);
            CsvFileHelper.ReadFromCsvAndWriteIntoJson(csvFilePath);
            CsvFileHelper.ReadFromJsonAndWriteIntoCsv();
        }
    }
}