using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DM_1
{
    class Program
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

        /// <summary>
        /// Формула сочетаний
        /// </summary>
        static int Combination(int k, int n)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
            //return Factorial(n+k-1) / (Factorial(k) * Factorial(n - 1));
        }

        static void Main()
        {
            int count = 0;
            Console.WriteLine("Задача:\nСколькл 4-х значных чисел можно составить из цифр числа N?");
            Console.WriteLine("Введите N");
            var N = int.Parse(Console.ReadLine());

            Dictionary<int, int> digitsCount = CountDigits(N);
            //1+1+1+1
            if (digitsCount.Count >= 4)
            {
                count += Factorial(digitsCount.Count);
            }
                
            //4
            foreach (KeyValuePair<int, int> entry in digitsCount)
            {
                //если эта цифра повторяется 4 или больше раз, то добавляем вариант
                if (entry.Value >= 4) count++;
            }

            //3+1
            foreach (KeyValuePair<int, int> entry in digitsCount)
            {
                //если эта цифра повторяется 3 или больше раз, то
                if (entry.Value >= 3 && digitsCount.Count > 1)
                {
                    //4 места, способы поставить: кол-во -1
                    count += 4 * (digitsCount.Count - 1);
                    break;
                }
            }

            //2+2
            foreach (KeyValuePair<int, int> entry in digitsCount)
            {
                //если эта цифра повторяется 2 или больше раз, то
                if (entry.Value >= 2 && digitsCount.Count > 1)
                {
                    //ищем количесво цифр, которые повторяются больше 2-х раз
                    int k = digitsCount.Count(pair => pair.Value >= 2);
                   
                    //проверим больше чем 1 такая цифра
                    if (k > 1)
                    {
                        //используем формулу сочетаний
                        count += Combination(k, digitsCount.Count);
                        break;
                    }
                }
            }

            //2+1+1+1
            foreach (KeyValuePair<int, int> entry in digitsCount)
            {
                //если эта цифра повторяется 2 или больше раз, то
                if (entry.Value >= 2 && digitsCount.Count > 1)
                {
                    //ищем количесво цифр, которые повторяются больше 2-х раз
                    int k = digitsCount.Count(pair => pair.Value >= 2);
                    //проверим больше чем 1 такая цифра
                    if (k > 1)
                    {
                        count += k * Combination(k, digitsCount.Count) * Factorial(digitsCount.Count - 1);
                        break;
                    }
                }
            }

            Console.WriteLine($"Количество 4-х значных чисел = {count}");
        }
    }
}