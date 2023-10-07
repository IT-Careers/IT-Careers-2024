class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                for (int k = 1; k < 10; k++)
                {
                    for (int l = 1; l < 10; l++)
                    {
                        for (int m = 1; m < 10; m++)
                        {
                            for (int o = 1; o < 10; o++)
                            {
                                Console.WriteLine($"{i}{j}{k}{l}{m}{o}");
                            }
                        }
                    }
                }
            }
        }
    }
}