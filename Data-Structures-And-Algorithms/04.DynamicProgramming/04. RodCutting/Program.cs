public class Program
{
    static int CutRod(int[] prices, int[] bestPrices, int n)
    {
        if (n <= 0) return 0;
        if (bestPrices[n] != 0) return bestPrices[n];

        for (int i = 1; i <= n; i++)
        {
            int cutPrice = Math.Max(prices[i], bestPrices[i]);
            int priceForLeftOverRope = CutRod(prices, bestPrices, n - i);
            bestPrices[n] = Math.Max(cutPrice + priceForLeftOverRope, bestPrices[n]);
        }

        return bestPrices[n];
    }

    static void Main(string[] args)
    {
        int[] prices = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
        int[] bestPrices = new int[prices.Length];
        int n = 9;

        //Console.WriteLine(CutRod(prices, bestPrices, n));
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                int jCutPrice = prices[j] + bestPrices[i - j];
                bestPrices[i] = Math.Max(bestPrices[i], jCutPrice);
            }
        }

        Console.WriteLine(bestPrices[n]);
    }
}