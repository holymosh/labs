using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        public IList<int> Heads { get; set; } // I
        public IList<int> Tails { get; set; } // J
        public IList<int> HeadsList { get; set; } //головы списков , массив H ,размерность n
        public IList<int> References { get; set; } // ссылки элементов друг на друга, массив L , размерность m
        public IList<int> Colors { get; set; }
        public IList<KeyValuePair<int,int>> HeadsTails { get; set; } // IJ

        public Graph(int[] heads, int[] tails)
        {
            Heads = new List<int>(heads);
            Tails = new List<int>(tails);
            HeadsTails = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < Heads.Count; i++)
            {
                HeadsTails.Add(new KeyValuePair<int, int>(Heads[i],Tails[i]));
            }
            CreateArcList();
        }

        public void Add(int head, int tail)
        {
            Heads.Add(head);
            Tails.Add(tail);
            HeadsTails.Add(new KeyValuePair<int, int>(head,tail));
            CreateArcList();
        }

        public void Print()
        {
            foreach (var head in HeadsList)
            {
                Console.Write(head + " ");
            }
            Console.WriteLine();
            foreach (var reference in References)
            {
                Console.Write(reference + " ");
            }
            if (!Directory.Exists(@"C:\graph"))
            {
                Directory.CreateDirectory(@"C:\graph");
            }
            var writer = new StreamWriter(@"C:\graph\graph.gv");
            writer.WriteLine("graph photograph{");
            for (int i = 0; i < Heads.Count; i = i + 2)
            {
                writer.WriteLine(Heads[i] + "--" + Tails[i] + ";");
            }
            writer.Write("}");
            writer.Close();
        }

        private void CreateArcList()
        {
            var count = Heads.Concat(Tails).Max() + 1;
            HeadsList = Enumerable.Repeat(-1, count).ToList();
            Colors = Enumerable.Repeat(-1,count).ToList();
            References = new List<int>(Heads.Count);
            for (int k = 0; k < Heads.Count; k++)
            {
                var i = Heads[k];
                References.Add(HeadsList[i]);
                HeadsList[i] = k;
            }
        }

        public void DepthFirstSearch(int vertex, int currentComponent)
        {
            Colors[vertex] = currentComponent;
            for (int index = HeadsList[vertex] = 0; !index.Equals(-1); index = References[index])
            {
                if (Colors[HeadsTails[index].Value].Equals(-1))
                {
                    DepthFirstSearch(HeadsTails[index].Value , currentComponent);
                }
            }
        }
    }
}