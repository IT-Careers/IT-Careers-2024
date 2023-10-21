namespace _03.BTree
{
    public class TwoThreeTreeNode<T> where T : IComparable<T>
    {
        private bool hasRightKey = false;

        private T rightKey;

        public TwoThreeTreeNode(T value) 
        {
            this.LeftKey = value;
        }

        public TwoThreeTreeNode(T value, TwoThreeTreeNode<T> leftChild, TwoThreeTreeNode<T> rightChild) : this(value)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T LeftKey { get; set; }

        public T RightKey 
        { 
            get 
            {
                return this.rightKey;
            }
            set 
            {
                this.rightKey = value;
                this.hasRightKey = true;
            } 
        }

        public TwoThreeTreeNode<T> LeftChild { get; set; } = null;

        public TwoThreeTreeNode<T> MiddleChild { get; set; } = null;

        public TwoThreeTreeNode<T> RightChild { get; set; } = null;

        public bool IsLeafNode()
        {
            return this.LeftChild == null && this.MiddleChild == null && this.RightChild == null;
        }

        public bool IsThreeNode()
        {
            return this.hasRightKey;
        }
    }
}
