using System;


namespace C__HW_modul_12_part_01_ua
{
    public static class FileProcessor
    {
        public static void ReplaceWord(string filePath, string searchWord, string replaceWord)
        {
            int replacementsCount = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                content = content.Replace(searchWord, replaceWord);
                replacementsCount = CountReplacements(content, searchWord);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(content);
                }
            }

            DisplayStatistics(searchWord, replaceWord, replacementsCount);
        }

        private static int CountReplacements(string content, string searchWord)
        {
            int count = 0;
            int index = content.IndexOf(searchWord);

            while (index != -1)
            {
                count++;
                index = content.IndexOf(searchWord, index + 1);
            }

            return count;
        }

        private static void DisplayStatistics(string searchWord, string replaceWord, int replacementsCount)
        {
           Console.WriteLine($"Replaced '{searchWord}' with '{replaceWord}' {replacementsCount} times.");
        }
    }
}
