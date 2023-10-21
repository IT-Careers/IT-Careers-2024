namespace _06._Kruskal
{
    public class Edge<T>
    {
        public T Parent { get; set; }

        public T Child { get; set; }

        public int Weight { get; set; }

        public Edge(T parent, T child, int weight) 
        { 
            this.Parent = parent;
            this.Child = child;
            this.Weight = weight;
        }
    }
}
