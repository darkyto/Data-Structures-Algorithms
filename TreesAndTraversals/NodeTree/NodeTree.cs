using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTree
{
    public delegate void TreeVisitor<T>(T nodeData);

    public class NodeTree<T>
    {
        public NodeTree(T value)
        {
            this.Value = value;
            this.Children = new List<NodeTree<T>>();
            this.HasParent = false;
        }

        public T Value { get; set; }

        public List<NodeTree<T>> Children { get; set; }

        public bool HasParent { get; protected set; }

        public bool HasChildren { get { return this.Children.Count > 0; } }

        public void AddChild(params NodeTree<T>[] children)
        {
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.HasParent = true;
            }
        }

        public void TraversePrint(NodeTree<T> node, TreeVisitor<string> visitor, int depth)
        {
            visitor(new string(' ', depth * 3) + "|---[" + node.Value + "]");
            foreach (NodeTree<T> kid in node.Children)
            {
                TraversePrint(kid, visitor, depth + 1);
            }
        }
    }
}
