using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MostValuablePaths
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; }
    }
}
