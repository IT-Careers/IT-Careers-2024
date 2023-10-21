using System.Reflection.Metadata;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, Dictionary<int, int>> graph = InitializeGraph();
        
        int start = 0;
        int end = 9;

        int[] distances = new int[12];
        int[] previous = new int[12];

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = int.MaxValue;
            previous[i] = -1;
        }

        bool[] visited = new bool[12];

        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        priorityQueue.Enqueue(start, 0);
        distances[start] = 0;

        while(priorityQueue.Count > 0)
        { 
            int currentNode = priorityQueue.Dequeue();

            if (!visited[currentNode])
            {
                visited[currentNode] = true;

                foreach (var childNode in graph[currentNode]) 
                {
                    int distanceFromStart = distances[childNode.Key];
                    int distanceToParentFromStart = distances[currentNode];
                    int realDistance = -1;

                    if(distanceFromStart > distanceToParentFromStart + childNode.Value)
                    {
                        distances[childNode.Key] = distanceToParentFromStart + childNode.Value;
                        previous[childNode.Key] = currentNode;
                        realDistance = distanceToParentFromStart + childNode.Value;
                    }
                    else
                    {
                        realDistance = distanceFromStart;
                    }

                    priorityQueue.Enqueue(childNode.Key, realDistance);
                }
            }
        }

        // TODO: Check if there is even a path between start and end
        LinkedList<int> path = new LinkedList<int>();
        int pathNode = end;

        while (pathNode != -1)
        {
            path.AddFirst(pathNode);
            pathNode = previous[pathNode];
        }

        Console.WriteLine("Path: " + string.Join(" -> ", path));
    }

    private static Dictionary<int, Dictionary<int, int>> InitializeGraph()
    {
        Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

        for (int i = 0; i < 12; i++)
        {
            graph.Add(i, new Dictionary<int, int>());
        }

        AddEdge(graph, 0, 6, 10);
        AddEdge(graph, 0, 8, 12);
        AddEdge(graph, 6, 4, 17);
        AddEdge(graph, 6, 5, 6);
        AddEdge(graph, 8, 5, 3);
        AddEdge(graph, 8, 2, 14);
        AddEdge(graph, 4, 5, 5);
        AddEdge(graph, 4, 11, 11);
        AddEdge(graph, 4, 1, 20);
        AddEdge(graph, 5, 11, 33);
        AddEdge(graph, 2, 11, 9);
        AddEdge(graph, 2, 7, 15);
        AddEdge(graph, 11, 1, 6);
        AddEdge(graph, 11, 7, 20);
        AddEdge(graph, 7, 1, 26);
        AddEdge(graph, 7, 9, 3);
        AddEdge(graph, 1, 9, 5);
        AddEdge(graph, 3, 10, 7);

        return graph;
    }

    private static void AddEdge(
        Dictionary<int, Dictionary<int, int>> graph,
        int parent,
        int child,
        int weight)
    {
        graph[parent].Add(child,weight);
        graph[child].Add(parent,weight);
    }
}