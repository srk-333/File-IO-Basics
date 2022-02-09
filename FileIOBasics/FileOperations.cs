using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics
{
    public class FileOperations
    {
        //check File Exists or Not.
        public void CheckFile(string path)
        {
            // The File Exists method is used to check if a particular file exists.
            Console.WriteLine("Check File Exists or Not");
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
                Console.WriteLine("File doesn't Exists");
        }
        //Read All Lines from File
        public void ReadAllLinesFromFile(string path)
        {
            /* ReadAllLines method is used to read all the lines
             * one by one in a file.
             * The lines are then stored in a string array variable.
             */
            Console.WriteLine();
            Console.WriteLine("Read All Lines From File");
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        //Read All Text From File.
        public void ReadAllTextFromFile(string path)
        {
            /* ReadAllText method is used to read all the lines
             * in a file at once.
             * The lines are then Stored in a string variable.
             */
            Console.WriteLine();
            Console.WriteLine("Read All Text From File");
            string lines = File.ReadAllText(path);
            Console.WriteLine(lines);
        }
        //Copy File from one Source to Another
        public void CopyFileSourceToDest(string path)
        {
            Console.WriteLine();
            Console.WriteLine("Copy File from one Source to Another Source");
            string path1 = @"E:\RfaBatch\File-IO-Basics\FileIOBasics\Files\sample1.txt";
            try
            {
                //Copy method is used to make a copy of an existing file.
                File.Copy(path, path1);
                Console.WriteLine("File Copied!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DeleteFile(path1);
        }
        //Delete a File
        public void DeleteFile(string path)
        {
            Console.WriteLine();
            Console.WriteLine("Delete a File");
            if (File.Exists(path))
            {
                //Delete method is used to delete an existing file.
                File.Delete(path);
                Console.WriteLine("File Deleted!");
            }
            else
                Console.WriteLine("File Doesn't Exists");
        }
        //File Reader Stream 
        public void FileReadUsingStream(string path)
        {
            /* The Stream Reader is used to read data from a file using Streams
             * The data from the file is first read into the stream.
             * Thereafter the application reads the data from the stream.
             */
            Console.WriteLine();
            Console.WriteLine("Reading File Using Stream Reader");
            using (StreamReader sr = File.OpenText(path))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }            
        }
        //File Writer Stream
        public void FileWriteUsingStream(string path)
        {
           /* The Stream Writer is used to write data on a file using Streams
            * The data from the application first written into the stream.
            * Thereafter the stream writes the data to the file.
            */
            Console.WriteLine();
            Console.WriteLine("Writing on a File Using Stream Writer");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("\nHello world - .net is boring");
                sw.Close();
            }
        }
    }
}
