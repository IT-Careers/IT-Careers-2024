class Program
{
    public static void Main(string[] args)
    {
        int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int numberToFind = 3;


        Console.WriteLine(BinarySearch(numberToFind, ints, 0, ints.Length - 1));
    }

    // 0, 9
    // 4, 9
    // 
    public static int BinarySearch(int numToFind, int[] numbers, int startIndex, int endIndex)
    {
        int median = (endIndex - startIndex) / 2;
        int currentMedianIndex = startIndex + median;

        int currentMedianNumber = numbers[currentMedianIndex];

        if (numToFind == currentMedianNumber)
        {
            return currentMedianIndex;
        }

        if (numToFind > currentMedianNumber)
        {
            return BinarySearch(numToFind, numbers, currentMedianIndex, endIndex);
        }
        else if (numToFind < currentMedianNumber)
        {
            return BinarySearch(numToFind, numbers, startIndex, currentMedianIndex - 1);
        }

        return -1;
    }
}