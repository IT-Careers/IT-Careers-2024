class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();
        tree.Insert(17);
        tree.Insert(9);
        tree.Insert(6);
        tree.Insert(7);
        tree.Insert(19);
        tree.Insert(18);
        tree.Insert(25);

        tree.DeleteMin();
        tree.DeleteMin();

        Console.WriteLine();
        //Console.WriteLine(tree.Contains(5));
        //tree.EachInOrder(x => Console.WriteLine(x));

        //Console.WriteLine(tree.Search(1) == null ? "NULL" : $"Not NULL" );


        //BinaryTree<int> binaryTree = new BinaryTree<int>(tree.Root);

        //binaryTree.EachInOrder((x) => Console.WriteLine(x));
    }
}