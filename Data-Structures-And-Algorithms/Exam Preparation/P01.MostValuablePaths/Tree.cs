namespace P01.MostValuablePaths
{
    public class Tree
    {
        public TreeNode<int> Root { get; set; }

        public void Add(int parentValue, int childValue)
        {
            if (Root == null)
            {
                Root = new TreeNode<int>(parentValue);
                Root.Children.Add(new TreeNode<int>(childValue));
                return;
            }

            TreeNode<int> parentNode = SearchNode(parentValue);

            if (parentNode != null)
            {
                parentNode.Children.Add(new TreeNode<int>(childValue));
            }
        }

        private TreeNode<int> SearchNode(int parentValue)
        {
            return InternalSearchNode(parentValue, Root);
        }

        private TreeNode<int> InternalSearchNode(int searchValue, TreeNode<int> node)
        {
            if (node != null)
            {
                if (node.Value.Equals(searchValue))
                {
                    return node;
                }

                for (int i = 0; i < node.Children.Count; i++)
                {
                    TreeNode<int> child = node.Children[i];

                    TreeNode<int> foundNode = InternalSearchNode(searchValue, child);

                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }
            }

            return null;
        }

        public List<List<int>> CalculateTopThree()
        {
            List<List<int>> result = new List<List<int>>();
            List<int> path = new List<int>();

            InternalCalculateTopThree(Root, path, result);

            return result;
        }

        public void InternalCalculateTopThree(TreeNode<int> node, List<int> path, List<List<int>> result)
        {
            if (node != null)
            {
                path.Add(node.Value);

                for (int i = 0;i < node.Children.Count;i++)
                {
                    TreeNode<int> child = node.Children[i];

                    InternalCalculateTopThree(child, path, result);
                }

                if (node.Children.Count == 0)
                {
                    result.Add(new List<int>(path));
                }

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
