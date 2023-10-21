public class Program
{
    static int countOfRecursions = 0;

    public static int SubsetSum(int index, int[] nums, int sum, int[,] dpMatrix)
    {
        if (sum == 0)
        {
            return 1;
        }

        if (index == 0) return 0;

        if (dpMatrix[index - 1, sum] != -1)
        {
            return dpMatrix[index - 1, sum];
        }

        if (nums[index - 1] > sum)
        {
            return SubsetSum(index - 1, nums, sum, dpMatrix);
        }

        int firstResult = SubsetSum(index - 1, nums, sum, dpMatrix);

        if (firstResult != 0)
        {
            dpMatrix[index - 1, sum] = firstResult;
            return firstResult;
        }

        int secondResult = SubsetSum(index - 1, nums, sum - nums[index - 1], dpMatrix);

        if (secondResult != 0)
        {
            dpMatrix[index - 1, sum - nums[index - 1]] = firstResult;
            return secondResult;
        }

        return 0;
    }

    public static void Main(string[] args)
    {
        int[] nums = { 3, 34, 4, 12, 5, 2 };
        int sum = 36;

        int[,] dpMatrix = new int[nums.Length, sum + 1];

        for (int i = 0; i < dpMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < dpMatrix.GetLength(1); j++)
            {
                dpMatrix[i, j] = -1;
            }
        }

        Console.WriteLine(SubsetSum(nums.Length, nums, sum, dpMatrix));
        Console.WriteLine(countOfRecursions);
    }

    public static void PresentationSolution()
    {
        int[] nums = { 3, 5, 1, 4, 2 };
        int sum = 6;

        HashSet<int> possibleSums = new HashSet<int>();
        Dictionary<int, int> sumNumberPair = new Dictionary<int, int>();

        possibleSums.Add(0);

        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];

            HashSet<int> currentSums = new HashSet<int>();

            foreach (var previousSum in possibleSums)
            {
                int currentSum = previousSum + nums[i];
                currentSums.Add(currentSum);

                if (!sumNumberPair.ContainsKey(currentSum))
                {
                    sumNumberPair.Add(currentSum, i);
                }
            }

            foreach (var currentSum in currentSums)
            {
                possibleSums.Add(currentSum);
            }
        }

        int currentIndex = sumNumberPair[sum];
        int currentSumm = sum;
        List<int> subSet = new List<int>();

        while (currentSumm > 0)
        {
            currentSumm -= nums[currentIndex];
            subSet.Add(nums[currentIndex]);
            if (currentSumm > 0) currentIndex = sumNumberPair[currentSumm];
        }

        Console.WriteLine(string.Join(", ", subSet));
    }
}