using System;

namespace AVLTree.AvlTree
{
    public class Node<T> where T : IComparable
    {
        public Node<T> Add(Node<T> node, T item)
        {
            if (item == null)
                return node;

            var comparisionResult = item.CompareTo(node.Value);
            if (comparisionResult == 0)
                return node;
            var newNode = new Node<T>(item, node.Tree);
            if (comparisionResult < 0)
                if (node.Left == null)
                    node.Left = newNode;
                else
                    node.Left = node.Left.Add(node.Left, item);
            if (comparisionResult > 0)
                if (node.Right == null)
                    node.Right = newNode;
                else
                    node.Right = node.Right.Add(node.Right, item);
            return node.Balance(node);
        }

        protected Node<T> Balance(Node<T> node)
        {
            node.FixHeight(node);
            if (node.BalanceFactor(node) == 2)
            {
                if (node.BalanceFactor(node.Right) < 0)
                    node.Right = node.RotateRight(node.Right);
                return node.RotaiteLeft(node);
            }
            if (node.BalanceFactor(node) == -2)
            {
                if (node.BalanceFactor(node.Left) > 0)
                    node.Left = node.RotaiteLeft(node.Left);
                return node.RotateRight(node);
            }
            return node;
        }

        public int BalanceFactor(Node<T> node)
        {
            return (node?.Right?.Height ?? 0) - (node?.Left?.Height ?? 0);
        }

        public T Find(Func<T, short> predicate)
        {
            var comparisionResult = predicate(this.Value);
            if (comparisionResult == 0)
                return this.Value;
            if ((comparisionResult > 0) && (this.Right != null))
                return this.Right.Find(predicate);
            if ((comparisionResult < 0) && (this.Left != null))
                return this.Left.Find(predicate);
            return this.Tree.DefaultValue;
        }

        protected Node<T> FindMin(Node<T> node)
        {
            return node?.Left?.FindMin(node.Left) ?? node;
        }

        protected void FixHeight(Node<T> node)
        {
            if (node == null)
                return;
            var leftH = node.GetHeight(node.Left);
            var rightH = node.GetHeight(node.Right);
            node.Height = (leftH > rightH ? leftH : rightH) + 1;
        }

        protected int GetHeight(Node<T> node)
        {
            return node?.Height ?? 0;
        }

        public int Height { get; private set; }

        public Node<T> Left { get; set; }

        public Node(T value, Tree<T> tree = null)
        {
            this.Tree = tree;
            this.Value = value;
            this.Height = 1;
        }

        public Node<T> Remove(Node<T> node, T item)
        {
            var comparisionResult = item.CompareTo(node.Value);
            if (comparisionResult < 0)
                node.Left = node.Remove(node.Left, item);
            else if (comparisionResult > 0)
                node.Right = node.Remove(node.Right, item);
            else
            {
                var q = node.Left;
                var r = node.Right;
                if (r == null)
                    return q;
                var min = node.FindMin(r);
                min.Right = node.RemoveMin(r);
                min.Left = q;
                return node.Balance(min);
            }
            return node.Balance(node);
        }

        protected Node<T> RemoveMin(Node<T> node)
        {
            if (node.Left == null)
                return node.Right;
            node.Left = node.RemoveMin(node.Left);
            return node.Balance(node);
        }

        public Node<T> Right { get; set; }

        protected Node<T> RotaiteLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            node.FixHeight(node);
            node.FixHeight(right);
            return right;
        }

        protected Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            node.FixHeight(node);
            node.FixHeight(left);
            return left;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public Tree<T> Tree { get; }

        public T Value { get; set; }
    }
}