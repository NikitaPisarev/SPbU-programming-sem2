namespace Calculator;

partial class CalculatorForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new TableLayoutPanel();
        display = new Label();
        zeroButton = new Button();
        oneButton = new Button();
        twoButton = new Button();
        threeButton = new Button();
        fourButton = new Button();
        fiveButton = new Button();
        sixButton = new Button();
        sevenButton = new Button();
        eightButton = new Button();
        nineButton = new Button();
        divisionButton = new Button();
        multiplicationButton = new Button();
        subtractionButton = new Button();
        additionButton = new Button();
        equalButton = new Button();
        clearButton = new Button();
        changeSignButton = new Button();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(display, 0, 0);
        tableLayoutPanel1.Controls.Add(zeroButton, 0, 5);
        tableLayoutPanel1.Controls.Add(oneButton, 0, 4);
        tableLayoutPanel1.Controls.Add(twoButton, 1, 4);
        tableLayoutPanel1.Controls.Add(threeButton, 2, 4);
        tableLayoutPanel1.Controls.Add(fourButton, 0, 3);
        tableLayoutPanel1.Controls.Add(fiveButton, 1, 3);
        tableLayoutPanel1.Controls.Add(sixButton, 2, 3);
        tableLayoutPanel1.Controls.Add(sevenButton, 0, 2);
        tableLayoutPanel1.Controls.Add(eightButton, 1, 2);
        tableLayoutPanel1.Controls.Add(nineButton, 2, 2);
        tableLayoutPanel1.Controls.Add(divisionButton, 3, 1);
        tableLayoutPanel1.Controls.Add(multiplicationButton, 3, 2);
        tableLayoutPanel1.Controls.Add(subtractionButton, 3, 3);
        tableLayoutPanel1.Controls.Add(additionButton, 3, 4);
        tableLayoutPanel1.Controls.Add(equalButton, 3, 5);
        tableLayoutPanel1.Controls.Add(clearButton, 0, 1);
        tableLayoutPanel1.Controls.Add(changeSignButton, 2, 1);
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.9027157F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel1.Size = new Size(322, 300);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // display
        // 
        display.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(display, 4);
        display.Dock = DockStyle.Fill;
        display.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
        display.ForeColor = Color.Transparent;
        display.Location = new Point(3, 0);
        display.Name = "display";
        display.Size = new Size(316, 80);
        display.TabIndex = 0;
        display.TextAlign = ContentAlignment.BottomRight;
        // 
        // zeroButton
        // 
        zeroButton.BackColor = Color.FromArgb(63, 63, 63);
        tableLayoutPanel1.SetColumnSpan(zeroButton, 3);
        zeroButton.Dock = DockStyle.Fill;
        zeroButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        zeroButton.ForeColor = Color.Transparent;
        zeroButton.Location = new Point(3, 255);
        zeroButton.Name = "zeroButton";
        zeroButton.Size = new Size(234, 42);
        zeroButton.TabIndex = 0;
        zeroButton.Text = "0";
        zeroButton.UseVisualStyleBackColor = false;
        zeroButton.Click += OnNumberButtonClick;
        // 
        // oneButton
        // 
        oneButton.BackColor = Color.FromArgb(63, 63, 63);
        oneButton.Dock = DockStyle.Fill;
        oneButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        oneButton.ForeColor = Color.Transparent;
        oneButton.Location = new Point(3, 212);
        oneButton.Name = "oneButton";
        oneButton.Size = new Size(74, 37);
        oneButton.TabIndex = 1;
        oneButton.Text = "1";
        oneButton.UseVisualStyleBackColor = false;
        oneButton.Click += OnNumberButtonClick;
        // 
        // twoButton
        // 
        twoButton.BackColor = Color.FromArgb(63, 63, 63);
        twoButton.Dock = DockStyle.Fill;
        twoButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        twoButton.ForeColor = Color.Transparent;
        twoButton.Location = new Point(83, 212);
        twoButton.Name = "twoButton";
        twoButton.Size = new Size(74, 37);
        twoButton.TabIndex = 2;
        twoButton.Text = "2";
        twoButton.UseVisualStyleBackColor = false;
        twoButton.Click += OnNumberButtonClick;
        // 
        // threeButton
        // 
        threeButton.BackColor = Color.FromArgb(63, 63, 63);
        threeButton.Dock = DockStyle.Fill;
        threeButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        threeButton.ForeColor = Color.Transparent;
        threeButton.Location = new Point(163, 212);
        threeButton.Name = "threeButton";
        threeButton.Size = new Size(74, 37);
        threeButton.TabIndex = 3;
        threeButton.Text = "3";
        threeButton.UseVisualStyleBackColor = false;
        threeButton.Click += OnNumberButtonClick;
        // 
        // fourButton
        // 
        fourButton.BackColor = Color.FromArgb(63, 63, 63);
        fourButton.Dock = DockStyle.Fill;
        fourButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        fourButton.ForeColor = Color.Transparent;
        fourButton.Location = new Point(3, 169);
        fourButton.Name = "fourButton";
        fourButton.Size = new Size(74, 37);
        fourButton.TabIndex = 4;
        fourButton.Text = "4";
        fourButton.UseVisualStyleBackColor = false;
        fourButton.Click += OnNumberButtonClick;
        // 
        // fiveButton
        // 
        fiveButton.BackColor = Color.FromArgb(63, 63, 63);
        fiveButton.Dock = DockStyle.Fill;
        fiveButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        fiveButton.ForeColor = Color.Transparent;
        fiveButton.Location = new Point(83, 169);
        fiveButton.Name = "fiveButton";
        fiveButton.Size = new Size(74, 37);
        fiveButton.TabIndex = 5;
        fiveButton.Text = "5";
        fiveButton.UseVisualStyleBackColor = false;
        fiveButton.Click += OnNumberButtonClick;
        // 
        // sixButton
        // 
        sixButton.BackColor = Color.FromArgb(63, 63, 63);
        sixButton.Dock = DockStyle.Fill;
        sixButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        sixButton.ForeColor = Color.Transparent;
        sixButton.Location = new Point(163, 169);
        sixButton.Name = "sixButton";
        sixButton.Size = new Size(74, 37);
        sixButton.TabIndex = 6;
        sixButton.Text = "6";
        sixButton.UseVisualStyleBackColor = false;
        sixButton.Click += OnNumberButtonClick;
        // 
        // sevenButton
        // 
        sevenButton.BackColor = Color.FromArgb(63, 63, 63);
        sevenButton.Dock = DockStyle.Fill;
        sevenButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        sevenButton.ForeColor = Color.Transparent;
        sevenButton.Location = new Point(3, 126);
        sevenButton.Name = "sevenButton";
        sevenButton.Size = new Size(74, 37);
        sevenButton.TabIndex = 7;
        sevenButton.Text = "7";
        sevenButton.UseVisualStyleBackColor = false;
        sevenButton.Click += OnNumberButtonClick;
        // 
        // eightButton
        // 
        eightButton.BackColor = Color.FromArgb(63, 63, 63);
        eightButton.Dock = DockStyle.Fill;
        eightButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        eightButton.ForeColor = Color.Transparent;
        eightButton.Location = new Point(83, 126);
        eightButton.Name = "eightButton";
        eightButton.Size = new Size(74, 37);
        eightButton.TabIndex = 8;
        eightButton.Text = "8";
        eightButton.UseVisualStyleBackColor = false;
        eightButton.Click += OnNumberButtonClick;
        // 
        // nineButton
        // 
        nineButton.BackColor = Color.FromArgb(63, 63, 63);
        nineButton.Dock = DockStyle.Fill;
        nineButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        nineButton.ForeColor = Color.Transparent;
        nineButton.Location = new Point(163, 126);
        nineButton.Name = "nineButton";
        nineButton.Size = new Size(74, 37);
        nineButton.TabIndex = 9;
        nineButton.Text = "9";
        nineButton.UseVisualStyleBackColor = false;
        nineButton.Click += OnNumberButtonClick;
        // 
        // divisionButton
        // 
        divisionButton.BackColor = Color.FromArgb(47, 47, 47);
        divisionButton.Dock = DockStyle.Fill;
        divisionButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        divisionButton.ForeColor = Color.Transparent;
        divisionButton.Location = new Point(243, 83);
        divisionButton.Name = "divisionButton";
        divisionButton.Size = new Size(76, 37);
        divisionButton.TabIndex = 11;
        divisionButton.Text = "÷";
        divisionButton.UseVisualStyleBackColor = false;
        divisionButton.Click += OnOperationButtonClick;
        // 
        // multiplicationButton
        // 
        multiplicationButton.BackColor = Color.FromArgb(47, 47, 47);
        multiplicationButton.Dock = DockStyle.Fill;
        multiplicationButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        multiplicationButton.ForeColor = Color.Transparent;
        multiplicationButton.Location = new Point(243, 126);
        multiplicationButton.Name = "multiplicationButton";
        multiplicationButton.Size = new Size(76, 37);
        multiplicationButton.TabIndex = 12;
        multiplicationButton.Text = "×";
        multiplicationButton.UseVisualStyleBackColor = false;
        multiplicationButton.Click += OnOperationButtonClick;
        // 
        // subtractionButton
        // 
        subtractionButton.BackColor = Color.FromArgb(47, 47, 47);
        subtractionButton.Dock = DockStyle.Fill;
        subtractionButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        subtractionButton.ForeColor = Color.Transparent;
        subtractionButton.Location = new Point(243, 169);
        subtractionButton.Name = "subtractionButton";
        subtractionButton.Size = new Size(76, 37);
        subtractionButton.TabIndex = 13;
        subtractionButton.Text = "-";
        subtractionButton.UseVisualStyleBackColor = false;
        subtractionButton.Click += OnOperationButtonClick;
        // 
        // additionButton
        // 
        additionButton.BackColor = Color.FromArgb(47, 47, 47);
        additionButton.Dock = DockStyle.Fill;
        additionButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        additionButton.ForeColor = Color.Transparent;
        additionButton.Location = new Point(243, 212);
        additionButton.Name = "additionButton";
        additionButton.Size = new Size(76, 37);
        additionButton.TabIndex = 14;
        additionButton.Text = "+";
        additionButton.UseVisualStyleBackColor = false;
        additionButton.Click += OnOperationButtonClick;
        // 
        // equalButton
        // 
        equalButton.BackColor = Color.Orchid;
        equalButton.Dock = DockStyle.Fill;
        equalButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        equalButton.ForeColor = Color.Transparent;
        equalButton.Location = new Point(243, 255);
        equalButton.Name = "equalButton";
        equalButton.Size = new Size(76, 42);
        equalButton.TabIndex = 15;
        equalButton.Text = "=";
        equalButton.UseVisualStyleBackColor = false;
        equalButton.Click += OnEqualButtonClick;
        // 
        // clearButton
        // 
        clearButton.BackColor = Color.FromArgb(47, 47, 47);
        tableLayoutPanel1.SetColumnSpan(clearButton, 2);
        clearButton.Dock = DockStyle.Fill;
        clearButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        clearButton.ForeColor = Color.Transparent;
        clearButton.Location = new Point(3, 83);
        clearButton.Name = "clearButton";
        clearButton.Size = new Size(154, 37);
        clearButton.TabIndex = 16;
        clearButton.Text = "C";
        clearButton.TextImageRelation = TextImageRelation.ImageAboveText;
        clearButton.UseVisualStyleBackColor = false;
        clearButton.Click += OnClearButtonClick;
        // 
        // changeSignButton
        // 
        changeSignButton.BackColor = Color.FromArgb(47, 47, 47);
        changeSignButton.Dock = DockStyle.Fill;
        changeSignButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        changeSignButton.ForeColor = Color.Transparent;
        changeSignButton.Location = new Point(163, 83);
        changeSignButton.Name = "changeSignButton";
        changeSignButton.Size = new Size(74, 37);
        changeSignButton.TabIndex = 10;
        changeSignButton.Text = "+/-";
        changeSignButton.UseVisualStyleBackColor = false;
        changeSignButton.Click += OnChangeSignButtonClick;
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(29, 29, 29);
        ClientSize = new Size(322, 300);
        Controls.Add(tableLayoutPanel1);
        MinimumSize = new Size(200, 200);
        Name = "CalculatorForm";
        Text = "Calculator";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label display;
    private Button zeroButton;
    private Button oneButton;
    private Button twoButton;
    private Button threeButton;
    private Button fourButton;
    private Button fiveButton;
    private Button sixButton;
    private Button sevenButton;
    private Button eightButton;
    private Button nineButton;
    private Button divisionButton;
    private Button multiplicationButton;
    private Button subtractionButton;
    private Button additionButton;
    private Button equalButton;
    private Button clearButton;
    private Button changeSignButton;
}