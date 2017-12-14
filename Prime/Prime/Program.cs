using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = Graph.ReadFromFile("graph.txt");
            graph.SaveToGraphizFormat("source.gv");
            Console.WriteLine(graph.VertexCount);
            var spanningTree = graph.GetMinimumSpanningTree();
            spanningTree.SaveToGraphizFormat("result.gv");
            foreach (var edge in spanningTree.Edges)
            {
                Console.WriteLine($"{edge.FirstVertex} , {edge.SecondVertex} , {edge.Weight}");
            }
        }

        //алгоритм Прима

    }

}
