using System;
using AVLTree.AvlTree;

namespace AVLTree
{
    public class MyTestClass : ITreeComparable<string>
    {
        public string Key { get; }
        public int Value { get; set; }
        public int Compare(string key)
        {
            return this.Key.CompareTo(key);
        }

        public int CompareTo(object obj)
        {
            var val = obj as MyTestClass;
            if (obj == null)
                return 0;
            return val.Key.CompareTo(this.Key);
        }

        public MyTestClass(int value)
        {
            this.Key = value.ToString();
            this.Value = value;
        }
    }
}