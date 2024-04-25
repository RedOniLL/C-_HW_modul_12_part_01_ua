using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_12_part_01_ua
{
    public static class NumberStatistics
    {
        public static void AnalyzeNumbers()
        {
            Console.WriteLine("EnterFilePath");
            string filePath = Console.ReadLine(); 

            int positiveCount = 0;
            int negativeCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        if (number > 0)
                        {
                            positiveCount++;
                        }
                        else if (number < 0)
                        {
                            negativeCount++;
                        }

                        if (number >= 10 && number <= 99)
                        {
                            twoDigitCount++;
                        }
                        else if (number >= 10000 && number <= 99999)
                        {
                            fiveDigitCount++;
                        }
                    }
                }
            }

            Console.WriteLine("Positive Numbers: " + positiveCount);
            Console.WriteLine("Negative Numbers: " + negativeCount);
            Console.WriteLine("Two-Digit Numbers: " + twoDigitCount);
            Console.WriteLine("Five-Digit Numbers: " + fiveDigitCount);
        }
    }
}
