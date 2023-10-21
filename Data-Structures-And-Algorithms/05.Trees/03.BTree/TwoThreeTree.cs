namespace _03.BTree
{
    public class TwoThreeTree<T> where T : IComparable<T>
    {
        public TwoThreeTreeNode<T> Root { get; set; }

        private TwoThreeTreeNode<T> InternalInsert(TwoThreeTreeNode<T> root, T value)
        {
            if(root.IsLeafNode())
            {
                if(!root.IsThreeNode())
                {
                    if(root.LeftKey.CompareTo(value) < 0)
                    {
                        root.RightKey = value;
                    }
                    else
                    {
                        root.RightKey = root.LeftKey;
                        root.LeftKey = value;
                    }
                }
                else
                {
                    T leftKey = root.LeftKey;
                    T rightKey = root.RightKey;

                    if(value.CompareTo(leftKey) < 0)
                    {
                        return new TwoThreeTreeNode<T>(leftKey, new TwoThreeTreeNode<T>(value), new TwoThreeTreeNode<T>(rightKey));
                    } 
                    else if(value.CompareTo(leftKey) > 0 && value.CompareTo(rightKey) < 0)
                    {
                        return new TwoThreeTreeNode<T>(value, new TwoThreeTreeNode<T>(leftKey), new TwoThreeTreeNode<T>(rightKey));
                    }
                    else if(value.CompareTo(rightKey) > 0)
                    {
                        return new TwoThreeTreeNode<T>(rightKey, new TwoThreeTreeNode<T>(leftKey), new TwoThreeTreeNode<T>(value));
                    }
                }
            }
            else
            {
                TwoThreeTreeNode<T> newNode = null;

                if(!root.IsThreeNode() && value.CompareTo(root.LeftKey) < 0)
                {
                    newNode = this.InternalInsert(root.LeftChild, value);
                } 
                else if(!root.IsThreeNode() && value.CompareTo(root.LeftKey) > 0)
                {
                    newNode = this.InternalInsert(root.RightChild, value);
                }
                else if(root.IsThreeNode() && value.CompareTo(root.LeftKey) < 0)
                {
                    newNode = this.InternalInsert(root.LeftChild, value);
                }
                else if(root.IsThreeNode() && value.CompareTo(root.LeftKey) > 0 && value.CompareTo(root.RightKey) < 0)
                {
                    newNode = this.InternalInsert(root.MiddleChild, value);
                }
                else if(root.IsThreeNode() && value.CompareTo(root.RightKey) > 0)
                {
                    newNode = this.InternalInsert(root.RightChild, value);
                }

                if(newNode != null)
                {
                    if (!root.IsThreeNode())
                    {
                        if (newNode.LeftKey.CompareTo(root.LeftKey) < 0)
                        {
                            root.RightKey = root.LeftKey;
                            root.LeftKey = newNode.LeftKey;
                            root.MiddleChild = newNode.RightChild;
                            root.LeftChild = newNode.LeftChild;
                        }
                        else
                        {
                            root.RightKey = newNode.LeftKey;
                            root.MiddleChild = newNode.LeftChild;
                            root.RightChild = newNode.RightChild;
                        }
                    }
                    else
                    {
                        if (newNode.LeftKey.CompareTo(root.LeftKey) < 0)
                        {
                            TwoThreeTreeNode<T> leftChild = newNode;
                            TwoThreeTreeNode<T> rightChild = new TwoThreeTreeNode<T>(root.RightKey, root.MiddleChild, root.RightChild);
                            TwoThreeTreeNode<T> newRoot = new TwoThreeTreeNode<T>(root.LeftKey, leftChild, rightChild);

                            return newRoot;
                        }
                        else if (newNode.LeftKey.CompareTo(root.LeftKey) > 0 
                            && newNode.LeftKey.CompareTo(root.RightKey) < 0)
                        {
                            TwoThreeTreeNode<T> leftChild = new TwoThreeTreeNode<T>(root.LeftKey, root.LeftChild, newNode.LeftChild);
                            TwoThreeTreeNode<T> rightChild = new TwoThreeTreeNode<T>(root.RightKey, newNode.RightChild, root.RightChild);
                            TwoThreeTreeNode<T> newRoot = new TwoThreeTreeNode<T>(newNode.LeftKey, leftChild, rightChild);

                            return newRoot;
                        }
                        else if(newNode.LeftKey.CompareTo(root.RightKey) > 0)
                        {
                            TwoThreeTreeNode<T> leftChild = new TwoThreeTreeNode<T>(root.LeftKey, root.LeftChild, root.MiddleChild);
                            TwoThreeTreeNode<T> rightChild = newNode;
                            TwoThreeTreeNode<T> newRoot = new TwoThreeTreeNode<T>(root.RightKey, leftChild, rightChild);

                            return newRoot;
                        }
                    }
                }
            }

            return null;
        }

        public void Insert(T value)
        {
            if(this.Root == null)
            {
                this.Root = new TwoThreeTreeNode<T>(value);
            }
            else
            {
                TwoThreeTreeNode<T> newRoot = this.InternalInsert(this.Root, value);
                
                if(newRoot != null)
                {
                    this.Root = newRoot;
                }
            }
        }
    }
}
