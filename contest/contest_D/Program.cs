using System;

namespace contest_D
{
    internal class Program
    {
       static int Dijkstra(int[,] graph, int N, int start, int finish)
        {
            int[] distances = new int[N];
            bool[] visited = new bool[N];

            for (int i = 0; i < N; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }

            distances[start] = 0;

            for (int i = 0; i < N; i++)
            {
                int u = -1;
                // Поиск непосещенной вершины с минимальным расстоянием
                for (int j = 0; j < N; j++)
                {
                    if (!visited[j] && (u == -1 || distances[j] < distances[u]))
                    {
                        u = j;
                    }
                }

                // Если минимальное расстояние "бесконечно", значит, все оставшиеся вершины недостижимы
                if (distances[u] == int.MaxValue)
                {
                    break;
                }

                visited[u] = true;

                // Обновляем расстояния до соседних вершин
                for (int v = 0; v < N; v++)
                {
                    // Существует ребро и вершина не посещена => обновляем расстояние
                    if (graph[u, v] != -1 && !visited[v])
                    {
                        int newDist = distances[u] + graph[u, v];
                        if (newDist < distances[v])
                        {
                            distances[v] = newDist;
                        }
                    }
                }
            }

            return distances[finish] == int.MaxValue ? -1 : distances[finish];
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int S = int.Parse(input[1]) - 1;
            int F = int.Parse(input[2]) - 1;

            int[,] graph = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] graphline = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                    graph[i, j] = int.Parse(graphline[j]);
            }

            Console.WriteLine(Dijkstra(graph, N, S, F));
        }
    }
}
