namespace prawo_jazdy
{
    partial class Menuform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(320, 135);
            button1.Name = "button1";
            button1.Size = new Size(133, 29);
            button1.TabIndex = 0;
            button1.Text = "Kategoria A1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(320, 183);
            button2.Name = "button2";
            button2.Size = new Size(133, 29);
            button2.TabIndex = 1;
            button2.Text = "Kategoria B";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(320, 229);
            button3.Name = "button3";
            button3.Size = new Size(133, 29);
            button3.TabIndex = 2;
            button3.Text = "Kategoria C";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(320, 277);
            button4.Name = "button4";
            button4.Size = new Size(133, 29);
            button4.TabIndex = 3;
            button4.Text = "Kategoria C+E";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(320, 325);
            button5.Name = "button5";
            button5.Size = new Size(133, 29);
            button5.TabIndex = 4;
            button5.Text = "Kategoria D";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(163, 63);
            label1.Name = "label1";
            label1.Size = new Size(480, 46);
            label1.TabIndex = 5;
            label1.Text = "Wybór kategorii prawa jazdy";
            // 
            // button6
            // 
            button6.Location = new Point(12, 409);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 6;
            button6.Text = "Wyloguj";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Menuform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Menuform";
            Text = "Menuform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private Button button6;
    }
}