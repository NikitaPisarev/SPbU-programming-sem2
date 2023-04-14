
using System.ComponentModel;

namespace TicTacToe
{
    internal class MyChar
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private char _myChar;

        public char Char
        {
            get
            {
                return _myChar;
            }
            set
            {
                _myChar = value;
                _notifyPropertyChanged(nameof(_myChar));
            }

        }

        private void _notifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
