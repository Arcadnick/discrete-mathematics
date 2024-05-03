using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_2
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
        /// Нахождение факториала
        /// </summary>
        static int Factorial(int n)
        {
            if (n == 1) return 1;
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            long sum = 0;
            Console.WriteLine("Задача:\nЧему равна сумма всех чисел, являющихся перестановкой цифр числа X?");
            Console.WriteLine("Введите X");
            string input = Console.ReadLine();
            int n = input.Length;

            Dictionary<int, int> digitsCount = CountDigits(int.Parse(input));

            var numerator = Factorial(n - 1);

            foreach (KeyValuePair<int, int> pair in digitsCount)
            {
                int label = pair.Key;
                var denominator = 1;

                foreach (KeyValuePair<int, int> entry in digitsCount)
                {
                    if (label == entry.Key)
                    {
                        denominator *= Factorial(entry.Value - 1);
                    }
                    else
                    {
                        denominator *= Factorial(entry.Value);
                    }
                }
                sum += label * (numerator / denominator);
            }

            //собираем величие(число из n едениц)
            long greatness = 0;
            for (int i = 0; i < n; i++)
            {
                greatness = (greatness * 10) + 1;
            }

            Console.WriteLine($"Сумма всех перестановок = {sum * greatness} ");
        }
    }
}
