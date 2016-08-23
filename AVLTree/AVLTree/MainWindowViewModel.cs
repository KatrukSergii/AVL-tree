using System;
using System.Windows.Input;

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