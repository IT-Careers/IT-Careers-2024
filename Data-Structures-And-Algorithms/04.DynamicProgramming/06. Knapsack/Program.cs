using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        List<Item> items = new List<Item> {
            new Item("Flashlight", 2, 3),
            new Item("Laptop", 2, 1),
            new Item("Book", 1, 3),
            new Item("Vafla", 1, 2),
            new Item("Phone", 1, 5),
            new Item("Headphones", 1, 2),
            new Item("Laptop charger", 2, 4),
        };

        int capacity = 6;

        int[,] dpMatrix = new int[items.Count + 1, capacity + 1];

        for (int i = 1; i < dpMatrix.GetLength(0); i++)
        {
            Item currentItem = items[i - 1];

            for (int j = 0; j < dpMatrix.GetLength(1); j++)
            {
                if (j >= currentItem.Weight)
                {
                    int valueIfCurrentItemIsTaken =
                        currentItem.Value + dpMatrix[i - 1, j - currentItem.Weight];

                    int valueIfCurrentItemIsSkipped = dpMatrix[i - 1, j];

                    if (valueIfCurrentItemIsTaken > valueIfCurrentItemIsSkipped)
                    {
                        dpMatrix[i, j] = valueIfCurrentItemIsTaken;
                    }
                    else
                    {
                        dpMatrix[i, j] = valueIfCurrentItemIsSkipped;
                    }
                }
            }
        }

        int currentRow = dpMatrix.GetLength(0) - 1;
        int currentColumn = dpMatrix.GetLength(1) - 1;
        List<Item> takenItems = new List<Item>();

        while (currentRow >= 1 && currentColumn >= 0)
        {
            Item currentItem = items[currentRow - 1];

            int valueIfCurrentItemIsTaken = 0;

            if (currentColumn >= currentItem.Weight)
            {
                valueIfCurrentItemIsTaken =
                    currentItem.Value + dpMatrix[currentRow - 1, currentColumn - currentItem.Weight];
            }

            int valueIfCurrentItemIsSkipped = dpMatrix[currentRow - 1, currentColumn];

            if (valueIfCurrentItemIsTaken > valueIfCurrentItemIsSkipped)
            {
                takenItems.Add(currentItem);
                currentRow = currentRow - 1;
                currentColumn = currentColumn - currentItem.Weight;
            }
            else
            {
                currentRow = currentRow - 1;
            }
        }

        Console.WriteLine("Taken Items: " + string.Join(", ", takenItems.Select(item => item.Name)));
        Console.WriteLine("Value achieved: " + dpMatrix[dpMatrix.GetLength(0) - 1, dpMatrix.GetLength(1) - 1]);
    }

    public static void PrintMatrix(int[,] matrix)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sb.Append(matrix[i, j] + " ");
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb);
    }
}