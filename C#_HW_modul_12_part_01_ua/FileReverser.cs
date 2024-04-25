using System;
using System.Reflection.Metadata;


namespace C__HW_modul_12_part_01_ua
{
    public static class FileReverser
    {
        public static void ToReverse()
        {
            SaveTextToFIle();
        }
        private static void SaveTextToFIle()
        {
            using (StreamWriter writer = new StreamWriter("ReversetText.txt"))
            {
                writer.Write(Reverser());
            }
        }
       private static string Reverser()
        {
            string fileContent = ReadFileToString();
            fileContent = new string(fileContent.ToCharArray().Reverse().ToArray());
            return fileContent;
        }
       private static string ReadFileToString()
           {
                Console.WriteLine("Enter filepath");
                string filePath = Console.ReadLine();   
                string fileContent;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                }

                return fileContent;
            }
        }

}
