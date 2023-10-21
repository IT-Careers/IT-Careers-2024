public class Program
{
    public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < edges.Count; i++)
        {
            List<int> currentEdge = edges[i];

            int firstNode = currentEdge[0];
            int secondNode = currentEdge[1];

            if (!graph.ContainsKey(firstNode)) graph[firstNode] = new List<int>();
            if (!graph.ContainsKey(secondNode)) graph[secondNode] = new List<int>();

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
        }


        if (!graph.ContainsKey(s))
        {
            List<int> resultEdgeCase = new List<int>();

            for (int i = 0; i < n - 1; i++)
            {
                resultEdgeCase.Add(-1);    
            }

            return resultEdgeCase;
        }

        Queue<int> q = new Queue<int>();
        q.Enqueue(s);
        bool[] used = new bool[n];
        int[] distances = new int[n];


        while (q.Count > 0)
        {
            int currentNode = q.Dequeue();
           
            if (!used[currentNode - 1])
            {
                used[currentNode - 1] = true;

                foreach (var child in graph[currentNode])
                {
                    if (!used[child - 1])
                    {
                        q.Enqueue(child);
                        if (distances[child - 1] != 0)
                        {
                            distances[child - 1] = Math.Min(distances[currentNode - 1] + 1, distances[child - 1]);
                        }
                        else
                        {
                            distances[child - 1] = distances[currentNode - 1] + 1;
                        }
                    }
                }
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < distances.Length; i++)
        {
            if (i == s - 1)
            {
                continue;
            }

            if (distances[i] == 0)
            {
                result.Add(-1);
            }
            else
            {
                result.Add(distances[i] * 6);
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        int queries = int.Parse(Console.ReadLine());

        for (int i = 0; i < queries; i++)
        {
            List<List<int>> edges = new List<List<int>>();

            int[] nodesAndEdges = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int countOfNodes = nodesAndEdges[0];
            int countOfEdges = nodesAndEdges[1];

            for (int j = 0; j < countOfEdges; j++)
            {
                edges.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
            }

            int startNode = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", bfs(countOfNodes, countOfEdges, edges, startNode)));
        }
    }
}

/*
 
1
4 6
1 2
1 3
1 4
2 3
2 4
3 4
1
 
 */