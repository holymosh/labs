using System.Collections.Generic;

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
            HeadsList = new List<int>(Heads.Count);
            References = new List<int>(Heads.Count);
        }

        public void Add(int head, int tail)
        {
            Heads.Add(head);
            Tails.Add(tail);
        }

        public void Print()
        {
        }

        private void CreateArcList()
        {
            for (int index = 0; index < HeadsList.Count; index++)
            {
                HeadsList[index] = -1;
            }
            for (int k = 0; k < References.Count; k++)
            {
                var i = Heads[k];
                References[k] = HeadsList[i];
                HeadsList[i] = k;
            }
        }
    }
}