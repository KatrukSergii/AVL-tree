using System;
using System.Windows;
using System.Windows.Input;
using AVLTree.AvlTree;

namespace AVLTree
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand StartCommand => new Command(this.Start);

        private void Start()
        {
            Tree<int> tree = new Tree<int>(-1);
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(0);
            tree.Add(-1);
            tree.Add(0);
            tree.Add(-1);
            tree.Add(-2);
        }
    }
}