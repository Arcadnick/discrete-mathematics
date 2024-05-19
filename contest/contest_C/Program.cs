using System;

namespace contest_C
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] distances = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    distances[i, j] = int.Parse(input[j]);
            }

            int minDistance = int.MaxValue;
            int[] niceCycle = new int[3];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        int currentDistance = distances[i, j] + distances[j, k] + distances[k, i];
                        if (currentDistance < minDistance)
                        {
                            minDistance = currentDistance;
                            niceCycle[0] = i + 1;
                            niceCycle[1] = j + 1;
                            niceCycle[2] = k + 1;
                        }
                    }
                }
            }

            Console.WriteLine($"{niceCycle[0]} {niceCycle[1]} {niceCycle[2]}");
        }
    }
}

