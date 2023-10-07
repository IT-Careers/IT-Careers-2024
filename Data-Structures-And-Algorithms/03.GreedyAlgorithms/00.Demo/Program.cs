class Program
{
    static void Main(string[] args)
    {
        int count = 0;

        for (int i = 1; i < 50; i++)
        {
            for (int j = 1; j < 50; j++)
            {
                if (j == i)
                {
                    continue;
                }

                for (int k = 1; k < 50; k++)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }

                    for (int l = 1; l < 50; l++)
                    {
                        if (l == i || l == j || l == k)
                        {
                            continue;
                        }

                        for (int m = 1; m < 50; m++)
                        {
                            if (m == i || m == j || m == k || m == l)
                            {
                                continue;
                            }

                            for (int o = 1; o < 50; o++)
                            {
                                if (o == i || o == j || o == k || o == l || o == m)
                                {
                                    continue;
                                }

                                count++;
                            }
                        }
                    }
                }
            }
            // 1 2 3 4 5 6
            // 6 5 4 3 2 1
            Console.WriteLine(i);
        }

        Console.WriteLine(count);
    }
}