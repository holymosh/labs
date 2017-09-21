namespace Graph
{
    public class Graph
    {
        public int[] Heads { get; set; }
        public int[] Tails { get; set; }

        public Graph(int[] heads, int[] tails)
        {
            Heads = heads;
            Tails = tails;
        }
    }
}