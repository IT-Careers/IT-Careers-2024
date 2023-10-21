public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(); ;
        List<string> result = new List<string>();

        Permute(0, input, new string[input.Length], new bool[input.Length], new HashSet<string>(), result);

        Console.WriteLine(string.Join(Environment.NewLine, result.OrderBy(x =>x)));
    }

    private static void Permute(int index, string[] element, string[] subset, bool[] isUsed, HashSet<string> palindromes, List<string> result)
    {
        if (index == element.Length)
        {
            string normalStr = string.Join(" ", subset);
            string reversedStr = string.Join(" ", subset.Reverse());

            if (!palindromes.Contains(normalStr))
            {
                palindromes.Add(reversedStr);
                result.Add(normalStr);
            }

            return;
        }

        for (int i = 0; i < element.Length; i++)
        {
            if (!isUsed[i])
            {
                isUsed[i] = true;
                subset[index] = element[i];
                Permute(index + 1, element, subset, isUsed, palindromes, result);
                isUsed[i] = false;
            }
        }
    }
}