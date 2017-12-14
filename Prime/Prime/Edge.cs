namespace Prime
{
    public class Edge
    {
        public Edge(int firstVertex, int secondVertex, int weight)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
            Weight = weight;

        }

        public int FirstVertex { get; set; }

        public int SecondVertex { get; set; }

        public int Weight { get; set; }
    }
}