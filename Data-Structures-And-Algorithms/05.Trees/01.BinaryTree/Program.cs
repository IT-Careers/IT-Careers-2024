class Program
{
    public static void Main(string[] args)
    {
        BinaryTreeNode<int> root = new BinaryTreeNode<int>() { Value = 17 }; ;


        BinaryTreeNode<int> firstChild = new BinaryTreeNode<int>();
        firstChild.Value = 9;
        firstChild.Left = new BinaryTreeNode<int>() { Value = 3 };
        firstChild.Right = new BinaryTreeNode<int>() { Value = 11 };


        BinaryTreeNode<int> secondChild = new BinaryTreeNode<int>();
        secondChild.Value = 25;
        secondChild.Left = new BinaryTreeNode<int>() { Value = 20 };
        secondChild.Right = new BinaryTreeNode<int>() { Value = 31 };

        root.Left = firstChild;
        root.Right = secondChild;

        root.PrintIndentedPreOrder(0, (value, indent) => Console.WriteLine($"{new string(' ', indent)}{value}"));
        root.PrintIndentedInOrder((value) => Console.WriteLine($"{value}"));
        Console.WriteLine();
        root.PrintIndentedPostOrder((value) => Console.WriteLine($"{value}"));
    }
}

class BinaryTreeNode<T>
{
    public T Value { get; set; }

    public BinaryTreeNode<T> Left { get; set; }

    public BinaryTreeNode<T> Right { get; set; }

    public void PreOrder()
    {
        if (this == null)
        {
            return;
        }

        Console.WriteLine(this.Value);
        this.Left?.PreOrder();
        this.Right?.PreOrder();
    }

    public void InOrder()
    {
        if (this == null)
        {
            return;
        }

        this.Left?.InOrder();
        Console.WriteLine();
        this.Right?.InOrder();
    }

    public void PostOrder()
    {
        if (this == null)
        {
            return;
        }

        this.Left?.PostOrder();
        this.Right.PostOrder();
        Console.WriteLine(this.Value);
    }

    public void PrintIndentedPreOrder(int indent, Action<T, int> action)
    {
        if (this == null)
        {
            return;
        }

        action.Invoke(this.Value, indent);
        this.Left?.PrintIndentedPreOrder(indent + 2, action);
        this.Right?.PrintIndentedPreOrder(indent + 2, action);
    }

    public void PrintIndentedInOrder(Action<T> action)
    {
        if (this == null)
        {
            return;
        }

        this.Left?.PrintIndentedInOrder(action);
        action.Invoke(this.Value);
        this.Right?.PrintIndentedInOrder(action);
    }

    public void PrintIndentedPostOrder(Action<T> action)
    {
        if (this == null)
        {
            return;
        }

        this.Left?.PrintIndentedPostOrder(action);
        this.Right?.PrintIndentedPostOrder(action);
        action.Invoke(this.Value);
    }
}