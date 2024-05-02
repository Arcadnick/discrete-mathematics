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
            Console.WriteLine("Задача:\nЧему равна сумма всех чисел, являющихся перестановкой цифр числа N?");
            Console.WriteLine("Введите N");
            var N = int.Parse(Console.ReadLine());

            Dictionary<int, int> digitsCount = CountDigits(N);
            var sum = 0;
            var totalCount = digitsCount.Values.Sum(v=>v);
            var totalPermutations = Factorial(totalCount);

            foreach (var pair in digitsCount)
            {
                totalPermutations /=Factorial(pair.Value);
            }
            var digitSum = digitsCount.Sum(x => x.Key * x.Value);
            foreach (var pair in digitsCount)
            {
                int digitContrib = pair.Key * (totalPermutations/totalCount) *digitSum;
                sum += digitContrib;
            }
            Console.WriteLine(sum);
        }
    }
}
