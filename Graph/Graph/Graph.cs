using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        public IList<int> Heads { get; set; } // I
        public IList<int> Tails { get; set; } // J
        public IList<int> HeadsList { get; set; } //головы списков , массив H ,размерность n
        public IList<int> References { get; set; } // ссылки элементов друг на друга, массив L , размерность m

        public Graph(int[] heads, int[] tails)
        {
            Heads = new List<int>(heads);
            Tails = new List<int>(tails);
            //HeadsList = new List<int>(Heads.Concat(Tails).Max()+1);
            var count = Heads.Concat(Tails).Max() + 1;
            HeadsList = Enumerable.Repeat(-1, count).ToList();
            References = new List<int>(Heads.Count);
            CreateArcList();
        }

        public void Add(int head, int tail)
        {
            Heads.Add(head);
            Tails.Add(tail);
        }

        public void Print()
        {
            foreach (var head in HeadsList)
            {
                Console.Write(head);
            }
            Console.WriteLine();
            foreach (var reference in References)
            {
                Console.Write(reference);
            }
        }

        private void CreateArcList()
        {
            for (int k = 0; k < Heads.Count; k++)
            {
                var i = Heads[k];
                References.Add(HeadsList[i]);
                HeadsList[i] = k;
            }
        }
    }
}