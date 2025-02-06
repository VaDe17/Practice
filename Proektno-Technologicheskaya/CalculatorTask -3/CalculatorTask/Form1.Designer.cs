namespace CalculatorTask
{
    partial class Form1
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
            textBox1 = new TextBox();
            ResetButton = new Button();
            DeleteButton = new Button();
            button3 = new Button();
            Add = new Button();
            Sub = new Button();
            Nine = new Button();
            Eight = new Button();
            Seven = new Button();
            Mult = new Button();
            Six = new Button();
            Five = new Button();
            Four = new Button();
            Div = new Button();
            Three = new Button();
            Two = new Button();
            One = new Button();
            Zero = new Button();
            point = new Button();
            Equals = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(45, 41);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 50);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(45, 120);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(70, 50);
            ResetButton.TabIndex = 1;
            ResetButton.Text = "C";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += button1_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(121, 120);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(70, 50);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "<-";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(197, 120);
            button3.Name = "button3";
            button3.Size = new Size(70, 50);
            button3.TabIndex = 3;
            button3.Text = "+/-";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Add
            // 
            Add.Location = new Point(273, 120);
            Add.Name = "Add";
            Add.Size = new Size(70, 50);
            Add.TabIndex = 4;
            Add.Text = "+";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Sub
            // 
            Sub.Location = new Point(273, 176);
            Sub.Name = "Sub";
            Sub.Size = new Size(70, 50);
            Sub.TabIndex = 8;
            Sub.Text = "-";
            Sub.UseVisualStyleBackColor = true;
            Sub.Click += Sub_Click;
            // 
            // Nine
            // 
            Nine.Location = new Point(197, 176);
            Nine.Name = "Nine";
            Nine.Size = new Size(70, 50);
            Nine.TabIndex = 7;
            Nine.Text = "9";
            Nine.UseVisualStyleBackColor = true;
            Nine.Click += Nine_Click;
            // 
            // Eight
            // 
            Eight.Location = new Point(121, 176);
            Eight.Name = "Eight";
            Eight.Size = new Size(70, 50);
            Eight.TabIndex = 6;
            Eight.Text = "8";
            Eight.UseVisualStyleBackColor = true;
            Eight.Click += Eight_Click;
            // 
            // Seven
            // 
            Seven.Location = new Point(45, 176);
            Seven.Name = "Seven";
            Seven.Size = new Size(70, 50);
            Seven.TabIndex = 5;
            Seven.Text = "7";
            Seven.UseVisualStyleBackColor = true;
            Seven.Click += Seven_Click;
            // 
            // Mult
            // 
            Mult.Location = new Point(273, 232);
            Mult.Name = "Mult";
            Mult.Size = new Size(70, 50);
            Mult.TabIndex = 12;
            Mult.Text = "*";
            Mult.UseVisualStyleBackColor = true;
            Mult.Click += Mult_Click;
            // 
            // Six
            // 
            Six.Location = new Point(197, 232);
            Six.Name = "Six";
            Six.Size = new Size(70, 50);
            Six.TabIndex = 11;
            Six.Text = "6";
            Six.UseVisualStyleBackColor = true;
            Six.Click += Six_Click;
            // 
            // Five
            // 
            Five.Location = new Point(121, 232);
            Five.Name = "Five";
            Five.Size = new Size(70, 50);
            Five.TabIndex = 10;
            Five.Text = "5";
            Five.UseVisualStyleBackColor = true;
            Five.Click += Five_Click;
            // 
            // Four
            // 
            Four.Location = new Point(45, 232);
            Four.Name = "Four";
            Four.Size = new Size(70, 50);
            Four.TabIndex = 9;
            Four.Text = "4";
            Four.UseVisualStyleBackColor = true;
            Four.Click += Four_Click;
            // 
            // Div
            // 
            Div.Location = new Point(273, 288);
            Div.Name = "Div";
            Div.Size = new Size(70, 50);
            Div.TabIndex = 16;
            Div.Text = "/";
            Div.UseVisualStyleBackColor = true;
            Div.Click += Div_Click;
            // 
            // Three
            // 
            Three.Location = new Point(197, 288);
            Three.Name = "Three";
            Three.Size = new Size(70, 50);
            Three.TabIndex = 15;
            Three.Text = "3";
            Three.UseVisualStyleBackColor = true;
            Three.Click += Three_Click;
            // 
            // Two
            // 
            Two.Location = new Point(121, 288);
            Two.Name = "Two";
            Two.Size = new Size(70, 50);
            Two.TabIndex = 14;
            Two.Text = "2";
            Two.UseVisualStyleBackColor = true;
            Two.Click += Two_Click;
            // 
            // One
            // 
            One.Location = new Point(45, 288);
            One.Name = "One";
            One.Size = new Size(70, 50);
            One.TabIndex = 13;
            One.Text = "1";
            One.UseVisualStyleBackColor = true;
            One.Click += button16_Click;
            // 
            // Zero
            // 
            Zero.Location = new Point(45, 344);
            Zero.Name = "Zero";
            Zero.Size = new Size(70, 50);
            Zero.TabIndex = 17;
            Zero.Text = "0";
            Zero.UseVisualStyleBackColor = true;
            Zero.Click += button1_Click_1;
            // 
            // point
            // 
            point.Location = new Point(121, 344);
            point.Name = "point";
            point.Size = new Size(70, 50);
            point.TabIndex = 18;
            point.Text = ".";
            point.UseVisualStyleBackColor = true;
            point.Click += point_Click;
            // 
            // Equals
            // 
            Equals.Location = new Point(197, 344);
            Equals.Name = "Equals";
            Equals.Size = new Size(146, 50);
            Equals.TabIndex = 19;
            Equals.Text = "=";
            Equals.UseVisualStyleBackColor = true;
            Equals.Click += Equals_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(54, 57);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 435);
            Controls.Add(label1);
            Controls.Add(Equals);
            Controls.Add(point);
            Controls.Add(Zero);
            Controls.Add(Div);
            Controls.Add(Three);
            Controls.Add(Two);
            Controls.Add(One);
            Controls.Add(Mult);
            Controls.Add(Six);
            Controls.Add(Five);
            Controls.Add(Four);
            Controls.Add(Sub);
            Controls.Add(Nine);
            Controls.Add(Eight);
            Controls.Add(Seven);
            Controls.Add(Add);
            Controls.Add(button3);
            Controls.Add(DeleteButton);
            Controls.Add(ResetButton);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "calculator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button ResetButton;
        private Button DeleteButton;
        private Button button3;
        private Button Add;
        private Button Sub;
        private Button Nine;
        private Button Eight;
        private Button Seven;
        private Button Mult;
        private Button Six;
        private Button Five;
        private Button Four;
        private Button Div;
        private Button Three;
        private Button Two;
        private Button One;
        private Button Zero;
        private Button point;
        private Button Equals;
        private Label label1;
    }
}
