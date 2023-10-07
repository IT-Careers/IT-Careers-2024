class Program
{
    static void Main(string[] args)
    {
        int fibonacciNumber = 10;

        if (fibonacciNumber <= 1)
        {
            Console.WriteLine(1);
        }

        int prev = 1;
        int prevPrev = 1;
        int count = 0;

        for (int i = 2; i <= fibonacciNumber; i++)
        {
            int result = prev + prevPrev;

            Console.WriteLine($"Fib({i}) = {result}");
            count++;
            prevPrev = prev;
            prev = result;
        }

        Console.WriteLine(count);
    }
}