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
            MyTestClass treeValue = null;
            MyTestClass listValue = null;
            Tree<MyTestClass, string> tree = new Tree<MyTestClass, string>();
            for (int i = 0; i < 1000000; i++)
            {
                var rand = new MyTestClass(r.Next());
                tree.Add(rand);
                if (i == 500000)
                    treeValue = rand;
            }

            this.Info = tree.Count.ToString();

            List<MyTestClass> list = new List<MyTestClass>();
            for (int i = 0; i < 1000000; i++)
            {
                var rand = new MyTestClass(r.Next()); ;
                list.Add(rand);
                if (i == 500000)
                    listValue = rand;
            }
            this.Info = list.Count.ToString();
            var foundTree = tree.Find(treeValue.Key);
            var foundList = list.Find(v => v.Key == listValue.Key);
            this.Info = foundTree.ToString();
            this.Info = foundList.ToString();
        }
        
        public string Info { get; private set; }
        
    }
}