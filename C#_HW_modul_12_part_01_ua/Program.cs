using System;

namespace C__HW_modul_12_part_01_ua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter choise: ");
            int c = int.Parse(Console.ReadLine());
            switch (c) { 
                case 0:
                    NumberProcessor.GenerateAndSaveNumbers();
                    break;
                case 1:
                    Console.Write("Enter the file path: ");
                    string filePath = Console.ReadLine();

                    Console.Write("Enter the word to search: ");
                    string searchWord = Console.ReadLine();

                    Console.Write("Enter the word to replace: ");
                    string replaceWord = Console.ReadLine();

                    FileProcessor.ReplaceWord(filePath, searchWord, replaceWord);
                    break;
                case 2:
                    ModeratorApp.ToModerate();
                    break;
                case 3:
                    FileReverser.ToReverse();
                    break;
                case 4:
                    NumberStatistics.AnalyzeNumbers();
                    break ;
            }
        }
    }
}
