using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_3
{
    internal class Program
    {
        /// <summary>
        /// Подсчет количества повторов в числе
        /// </summary>
        static Dictionary<int, int> CountDigits(int number)
        {
            Dictionary<int, int> digitsCount = new Dictionary<int, int>();

            while (number > 0)
            {
                int digit = number % 10;
                if (digitsCount.ContainsKey(digit))
                {
                    digitsCount[digit]++;
                }
                else
                {
                    digitsCount.Add(digit, 1);
                }
                number /= 10;
            }
            return digitsCount;
        }

        /// <summary>
        /// Генератор всех чисел с помощью богоподобной рекурсии
        /// </summary>
        public static void GenerateNumbers(Dictionary<int, int> digitCounts, string currentNumber, int length, List<int> results)
        {
            if (currentNumber.Length == length)
            {
                results.Add(int.Parse(currentNumber));
                return;
            }

            foreach (var pair in new Dictionary<int, int>(digitCounts))
            {
                if (pair.Value > 0)
                {
                    digitCounts[pair.Key]--;
                    GenerateNumbers(digitCounts, currentNumber + pair.Key, length, results);
                    digitCounts[pair.Key]++;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задача:\nЧему равна сумма 4-х значных чисел из цифр числа X?");
            Console.WriteLine("Введите X");
            var X = int.Parse(Console.ReadLine());

            Dictionary<int, int> digitsCount = CountDigits(X);

            var results = new List<int>();
            GenerateNumbers(digitsCount, "", 4, results);

            var sum = results.Sum();
            Console.WriteLine($"Cумма 4-х значных чисел = {sum}");
        }
    }
}
