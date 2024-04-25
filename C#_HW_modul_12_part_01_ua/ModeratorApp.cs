using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_12_part_01_ua
{
    public static class ModeratorApp
    {
        public static void ToModerate()
        {
            SaveArrayToFile();
        }
        public static string[] ReadWordsFromFile(string filePath)
        {
            List<string> wordsList = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        wordsList.Add(word);
                    }
                }
            }

            return wordsList.ToArray();
        }

        private static string[] CompareAndReplaceWords()
        {
            string[] firstArray = ReadWordsFromFile("Mod.txt");
            string[] secondArray = ReadWordsFromFile("Text.txt");

            for (int i = 0; i < secondArray.Length; i++)
            {
                string word = secondArray[i];
                if (Array.Exists(firstArray, w => w.Equals(word, StringComparison.OrdinalIgnoreCase)))
                {
                    secondArray[i] = new string('*', word.Length);
                }
            }
            return secondArray;
        }

        private static void SaveArrayToFile()
        {
            string[] array = CompareAndReplaceWords();
            using (StreamWriter writer = new StreamWriter("Text.txt"))
            {
                foreach (string word in array)
                {
                    writer.WriteLine(word);
                }
            }
        }

    }
}

