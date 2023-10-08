using System.Diagnostics.CodeAnalysis;

public class BinaryTree<T> where T : IComparable<T>
{
    public BinaryTree()
    {
    }

    public BinaryTree(BinaryTreeNode<T> node)
    {
        this.Copy(node);
    }

    public BinaryTreeNode<T> Root { get; set; }

    public BinaryTreeNode<T> Insert(T value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(value);
            return Root;
        }

        return InsertRec(Root, value);
    }

    public bool Contains(T value)
    {
        return Search(value) != null;
    }

    public BinaryTreeNode<T> Delete(T value)
    {
        return DeleteRec(Root, value);
    }

    public void DeleteMin()
    {
        BinaryTreeNode<T> parent = Root;
        BinaryTreeNode<T> child = Root.Left;

        while (child.Left != null)
        {
            parent = child;
            child = child.Left;
        }

        if (child.Right != null)
        {
            parent.Left = child.Right;
        }
        else
        {
            parent.Left = null;
        }
    }

    private BinaryTreeNode<T> DeleteRec(BinaryTreeNode<T> node, T value)
    {
        if (node == null)
        {
            return null;
        }

        int compareResult = value.CompareTo(node.Value);

        if (compareResult < 0)
        {
            node.Left = DeleteRec(node.Left, value);
        }
        else if (compareResult > 0)
        {
            node.Right = DeleteRec(node.Right, value);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            if (node.Right == null)
            {
                return node.Left;
            }

            BinaryTreeNode<T> succParent = node;
            BinaryTreeNode<T> succ = node.Right;

            while (succ.Left != null)
            {
                succParent = succ;
                succ = succ.Left;
            }

            if (succParent != node)
            {
                succParent.Left = succ.Right;
            }
            else
            {
                succParent.Right = succ.Right;
            }

            node.Value = succ.Value;
        }

        return node;
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrderRecursive(Root, action);
    }

    public BinaryTreeNode<T> Search(T value)
    {
        return SearchRec(Root, value);
    }

    private BinaryTreeNode<T> SearchRec(BinaryTreeNode<T> node, T value)
    {
        if (node == null)
        {
            return null;
        }

        int compareResult = value.CompareTo(node.Value);

        if (compareResult == 0)
        {
            return node;
        }
        else if (compareResult < 0)
        {
            return SearchRec(node.Left, value);
        }
        else
        {
            return SearchRec(node.Right, value);
        }
    }

    private BinaryTreeNode<T> InsertRec(BinaryTreeNode<T> node, T value)
    {
        if (node == null)
        {
            node = new BinaryTreeNode<T>(value);
            return node;
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = InsertRec(node.Left, value);
            return node;
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = InsertRec(node.Right, value);
            return node;
        }

        return node;
    }

    private void Copy(BinaryTreeNode<T> root)
    {
        if (root == null)
        {
            return;
        }

        this.Insert(root.Value);
        Copy(root.Left);
        Copy(root.Right);
    }

    private void EachInOrderRecursive(BinaryTreeNode<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrderRecursive(node.Left, action);
        action.Invoke(node.Value);
        EachInOrderRecursive(node.Right, action);
    }
}