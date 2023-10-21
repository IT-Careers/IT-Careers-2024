using _06._Kruskal;
using System.Net.Http.Headers;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> graph = InitializeGraph();
        Dictionary<string, string> forest = new Dictionary<string, string>();

        foreach (var vertex in graph.Keys)
        {
            forest.Add(vertex, null);
        }

        List<Edge<string>> edges = new List<Edge<string>>();
        
        foreach (var vertex in graph)
        {
            foreach (var edge in vertex.Value)
            {
                edges.Add(new Edge<string>(vertex.Key, edge.Key, edge.Value)); // TODO: Optimize this...
            }
        }

        while(edges.Count > 0)
        {
            Edge<string> currentEdge = FindMin(edges); // TODO: Optimize this...
            RemoveEdge(edges, currentEdge); // TODO: Optimize this...

            string parentRoot = FindRoot(forest, currentEdge.Parent);
            string childRoot = FindRoot(forest, currentEdge.Child);

            if(childRoot != parentRoot)
            {
                forest[childRoot] = currentEdge.Parent;
            }
        }
    }

    private static void RemoveEdge(List<Edge<string>> edges, Edge<string> currentEdge)
    {
        HashSet<Edge<string>> removedEdges = new HashSet<Edge<string>>();

        for (int i = 0; i < edges.Count; i++)
        {
            Edge<string> edge = edges[i];

            if((edge.Parent == currentEdge.Parent && edge.Child == currentEdge.Child)
                || (edge.Parent == currentEdge.Child && edge.Child == currentEdge.Parent))
            {
                removedEdges.Add(edge);
            }
        }

        edges.RemoveAll(edge => removedEdges.Contains(edge));
    }

    private static Edge<string> FindMin(List<Edge<string>> sortedEdges)
    {
        int minWeight = int.MaxValue;
        Edge<string> minEdge = null;

        foreach (var edge in sortedEdges)
        {
            if(edge.Weight < minWeight)
            {
                minWeight = edge.Weight;
                minEdge = edge;
            }
        }

        return minEdge;
    }

    private static string FindRoot(Dictionary<string, string> forest, string currentNode)
    {
        while (forest[currentNode] != null)
        {
            currentNode = forest[currentNode];
        }

        return currentNode;
    }

    private static Dictionary<string, Dictionary<string, int>> InitializeGraph()
    {
        Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < 9; i++)
        {
            graph.Add(((char)(i + 65)).ToString(), new Dictionary<string, int>());
        }

        graph["A"].Add("B", 4); // A -> B
        graph["B"].Add("A", 4); // B -> A

        graph["A"].Add("C", 5); // A -> C
        graph["C"].Add("A", 5); // C -> A

        graph["A"].Add("D", 9); // A -> D
        graph["D"].Add("A", 9); // D -> A

        graph["B"].Add("D", 2); // B -> D
        graph["D"].Add("B", 2); // D -> B

        graph["C"].Add("D", 20); // C -> D
        graph["D"].Add("C", 20); // D -> C

        graph["C"].Add("E", 7); // C -> E
        graph["E"].Add("C", 7); // E -> C

        graph["D"].Add("E", 8); // D -> E
        graph["E"].Add("D", 8); // E -> D

        graph["E"].Add("F", 12); // E -> F
        graph["F"].Add("E", 12); // F -> E

        graph["G"].Add("H", 8); // G -> H
        graph["H"].Add("G", 8); // H -> G

        graph["H"].Add("I", 7); // H -> I
        graph["I"].Add("H", 7); // I -> H

        graph["G"].Add("I", 10); // G -> I
        graph["I"].Add("G", 10); // I -> G

        return graph;
    }
}



//forest.Add(new Edge<string>("A", "B", 5));
//forest.Add(new Edge<string>("B", "C", 2));
//forest.Add(new Edge<string>("C", "D", 1));

//foreach (Edge<string> edge in forest)
//{
//    Console.WriteLine($"{edge.Parent} -> {edge.Child} ({edge.Weight})");
//}