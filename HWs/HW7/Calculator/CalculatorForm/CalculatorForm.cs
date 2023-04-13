namespace Calculator;

/// <summary>
/// Form for the Calculator application
/// </summary>
public partial class CalculatorForm : Form
{
    private Calculator calculator = new();

    /// <summary>
    /// Initializing components in the form.
    /// </summary>
    public CalculatorForm()
    {
        InitializeComponent();

        display.DataBindings.Add("Text", calculator, "Display", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void OnNumberButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        calculator.AddNumberInCalcultor(button.Text.First());
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        calculator.AddOperationInCalcultor(button.Text.First());
    }

    private void OnEqualButtonClick(object sender, EventArgs e)
    {
        calculator.Calculate();
    }

    private void OnClearButtonClick(object sender, EventArgs e)
    {
        calculator.ClearCalculator();
    }

    private void OnChangeSignButtonClick(object sender, EventArgs e)
    {
        calculator.ChangeSign();
    }
}