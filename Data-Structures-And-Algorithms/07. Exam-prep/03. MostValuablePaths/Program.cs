public class Program
{
    public static void Main(string[] args)
    {
        Tree tree = new Tree();
        string input = null;

        while ((input = Console.ReadLine()) != "calculate")
        {
            int[] inputNums = input.Split()
                .Select(int.Parse)
                .ToArray();

            int parentNum = inputNums[0];
            int childNum = inputNums[1];

            tree.Add(parentNum, childNum);
        }

        List<List<int>> result = tree.CalculateTopThree()
            .OrderByDescending(path => path.Sum())
            .Take(3)
            .ToList();

        foreach (List<int> path in result)
        {
            int sum = path.Sum();

            string resultLine = $"{sum} -> {string.Join(", ", path)}";

            Console.WriteLine(resultLine);
        }

    }
}