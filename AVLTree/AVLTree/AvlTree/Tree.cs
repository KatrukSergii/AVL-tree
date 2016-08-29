using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree.AvlTree
{
    public class Tree<T> where T : IComparable
    {
        public T DefaultValue { get; }
        public Node<T> Root { get; set; }

        public void Add(T item)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(item, this);
                return;
            }
            this.Root.Add(this.Root, item);
        }

        public void Remove(T item)
        {
            this.Root?.Remove(this.Root, item);
        }
        public T Find(Func<T, short> predicate)
        {
            if (this.Root == null)
                return this.DefaultValue;
            return this.Root.Find(predicate);
        }
        public Tree(T defaultValue = default(T))
        {
            this.DefaultValue = defaultValue;
        }
    }
}
