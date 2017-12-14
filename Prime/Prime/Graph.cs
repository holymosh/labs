using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Prime
{
    public class Graph
    {
        public Graph()
        {
            Edges = new List<Edge>();
            VertexCount = 0;
        }


        public Graph(List<Edge> edges, int vertexCount)
        {
            Edges = edges;
            VertexCount = vertexCount;
        }

        public void AddEdge(Edge edge)
        {
            if (!Edges.Any(current => current.FirstVertex.Equals(edge.FirstVertex)||
                current.SecondVertex.Equals(edge.FirstVertex)))
            {
                VertexCount++;
            }
            if (!Edges.Any(current => current.FirstVertex.Equals(edge.SecondVertex) ||
                                current.SecondVertex.Equals(edge.SecondVertex)))
            {
                VertexCount++;
            }
            Edges.Add(edge);
        }

        public int VertexCount { get;  set; }

        public List<Edge> Edges { get;}

        public Graph GetMinimumSpanningTree()
        {
            var result = new List<Edge>();
            //неиспользованные ребра
            List<Edge> notUsedEdges = new List<Edge>(Edges);
            //использованные вершины
            List<int> usedVertexes = new List<int>();
            //неиспользованные вершины
            List<int> notUsedVertexes = new List<int>();
            for (int i = 0; i < VertexCount; i++)
            {
                notUsedVertexes.Add(i);
            }
            //выбираем случайную начальную вершину
            Random rand = new Random();
            usedVertexes.Add(rand.Next(0, VertexCount));
            notUsedVertexes.RemoveAt(usedVertexes[0]);
            while (notUsedEdges.Count > 0)
            {
                int minE = -1; //номер наименьшего ребра
                //поиск наименьшего ребра
                if (notUsedEdges.Count.Equals(6))
                {
                    Console.WriteLine("here");
                }
                for (int i = 0; i < notUsedEdges.Count; i++)
                {
                    if (usedVertexes.Contains(notUsedEdges[i].FirstVertex) &&
                        notUsedVertexes.Contains(notUsedEdges[i].SecondVertex)||
                        usedVertexes.Contains(notUsedEdges[i].SecondVertex)
                        && notUsedVertexes.Contains(notUsedEdges[i].FirstVertex))
                    {
                        if (minE != -1)
                        {
                            if (notUsedEdges[i].Weight < notUsedEdges[minE].Weight)
                                minE = i;
                        }
                        else
                            minE = i;
                    }
                    
                }
                //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
                if (minE.Equals(-1))
                {
                    break;
                }
                if (usedVertexes.Contains(notUsedEdges[minE].FirstVertex))
                {
                    usedVertexes.Add(notUsedEdges[minE].SecondVertex);
                    notUsedVertexes.Remove(notUsedEdges[minE].SecondVertex);
                }
                else
                {
                    usedVertexes.Add(notUsedEdges[minE].FirstVertex);
                    notUsedVertexes.Remove(notUsedEdges[minE].FirstVertex);
                }
                //заносим новое ребро в дерево и удаляем его из списка неиспользованных
                result.Add(notUsedEdges[minE]);
                notUsedEdges.RemoveAt(minE);
            }
            var edges = Edges.Where(edge => edge.FirstVertex.Equals(VertexCount)
                                            || edge.SecondVertex.Equals(VertexCount));
            var min = edges.Min(edge => edge.Weight);
            result.Add(edges.Single(edge => edge.Weight.Equals(min)));
            return new Graph(result.OrderBy(edge => edge.FirstVertex).ToList(),VertexCount);
        }

        public void SaveToJson(string filename)
        {
            var serialized = JsonConvert.SerializeObject(this);
            using (var writer = new StreamWriter($@"C:\Users\MI\source\repos\Prime\Prime\{filename}"))
            {
                writer.Write(serialized);
            }
        }

        public static Graph ReadFromFile(string filename)
        {
            string notDeserialized;
            using (var reader = new StreamReader(filename))
            {
                notDeserialized = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Graph>(notDeserialized);
        }

        public void SaveToGraphizFormat(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine("graph {");
                foreach (var edge in Edges)
                {
                    writer.WriteLine($"{edge.FirstVertex} -- {edge.SecondVertex} [label={edge.Weight},weight={edge.Weight}]");
                }
                writer.Write("}");
            }
        }

        public void SaveGraphWithMST(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                var MST = GetMinimumSpanningTree();
                writer.WriteLine("graph {");
                foreach (var edge in Edges)
                {
                    if (MST.Edges.Contains(edge))
                    {
                    writer.WriteLine($"{edge.FirstVertex} -- {edge.SecondVertex} [label={edge.Weight},weight={edge.Weight},color=green]");
                    }
                    else
                    {
                        writer.WriteLine($"{edge.FirstVertex} -- {edge.SecondVertex} [label={edge.Weight},weight={edge.Weight}]");
                    }
                }
                writer.Write("}");
            }

            
            var info = new ProcessStartInfo(@"C:\graphviz-2.38\release\bin\dot.exe",
                $@"-Tpng C:\Users\MI\Documents\labs\Prime\Prime\bin\Debug\{filename} -o C:\holymosh\Result.png");
            Process.Start(info);
            Process.Start(@"C:\holymosh\Result.png");


        }
    }
}