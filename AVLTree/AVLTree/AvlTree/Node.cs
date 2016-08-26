using System;

namespace AVLTree.AvlTree
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }
        public Tree<T> Tree { get;}
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

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
        }

        public void Add(T item)
        {
        }

        public void Romove(T item)
        {
            
        }
    }
}