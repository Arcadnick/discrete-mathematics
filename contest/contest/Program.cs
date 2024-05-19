using System;
using System.Collections.Generic;
using System.Linq;

namespace contest_A
{
    internal class Program
    {
        static List<int>[] graph;
        static bool[] visited;
        static List<int> component;

        static void DFS(int v)
        {
            visited[v] = true;
            component.Add(v);
            foreach (var neighbor in graph[v])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor);
                }
            }
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new List<int>();
            

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split();
                int u = int.Parse(edge[0]);
                int v = int.Parse(edge[1]);
                graph[u].Add(v);
                graph[v].Add(u);
            }

            visited = new bool[n + 1];
            var components = new List<List<int>>();

            for (int i = 1; i <= n; i++)
            {
                if (!visited[i])
                {
                    component = new List<int>();
                    DFS(i);
                    components.Add(component);
                }
            }

            Console.WriteLine(components.Count);
            foreach (var comp in components)
            {
                Console.WriteLine(comp.Count);
                Console.WriteLine(string.Join(" ", comp.OrderBy(v => v)));
            }
        }
    }
}
