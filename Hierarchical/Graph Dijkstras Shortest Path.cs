using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Dijkstras_Shortest_Path
{

    public class Dijkstra
    {
        public static int V = 9;

        public int MinDistance(int[] dist, bool[] sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false &&
                      dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }
        public void FindShortestPath(int[,] graph, int source)
        {
            int[] dist = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[source] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V-1; count++)
            {
                int u = MinDistance(dist, sptSet);

                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex.              
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in  
                    // sptSet, there is an edge from u  
                    // to v, and total weight of path  
                    // from src to v through u is smaller  
                    // than current value of dist[v] 
                    if (!sptSet[v] && graph[u, v] != 0 &&
                               dist[u] != int.MaxValue &&
                         dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            PrintPath(dist);
        }        

        public void PrintPath(int[] dist)
        {
            Console.Write("Vertex     Distance from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " +
                            dist[i] + "\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]{{0, 4, 0, 0, 0, 0, 0, 8, 0},
                          {4, 0, 8, 0, 0, 0, 0, 11, 0},
                          {0, 8, 0, 7, 0, 4, 0, 0, 2},
                          {0, 0, 7, 0, 9, 14, 0, 0, 0},
                          {0, 0, 0, 9, 0, 10, 0, 0, 0},
                          {0, 0, 4, 14, 10, 0, 2, 0, 0},
                          {0, 0, 0, 0, 0, 2, 0, 1, 6},
                          {8, 11, 0, 0, 0, 0, 1, 0, 7},
                          {0, 0, 2, 0, 0, 0, 6, 7, 0}};

            Dijkstra dijkstra = new Dijkstra();
            dijkstra.FindShortestPath(graph, 0);
            Console.ReadKey();
        }
    }
}
