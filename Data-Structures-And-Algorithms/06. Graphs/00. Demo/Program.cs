public class Program
{
    public static void Main(string[] args)
    {
        List<string> streets = Enumerable.Range(0, 5).Select(x => ((char) (x + 65)).ToString()).ToList();

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

        Dfs(0, graph, streets, new bool[streets.Count]);
    }

    public static void Dfs(int currentNode, Dictionary<int, List<int>> graph, List<string> streets, bool[] isVisited)
    {
        if(!isVisited[currentNode])
        {
            isVisited[currentNode] = true;
            Console.WriteLine(streets[currentNode]);

            foreach(int childNode in graph[currentNode]) 
            {
                Dfs(childNode, graph, streets, isVisited);
            }
        }
    }
}