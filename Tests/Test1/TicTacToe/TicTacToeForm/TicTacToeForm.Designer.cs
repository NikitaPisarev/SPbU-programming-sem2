namespace TicTacToe
{
    partial class TicTacToeForm
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(display, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Controls.Add(button2, 1, 1);
            tableLayoutPanel1.Controls.Add(button3, 2, 1);
            tableLayoutPanel1.Controls.Add(button4, 0, 2);
            tableLayoutPanel1.Controls.Add(button5, 1, 2);
            tableLayoutPanel1.Controls.Add(button6, 2, 2);
            tableLayoutPanel1.Controls.Add(button7, 0, 3);
            tableLayoutPanel1.Controls.Add(button8, 1, 3);
            tableLayoutPanel1.Controls.Add(button9, 2, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(284, 261);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // display
            // 
            display.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(display, 3);
            display.Dock = DockStyle.Fill;
            display.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            display.Location = new Point(3, 0);
            display.Name = "display";
            display.Size = new Size(278, 65);
            display.TabIndex = 0;
            display.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(3, 68);
            button1.Name = "button1";
            button1.Size = new Size(88, 59);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnButtonClick;
            buttons.Add(button1);
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(97, 68);
            button2.Name = "button2";
            button2.Size = new Size(88, 59);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnButtonClick;
            buttons.Add(button2);
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(191, 68);
            button3.Name = "button3";
            button3.Size = new Size(90, 59);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnButtonClick;
            buttons.Add(button3);
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(3, 133);
            button4.Name = "button4";
            button4.Size = new Size(88, 59);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = true;
            button4.Click += OnButtonClick;
            buttons.Add(button4);
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(97, 133);
            button5.Name = "button5";
            button5.Size = new Size(88, 59);
            button5.TabIndex = 5;
            button5.UseVisualStyleBackColor = true;
            button5.Click += OnButtonClick;
            buttons.Add(button5);
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(191, 133);
            button6.Name = "button6";
            button6.Size = new Size(90, 59);
            button6.TabIndex = 6;
            button6.UseVisualStyleBackColor = true;
            button6.Click += OnButtonClick;
            buttons.Add(button6);
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(3, 198);
            button7.Name = "button7";
            button7.Size = new Size(88, 60);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = true;
            button7.Click += OnButtonClick;
            buttons.Add(button7);
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(97, 198);
            button8.Name = "button8";
            button8.Size = new Size(88, 60);
            button8.TabIndex = 8;
            button8.UseVisualStyleBackColor = true;
            button8.Click += OnButtonClick;
            buttons.Add(button8);
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Location = new Point(191, 198);
            button9.Name = "button9";
            button9.Size = new Size(90, 60);
            button9.TabIndex = 9;
            button9.UseVisualStyleBackColor = true;
            button9.Click += OnButtonClick;
            buttons.Add(button9);
            // 
            // TicTacToeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(300, 300);
            Name = "TicTacToeForm";
            Text = "TicTacToe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label display;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private List<Button> buttons = new();
    }
}