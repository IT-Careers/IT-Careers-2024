using _00.Demo;
using System.Collections.ObjectModel;

class Program
{
    //17
    //  9
    //    6
    //    5
    public static void Main(string[] args)
    {
        //Tree<int> root = new Tree<int>(17,
        //    new Tree<int>(9,
        //        new Tree<int>(6),
        //        new Tree<int>(5)),
        //    new Tree<int>(14),
        //    new Tree<int>(15,
        //        new Tree<int>(8)));

        Tree<int> root = new Tree<int>(7,
            new Tree<int>(19,
                new Tree<int>(1),
                new Tree<int>(12),
                new Tree<int>(31)),
            new Tree<int>(21),
            new Tree<int>(14,
                new Tree<int>(23),
                new Tree<int>(6)));

        //IEnumerable<int> iter = root.OrderDFS();

        //Console.WriteLine(string.Join(" ", iter));

        Console.WriteLine(string.Join(" ", root.OrderBFS()));
    }
}

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (Tree<T> child in children)
        {
            Children.Add(child);
        }
    }

    public T Value { get; set; }

    public List<Tree<T>> Children { get; set; }

    public void Print(int interval)
    {
        Console.WriteLine($"{new string(' ', interval)}{this.Value}");

        foreach (Tree<T> child in this.Children)
        {
            child.Print(interval + 2);
        }
    }

    public void PrintWithDFS()
    {
        foreach (Tree<T> child in this.Children)
        {
            child.PrintWithDFS();
        }

        Console.WriteLine(this.Value);
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> collection = new List<T>();

        foreach (Tree<T> child in this.Children)
        {
            collection.AddRange(child.OrderDFS());
        }

        collection.Add(this.Value);

        return collection;
    }

    public void PrintWithBFS()
    {
        Queue<Tree<T>> queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> currentNode = queue.Dequeue();

            Console.WriteLine(currentNode.Value);

            foreach (Tree<T> child in currentNode.Children)
            {
                queue.Enqueue(child);
            }
        }
    }

    public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        List<T> list = new List<T>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> currentNode = queue.Dequeue();

            list.Add(currentNode.Value);

            foreach (Tree<T> child in currentNode.Children)
            {
                queue.Enqueue(child);
            }
        }

        return list;
    }

    public void PrintPreOrder()
    {
        if (this != null)
        {
            Console.WriteLine(this.Value);

            PrintPreOrder();
        }
    }
}