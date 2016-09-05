using System;

namespace AVLTree.AvlTree
{
    public class Tree<T, S> where T : ITreeComparable<S>
    {
        public void Add(T item)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T, S>(item, this);
                return;
            }
            this.Root = this.Root.Add(this.Root, item);
        }

        public int Count => this.Root?.Height ?? 0;

        public T DefaultValue { get; }

        public T Find(S key)
        {
            if (this.Root == null)
                return this.DefaultValue;
            return this.Root.Find(key);
        }

        public void Remove(T item)
        {
            this.Root = this.Root?.Remove(this.Root, item);
        }

        public Node<T, S> Root { get; private set; }

        public Tree(T defaultValue = default(T))
        {
            this.DefaultValue = defaultValue;
        }
    }
}
