using System;

namespace AVLTree.AvlTree
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }
        public Tree<T> Tree { get; }

        public Node<T> Left
        {
            get; set;
        }

        public Node<T> Right
        {
            get; set;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
        public T Find(Func<T, short> predicate)
        {
            var comparisionResult = predicate(this.Value);
            if (comparisionResult == 0)
                return this.Value;
            if (comparisionResult > 0 && this.Right != null)
                return this.Right.Find(predicate);
            if (comparisionResult < 0 && this.Left != null)
                return this.Left.Find(predicate);
            return this.Tree.DefaultValue;
        }
        public Node(T value, Tree<T> tree = null)
        {
            this.Tree = tree;
            this.Value = value;
            this.Height = 1;
        }

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
                    node.Left.Add(node.Left, item);
            if (comparisionResult > 0)
                if (node.Right == null)
                    node.Right = newNode;
                else
                    node.Right.Add(node.Right, item);
            return node.Balance(node);
        }

        protected Node<T> FindMin(Node<T> node)
        {
            return node?.Left?.FindMin(node.Left) ?? node;
        }

        protected Node<T> RemoveMin(Node<T> node)
        {
            if (node.Left == null)
                return node.Right;
            node.Left = node.RemoveMin(node.Left);
            return node.Balance(node);
        }

        public Node<T> Remove(Node<T> node, T item)
        {
            var comparisionResult = node.Value.CompareTo(item);
            if (comparisionResult < 0)
                node.Left = node.Remove(node.Left, item);
            else if (comparisionResult < 0)
                node.Right = node.Remove(node.Right, item);
            else
            {
                Node<T> q = node.Left;
                Node<T> r = node.Right;
                if (r == null)
                    return q;
                Node<T> min = node.FindMin(r);
                min.Right = node.RemoveMin(r);
                min.Left = q;
                return node.Balance(node);
            }
            return node.Balance(node);
        }

        protected int GetHeight(Node<T> node)
        {
            return node?.Height ?? 0;
        }

        public int BalanceFactor(Node<T> node)
        {
            return (node?.Right?.Height ?? 0) - (node?.Left?.Height ?? 0);
        }

        public int Height { get; private set; }

        protected void FixHeight(Node<T> node)
        {
            if (node == null)
                return;
            var leftH = node.GetHeight(node.Left);
            var rightH = node.GetHeight(node.Right);
            node.Height = (leftH > rightH ? leftH : rightH) + 1;
        }

        protected Node<T> RotateRight(Node<T> node)
        {
            Node<T> left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            node.FixHeight(node);
            node.FixHeight(left);
            return left;
        }

        protected Node<T> RotaiteLeft(Node<T> node)
        {
            Node<T> right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            node.FixHeight(node);
            node.FixHeight(right);
            return right;
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
    }
}