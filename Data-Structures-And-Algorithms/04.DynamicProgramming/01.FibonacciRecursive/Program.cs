class Program
{
    static int count = 0;
    static Dictionary<int, int> fibonacciResults = new Dictionary<int, int>();

    static void Main(string[] args)
    {
        int fibonacci = GetFibonacciNumber(10);

        Console.WriteLine($"{fibonacci} - {count}");
    }

    static int GetFibonacciNumber(int number)
    {
        if (fibonacciResults.ContainsKey(number))
        {
            return fibonacciResults[number];
        }

        if (number <= 1)
        {
            return 1;
        }

        count++;
        int firstFibonacci = GetFibonacciNumber(number - 1);
        int secondFibonacci = GetFibonacciNumber(number - 2);

        fibonacciResults[number - 1] = firstFibonacci;
        fibonacciResults[number - 2] = secondFibonacci;

        return firstFibonacci + secondFibonacci;
    }
}