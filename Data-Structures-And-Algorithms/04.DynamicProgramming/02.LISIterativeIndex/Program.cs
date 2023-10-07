class Program
{
    static void Main(string[] args)
    {
        int[] inputSequance = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        //int[] inputSequance = { 3, 4, 8, 6, 7 };
        //int[] inputSequance = { 1, 2, 4, 5 };
        int[] lengths = new int[inputSequance.Length];
        int[] prev = new int[inputSequance.Length];

        for (int i = 0; i < inputSequance.Length; i++)
        {
            lengths[i] = 1;
            prev[i] = -1;

            for (int j = 0; j < i; j++)
            {
                int currentNum = inputSequance[i];
                int prevNum = inputSequance[j];

                if (currentNum > prevNum)
                {
                    // Example with number 7 from the upper sequance
                    // number from sequance - 7
                    // index 5 -> length 2
                    // index 5 -> length 3
                    lengths[i] = lengths[j] + 1;
                    prev[i] = j;
                    Console.WriteLine($"{inputSequance[j]} -> {inputSequance[i]}");
                }
            }
        }

        int maxLenght = lengths.Max();
        List<int> maxSeqIndexes = new List<int>();

        for (int i = 0; i < lengths.Length; i++)
        {
            int currentLength = lengths[i];

            if (currentLength == maxLenght)
            {
                maxSeqIndexes.Add(i);
            }
        }

        for (int i = 0; i < maxSeqIndexes.Count; i++)
        {
            List<int> maxSequance = new List<int>();
            int currentIndex = maxSeqIndexes[i];

            while (true)
            {
                int currentNum = inputSequance[currentIndex];
                maxSequance.Add(currentNum);

                if (prev[currentIndex] == -1)
                {
                    break;
                }

                currentIndex = prev[currentIndex];
            }

            maxSequance.Reverse();

            PrintList(maxSequance);
        }
    }

    static void PrintList(List<int> list)
    {
        Console.WriteLine(string.Join(" ", list));
    }
}