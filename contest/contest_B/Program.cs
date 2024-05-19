using System;

namespace contest_B
{
    class Program
    {
        static bool IsTree(int[,] matrix, int n)
        {
            bool[] visited = new bool[n];
            int edgeCount = 0;

            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (matrix[i, j] == 1)
                        edgeCount++;

            if (edgeCount != n - 1)
                return false;

            DFS(matrix, 0, visited, n);

            for (int i = 0; i < n; i++)
                if (!visited[i])
                    return false;

            return true;
        }

        static void DFS(int[,] matrix, int vertex, bool[] visited, int n)
        {
            visited[vertex] = true;

            for (int i = 0; i < n; i++)
                if (matrix[vertex, i] == 1 && !visited[i])
                    DFS(matrix, i, visited, n);
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = int.Parse(input[j]);
            }

            Console.WriteLine(IsTree(matrix, n) ? "YES" : "NO");
        }
    }
}