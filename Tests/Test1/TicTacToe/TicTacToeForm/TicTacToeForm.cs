namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private TicTacToe _ticTacToe = new();

        public TicTacToeForm()
        {
            InitializeComponent();

            display.DataBindings.Add("Text", _ticTacToe, "Display", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.Text = _ticTacToe.AddNewElementInCells(button.TabIndex);

            if (display.Text == "Победил первый игрок! (X)" || display.Text == "Победил второй игрок! (O)" || display.Text == "Ничья!")
            {
                _disableAllButtons();
            }
        }

        private void _disableAllButtons()
        {
            foreach(var i in buttons)
            {
                i.Enabled = false;
            }
        }
    }
}