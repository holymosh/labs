﻿using System;
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
            graph.SaveGraphWithMST("kok.gv");
        }

        //алгоритм Прима

    }

}
