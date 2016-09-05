using System;

namespace AVLTree.AvlTree
{
    public interface ITreeComparable<T>: IComparable
    {
        int Compare(T key);
    }
}