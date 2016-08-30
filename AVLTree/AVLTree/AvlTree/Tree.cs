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

        public int Count => this.Root?.Height ?? 0;

        public T DefaultValue { get; }

        public T Find(Func<T, short> predicate)
        {
            if (this.Root == null)
                return this.DefaultValue;
            return this.Root.Find(predicate);
        }

        public T Find(Func<T, T, short> predicate, T arg)
        {
            if (this.Root == null)
                return this.DefaultValue;
            return this.Root.Find(predicate, arg);
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
