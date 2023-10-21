public class Program
{
    public static bool IsInner(Dictionary<string, HashSet<string>> graph, string currentNode)
    {
        foreach (var node in graph)
        {
            if(node.Value.Contains(currentNode))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasDoubleConnection(
        Dictionary<string, HashSet<string>> graph, 
        string currentNode, 
        string otherNode)
    {
        return graph[currentNode].Contains(otherNode) && graph[otherNode].Contains(currentNode);
    }

    public static void Main(string[] args)
    {
        Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

        string inputLine = string.Empty;

        while((inputLine = Console.ReadLine()) != "end")
        {
            string[] inputParams = inputLine.Split();

            string parent = inputParams[0];
            string child = inputParams[1];

            if(!graph.ContainsKey(parent)) graph[parent] = new HashSet<string>();
            if(!graph.ContainsKey(child)) graph[child] = new HashSet<string>();

            graph[parent].Add(child);
        }

        List<string> innerNodes = new List<string>();

        foreach (var node in graph)
        {
            if (IsInner(graph, node.Key))
            {
                innerNodes.Add(node.Key);
            }
        }

        HashSet<string> outputStrings = new HashSet<string>();

        bool hasConnections = false;

        foreach (var innerNode in innerNodes)
        {
            foreach (var otherInnerNode in innerNodes)
            {
                if (innerNode == otherInnerNode) continue;

                if (HasDoubleConnection(graph, innerNode, otherInnerNode))
                {
                    string normalOutput = $"{innerNode} <-> {otherInnerNode}";
                    string reversedOutput = $"{otherInnerNode} <-> {innerNode}";

                    if (!outputStrings.Contains(normalOutput) && !outputStrings.Contains(reversedOutput))
                    {
                        outputStrings.Add(normalOutput);
                        outputStrings.Add(reversedOutput);
                        Console.WriteLine(normalOutput);
                        hasConnections = true;
                    }
                }
            }
        }

        if (!hasConnections) Console.WriteLine("Disconnected");
    }
}