using System;

namespace AVLTree.AvlTree
{
    public class Tree<T> where T : IComparable
    {
        public void Add(T item)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(item, this);
                return;
            }
            this.Root = this.Root.Add(this.Root, item);
        }

        public T DefaultValue { get; }

        public T Find(Func<T, short> predicate)
        {
            if (this.Root == null)
                return this.DefaultValue;
            return this.Root.Find(predicate);
        }

        public void Remove(T item)
        {
            this.Root = this.Root?.Remove(this.Root, item);
        }

        public Node<T> Root { get; private set; }

        public Tree(T defaultValue = default(T))
        {
            this.DefaultValue = defaultValue;
        }
    }
}
