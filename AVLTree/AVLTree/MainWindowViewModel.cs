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
        }
        
    }
}