using _03.BTree;

public class Program
{
    public static void Main(string[] args)
    {
        TwoThreeTree<int> twoThreeTree = new TwoThreeTree<int>();


        twoThreeTree.Insert(5);
        twoThreeTree.Insert(10);
        twoThreeTree.Insert(15);
        twoThreeTree.Insert(20);
        twoThreeTree.Insert(25);
        twoThreeTree.Insert(30);
        twoThreeTree.Insert(35);
    }
}