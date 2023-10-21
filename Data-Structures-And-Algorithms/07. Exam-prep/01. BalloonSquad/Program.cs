using System.Diagnostics;
using System.Numerics;

public class Program
{
    static int countOfSolutions = 0;

    public static void Main(string[] args)
    {
        string[] matrixParams = Console.ReadLine().Split();
        int rows = int.Parse(matrixParams[0]);
        int columns = int.Parse(matrixParams[1]);
        int baloons = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, columns];

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        PlaceBaloon(0, baloons, matrix, 0);
        stopwatch.Stop();
        Console.WriteLine(countOfSolutions);
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms");
    }

    public static void PlaceBaloon(int currentIndex, int baloons, int[,] matrix, int placedBaloons)
    {
        if(currentIndex >= baloons)
        {
            if (placedBaloons == baloons) countOfSolutions++;

            return;
        }

        for(int column = 0; column < matrix.GetLength(1); column++)
        {
            if(!IsAttacked(matrix, currentIndex, column))
            {
                Mark(matrix, currentIndex, column);
                PlaceBaloon(currentIndex + 1, baloons, matrix, placedBaloons + 1);
                Unmark(matrix, currentIndex, column);
            }
        }
    }

    private static void Mark(int[,] matrix, int currentRow, int currentColumn)
    {
        for(int row = 0; row < matrix.GetLength(0); row++)
        {
            matrix[row, currentColumn]++;
        }

        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            matrix[currentRow, column]++;
        }
    }

    private static void Unmark(int[,] matrix, int currentRow, int currentColumn)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            matrix[row, currentColumn]--;
        }

        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            matrix[currentRow, column]--;
        }
    }

    private static bool IsAttacked(int[,] matrix, int currentIndex, int column)
    {
        return matrix[currentIndex, column] != 0;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string result = "";

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] > 0)
                {
                    result += "* ";
                }
                else
                {
                    result += "- ";
                }
            }

            Console.WriteLine(result.Trim());
        }

        Console.WriteLine();
    }
}
