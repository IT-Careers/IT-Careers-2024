class Program
{
    static int[] subSequance = new int[5];
    static int subSequanceLength = 0;
    static int[] resultSubSequance = new int[5];
    static int maxSequanceLength = 0;
    static int count = 0;

    int[] sequnasLegths = new int[5];
    // 1 2 3 4 5
    // 1 2 3 5
    // 1 2 4 5
    // 1 2 5 
    static int[] inputSequance = { 3, 5, 8, 6, 7 };
    //static int[] inputSequance = { 1, 2, 3, 4, 5 };
    //static int[] inputSequance = {  3, 1, 2, 4, 5 };
    //12345

    //12345
    //1235
    //1245
    //125

    //2345

    //3
    //3,5
    //3,5,8
    //3,5,6
    //3,5,6,7
    //3,5,7
    //3,8
    //3,6
    //3,6,7
    //3,7

    //5,8
    //5,6
    //5,6,7
    //5,7

    //8

    //6
    //6,7

    //7

    // index 0 -> 3 5 8 6 7
    // index 1 -> 5 8 6 7
    // index 2 -> 8 6 7
    // index 3 -> 6 7
    // index 4 -> 7

    static void Main(string[] args)
    {
        // 3 5 6 7

        GenerateSubSequance(0);

        Console.WriteLine(string.Join(" ", resultSubSequance));
        Console.WriteLine(count);
    }

    private static void GenerateSubSequance(int index)
    {
        if (index == inputSequance.Length)
        {
            return;
        }

        for (int i = index; i < inputSequance.Length; i++)
        {
            if (index == 0 && inputSequance.Length - i + 1 <= maxSequanceLength)
            {
                return;
            }

            count++;
            if (index == 0)
            {
                subSequance[index] = inputSequance[i];
                subSequanceLength++;
                GenerateSubSequance(index + 1);
            }
            else
            {
                int currentElement = inputSequance[i];
                int previousElement = subSequance[index - 1];

                if (previousElement < currentElement)
                {
                    subSequance[index] = inputSequance[i];
                    subSequanceLength++;
                    GenerateSubSequance(index + 1);
                }
            }
        }

        if (maxSequanceLength < subSequanceLength)
        {
            maxSequanceLength = subSequanceLength;
            Array.Copy(subSequance, resultSubSequance, maxSequanceLength);
        }

        subSequanceLength--;
        subSequance[index] = 0;
    }
}