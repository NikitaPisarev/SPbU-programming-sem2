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

            if (display.Text == "������� ������ �����! (X)" || display.Text == "������� ������ �����! (O)" || display.Text == "�����!")
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