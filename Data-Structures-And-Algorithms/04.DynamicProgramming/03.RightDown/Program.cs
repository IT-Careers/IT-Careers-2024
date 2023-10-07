class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[,]
        {
                { 2, 6, 1, 8, 9, 4, 2 },
                { 1, 8, 0, 3, 5, 6, 7 },
                { 3, 4, 8, 7, 2, 1, 8 },
                { 0, 9, 2, 8, 1, 7, 9 },
                { 2, 7, 1, 9, 7, 8, 2 },
                { 4, 5, 6, 1, 2, 5, 6 },
                { 9, 3, 5, 2, 8, 1, 9 },
                { 2, 3, 4, 1, 7, 2, 8 }
        };

        int[,] sumMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

        Trevarse(0, 0, matrix, sumMatrix);

        for (int i = 0; i < sumMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < sumMatrix.GetLength(1); j++)
            {
                Console.Write(sumMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        int row = sumMatrix.GetLength(0) - 1;
        int col = sumMatrix.GetLength(1) - 1;

        Console.WriteLine($"Max Sum: {sumMatrix[row, col]}");

        List<string> path = new List<string>();
        path.Add($"(Current location -> row: {row}, col: {col})");

        while (row >= 0 && col >= 0)
        {
            int upSum = 0;
            int leftSum = 0;

            if (row > 0)
            {
                upSum = sumMatrix[row - 1, col];
            }

            if (col > 0)
            {
                leftSum = sumMatrix[row, col - 1];
            }

            if (upSum > leftSum)
            {
                row--;
                path.Add($"(Current location -> row: {row}, col: {col} Direction -> Down)");
            }
            else
            {
                col--;
                path.Add($"(Current location -> row: {row}, col: {col} Direction -> Right)");
            }
        }

        path.Reverse();
        Console.WriteLine(string.Join(Environment.NewLine, path));

    }

    static void Trevarse(int row, int col, int[,] matrix, int[,] sumMatrix)
    {
        int currentValue = matrix[row, col];
        int upSum = 0;
        int leftSum = 0;

        if (row > 0)
        {
            upSum = sumMatrix[row - 1, col];
        }

        if (col > 0)
        {
            leftSum = sumMatrix[row, col - 1];
        }

        int maxSum = Math.Max(upSum, leftSum);

        sumMatrix[row, col] = currentValue + maxSum;

        if (col < matrix.GetLength(1) - 1)
        {
            Trevarse(row, col + 1, matrix, sumMatrix);
        }

        if (row < matrix.GetLength(0) - 1)
        {
            Trevarse(row + 1, col, matrix, sumMatrix);
        }
    }
}