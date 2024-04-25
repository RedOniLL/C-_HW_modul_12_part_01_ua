using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_12_part_01_ua
{
    public static class NumberProcessor
    {
        public static void GenerateAndSaveNumbers()
        {
            int[] numbers = GenerateNumbers(100);
            int[] primes = GetPrimes(numbers);
            int[] fibonaccis = GetFibonacci(numbers);

            SaveNumbersToFile("primes.txt", primes);
            SaveNumbersToFile("fibonacci.txt", fibonaccis);

            DisplayStatistics(numbers, primes, fibonaccis);
        }

        private static int[] GenerateNumbers(int count)
        {
            int[] numbers = new int[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(1, 1000);
            }

            return numbers;
        }

        private static int[] GetPrimes(int[] numbers)
        {
            int[] primes = new int[numbers.Length];
            int primeCount = 0;

            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primes[primeCount++] = number;
                }
            }

            Array.Resize(ref primes, primeCount);
            return primes;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            int i = 5;
            while (i * i <= number)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
                i += 6;
            }

            return true;
        }

        private static int[] GetFibonacci(int[] numbers)
        {
            int[] fibonaccis = new int[numbers.Length];
            int fibonacciCount = 0;

            foreach (int number in numbers)
            {
                if (IsFibonacci(number))
                {
                    fibonaccis[fibonacciCount++] = number;
                }
            }

            Array.Resize(ref fibonaccis, fibonacciCount);
            return fibonaccis;
        }

        private static bool IsFibonacci(int number)
        {
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }

        private static bool IsPerfectSquare(int x)
        {
            int sqrt = (int)Math.Sqrt(x);
            return sqrt * sqrt == x;
        }

        private static void SaveNumbersToFile(string filename, int[] numbers)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }

        private static void DisplayStatistics(int[] allNumbers, int[] primes, int[] fibonaccis)
        {
            Console.WriteLine($"Total numbers generated: {allNumbers.Length}");
            Console.WriteLine($"Total prime numbers: {primes.Length}");
            Console.WriteLine($"Total Fibonacci numbers: {fibonaccis.Length}");
        }
    }
}
