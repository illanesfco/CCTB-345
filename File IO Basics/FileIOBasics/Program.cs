using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = {5, 12, 7, 9, 1, 3, 0, 187, 42, 8};
            var sorted = from item in values
                         orderby item
                         select items;
            //sorted = values.OrderBy(x => -x); //Method syntax of LINQ
            foreach (int thing in sorted)
                Console.Write(":" + thing);
            Console.WriteLine();
            Console.WriteLine();

            ReadFile("");
        }

        static string WinDir = System.Environment.GetEnvironmentVariable("windir");
        static void ReadFile(string filePath)
        {
            List<string> textInMemory = new List<string>();
            string path = filePath;
            if (string.IsNullOrEmpty(path))
                path = WinDir + "\\system.ini";

            StreamReader reader = new StreamReader(path);
            try
            {
                do
                {
                    textInMemory.Add(reader.ReadLine());
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                textInMemory.Add("File is empty");
            }
            finally
            {
                reader.Close();
            }
            Display(textInMemory);
        }

        private static void Display(List<string> linesOfText)
        {
            foreach (string line in linesOfText)
            {
                Console.WriteLine(line);
                Console.WriteLine();
            }
        }
    }
}
