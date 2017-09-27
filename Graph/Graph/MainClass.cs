using System;

namespace Graph
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            int[] i = {0, 1, 2, 1, 0};
            int[] j = {1, 2, 3, 3, 2};
            var graph = new Graph(i, j);
            graph.Print();
        }
    }
}