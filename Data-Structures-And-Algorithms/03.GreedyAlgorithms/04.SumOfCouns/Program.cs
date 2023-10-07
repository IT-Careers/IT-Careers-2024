class Program
{
    static void Main(string[] args)
    {
        int finalSum = 18;
        int actual = 0;
        int[] coins = { 10, 10, 5, 5, 2, 2, 1, 1 };
        Queue<int> result = new Queue<int>();
        int count = 0;

        for (int i = 0; i < coins.Length; i++)
        {
            int currentCoint = coins[i];

            if (actual + currentCoint <= finalSum)
            {
                actual += currentCoint;
                result.Enqueue(currentCoint);
            }

            count++;
            if (actual == finalSum)
            {
                break;
            }
        }

        Console.WriteLine(string.Join(" ", result));
        Console.WriteLine(count);
    }
}