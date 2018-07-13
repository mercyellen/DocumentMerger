using System;
using System.IO;
using System.Collections.Generic;

namespace DocumentMerger
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Document\n");
            Console.Write("Enter the name of the first document: ");
            string name = GetUserInput();
            Console.Write("Enter the name of the second document: ");
            string name2 = GetUserInput();
            try
            {
                StreamWriter streamWriter = new StreamWriter(name + ".txt");
                Console.WriteLine("{0} was successfully saved. The document contains characters.", name);
                Console.WriteLine("{0} was successfully saved. The document contains characters.", name2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            String combined = CombinePaths(name, name2);

            List<string[]> data = new List<string[]>();
            data.Add(File.ReadAllLines("name"));
            data.Add(File.ReadAllLines("name2.txt"));
            List<string> finalData = new List<string>();

            for (int i = 0; i < data.Count; i++)
            {
                for (int n = 0; n < data[i].Length; n++)
                {
                    string[] temp = data[i][n].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    finalData.Add(temp[1] + "|" + temp[2]);
                }
            }

            finalData.Sort();

            try
            {
                StreamWriter streamWriter = new StreamWriter(combined + ".txt");
                Console.WriteLine("{0} was successfully saved. The document contains characters.", combined);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            /*

            CombinePaths(firstTextFile, secondFile);

            List<string[]> data = new List<string[]>();
            data.Add(File.ReadAllLines("firstTextFile.txt"));
            data.Add(File.ReadAllLines("secondFile.txt"));
            List<string> finalData = new List<string>();

            try
            {
                StreamWriter streamWriter = new StreamWriter(firstTextFile + ".txt");
                streamWriter.WriteLine(data);
                streamWriter.Close();
                Console.WriteLine("{0} was successfully saved.", firstTextFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int n = 0; n < data[i].Length; n++)
                {
                    string[] temp = data[i][n].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    finalData.Add(temp[1] + "|" + temp[2]);
                }
            } */
        }

        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
            {
                if ((character >= 0x00 && character <= 0x1F) || character == 0x7F)
                {
                    return false;
                }
            }
            return true;
        }

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("The input contains invalid characters. Enter again: ");
            } while (true);
        }

        private static String CombinePaths(string p1, string p2)
        {

            try
            {
                string combination = Path.Combine(p1, p2);

                Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}{3}.txt",
                            p1, p2, Environment.NewLine, combination);
                return combination;
            }
            catch (Exception e)
            {
                if (p1 == null)
                    p1 = "null";
                if (p2 == null)
                    p2 = "null";
                Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}",
                            p1, p2, Environment.NewLine, e.Message);
            }
            Console.WriteLine();
            return null;
        }
    }
}
