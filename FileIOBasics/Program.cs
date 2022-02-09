using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to File Io Operations");
            string path = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Files\sample.txt";        
            FileOperations(path);
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
        }
    }
}
