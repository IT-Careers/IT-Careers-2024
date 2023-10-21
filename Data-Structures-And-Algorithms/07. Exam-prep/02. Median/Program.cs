public class Program
{
    public static int minimumAbsoluteDifference(List<int> arr)
    {
        arr.Sort();
        int minDifference = int.MaxValue;

        for (int i = 0; i < arr.Count - 1; i++)
        {
            int difference = Math.Abs(arr[i + 1] - arr[i]);
            if (minDifference > difference) minDifference = difference;
        }

        return minDifference;
    }


    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> ints = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(minimumAbsoluteDifference(ints));
    }
}