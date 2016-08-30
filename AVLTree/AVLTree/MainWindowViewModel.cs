using System;
using System.Collections.Generic;
using System.Windows.Input;
using AVLTree.AvlTree;

namespace AVLTree
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand StartCommand => new Command(this.Start);

        private void Start()
        {
            Random r = new Random(234);
            int treeValue = 0;
            int listValue = 0;
            Tree<int> tree = new Tree<int>();
            for (int i = 0; i < 1000000; i++)
            {
                var rand = r.Next();
                tree.Add(rand);
                if (i == 500000)
                    treeValue = rand;
            }

            this.Info = tree.Count.ToString();

            List<int> list = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                var rand = r.Next();
                list.Add(rand);
                if (i == 500000)
                    listValue = rand;
            }
            this.Info = list.Count.ToString();
            var foundTree = tree.Find(this.FindPredicate, treeValue);
            var foundList = list.Find(v => v == listValue);
            this.Info = foundTree.ToString();
            this.Info = foundList.ToString();
        }

        private short FindPredicate(int currentValue, int valueToFind)
        {
            return (short)valueToFind.CompareTo(currentValue);
        }

        public string Info { get; private set; }
        
    }
}