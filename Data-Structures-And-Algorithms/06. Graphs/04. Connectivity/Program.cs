public class Program
{
    public static void Main(string[] args)
    {
        List<string> streets = Enumerable.Range(0, 7).Select(x => ((char)(x + 65)).ToString()).ToList();

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < streets.Count; i++)
        {
            graph.Add(i, new List<int>());
        }

        graph[0].Add(1); // A -> B
        graph[0].Add(2); // A -> C
        graph[1].Add(3); // B -> D
        graph[2].Add(4); // C -> E
        graph[4].Add(1); // E -> B
        graph[3].Add(2); // D -> C
        //graph[5].Add(1); // F -> B
        //graph[6].Add(0); // G -> A
        graph[6].Add(5);


        bool[] isVisited = new bool[streets.Count];

        for (int i = 0; i < streets.Count; i++)
        {
            Dfs(i, graph, streets, isVisited);
        } 
    }

    public static void Dfs(int currentNode, Dictionary<int, List<int>> graph, List<string> streets, bool[] isVisited)
    {
        if (!isVisited[currentNode])
        {
            isVisited[currentNode] = true;
            Console.WriteLine(streets[currentNode]);

            foreach (int childNode in graph[currentNode])
            {
                if (!isVisited[childNode]) Dfs(childNode, graph, streets, isVisited);
            }
        }
    }
}