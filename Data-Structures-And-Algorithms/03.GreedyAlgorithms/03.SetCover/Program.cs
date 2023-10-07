class Program
{
    static void Main(string[] args)
    {
        int[] u = { 1, 2, 3, 4, 5, 6 };
        List<int[]> subsets = new List<int[]>()
            {
                new [] {1, 3},
                new [] {1},
                new [] {2, 4},
                new [] {2, 5},
                new [] {2, 6},
                new [] {2, 3, 6},
                new [] {4, 6},
                new [] {4, 5, 6},
                new [] {6},
            };

        List<int> uncoveredElements = new List<int> { 1, 2, 3, 4, 5, 6 };

        while (uncoveredElements.Count > 0)
        {
            int[] result = subsets.OrderByDescending(subset =>
            {
                int count = 0;

                for (int i = 0; i < subset.Length; i++)
                {
                    if (uncoveredElements.Contains(subset[i]))
                    {
                        count++;
                    }
                }

                return count;
            }).ThenBy(subset => subset.Count())
            .First();

            foreach (int item in result)
            {
                uncoveredElements.Remove(item);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}