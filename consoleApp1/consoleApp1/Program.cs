using System;
using System.Collections.Generic;
using System.IO;

namespace consoleApp1
{
    class Program
    {
        public static void FileWriter(string path)
        {
            const char DELIMITER = ',';
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string data;
                    do
                    {
                        Console.WriteLine("Please enter text: ");
                        data = Console.ReadLine();
                        writer.WriteLine(data + DELIMITER);
                        Console.WriteLine("Would you like to continue (Yes/No)? : ");
                        data = Console.ReadLine();
                    } while (data == "Yes");
                }
            }
        }

        public static void FileReader(string path)
        {
            const char DELIMITER = ',';
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line;
                        string[] lines;
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            lines = line.Split(DELIMITER);
                            foreach(var item in lines)
                            {
                                Console.WriteLine(item);
                            }
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static void Main(string[] args)
        {
            FileWriter("something.txt");
            FileReader("something.txt");
        }
    }
}
