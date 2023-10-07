class Program
{
    static void Main(string[] args)
    {
        int[] inputSequance = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        int[] lengths = new int[inputSequance.Length];
        List<List<int>> finalSubSequances = new List<List<int>>();
        List<int> subsequance = new List<int>();

        int length = UpdateSubsequance(lengths, finalSubSequances, subsequance, 0, 0, inputSequance[0]);

        for (int i = 1; i < inputSequance.Length; i++)
        {
            int currentNum = inputSequance[i];
            int prevNum = inputSequance[i - 1];

            if (currentNum > prevNum)
            {
                length = UpdateSubsequance(lengths, finalSubSequances, subsequance, length, i, currentNum);
            }
            else
            {
                RemoveInvalidNumsFromSubsequance(subsequance, ref length, currentNum, ref prevNum);
                length = UpdateSubsequance(lengths, finalSubSequances, subsequance, length, i, currentNum);
            }
        }

        int maxLenght = lengths.Max();
        List<List<int>> resultSequance = new List<List<int>>();

        for (int i = 0; i < lengths.Length; i++)
        {
            int currentLength = lengths[i];

            if (currentLength == maxLenght)
            {
                resultSequance.Add(finalSubSequances[i]);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, resultSequance.Select(subseq => string.Join(" -> ", subseq))));
    }

    private static void RemoveInvalidNumsFromSubsequance(List<int> subsequance, ref int length, int currentNum, ref int prevNum)
    {
        while (currentNum <= prevNum)
        {
            subsequance.Remove(subsequance.Last());
            length--;

            if (length == 0)
            {
                break;
            }

            prevNum = subsequance.Last();
        }
    }

    private static int UpdateSubsequance(int[] lengths, List<List<int>> finalSubSequances, List<int> subsequance, int length, int i, int currentNum)
    {
        subsequance.Add(currentNum);
        length++;
        finalSubSequances.Add(new List<int>(subsequance));
        lengths[i] = length;
        return length;
    }
}