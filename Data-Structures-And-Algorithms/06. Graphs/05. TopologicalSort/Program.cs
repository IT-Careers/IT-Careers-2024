public class Program
{
    public static void Main(string[] args)
    {
        List<string> streets = Enumerable.Range(0, 6).Select(x => ((char)(x + 65)).ToString()).ToList();

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < streets.Count; i++)
        {
            graph.Add(i, new List<int>());
        }

        graph[0].Add(1); // A -> B
        graph[0].Add(2); // A -> C
        graph[1].Add(3); // B -> D
        graph[1].Add(4); // B -> E
        graph[4].Add(3); // E -> D 
        graph[3].Add(2); // D -> C 
        graph[3].Add(5); // D -> F 
        graph[2].Add(5); // C -> F 

        SourceRemoval(graph, streets, new HashSet<int>());
    }

    public static void SourceRemoval(Dictionary<int, List<int>> graph, List<string> streets, HashSet<int> removed)
    {
        while (graph.Count != removed.Count)
        {
            int source = FindSource(graph, removed);
            Console.WriteLine(streets[source]);
            removed.Add(source);
        }
    }

    public static int FindSource(Dictionary<int, List<int>> graph, HashSet<int> removed)
    {
        for (int i = 0; i < graph.Count; i++)
        {
            if (removed.Contains(i)) continue;

            bool isContained = false;

            for (int j = 0; j < graph.Count; j++)
            {
                if (j == i || removed.Contains(j)) continue;
                if (graph[j].Contains(i))
                {
                    isContained = true;
                    break;
                }
            }

            if(!isContained)
            {
                return i;
            }
        }

        return -1;
    }
}