namespace prawo_jazdy
{
    partial class TeoretycznyA1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelQuestion = new Label();
            radioButtonA = new RadioButton();
            radioButtonB = new RadioButton();
            radioButtonC = new RadioButton();
            buttonNext = new Button();
            labelTime = new Label();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.Location = new Point(13, 13);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(775, 23);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "labelQuestion";
            // 
            // radioButtonA
            // 
            radioButtonA.Location = new Point(16, 50);
            radioButtonA.Name = "radioButtonA";
            radioButtonA.Size = new Size(772, 24);
            radioButtonA.TabIndex = 1;
            radioButtonA.TabStop = true;
            radioButtonA.Text = "radioButtonA";
            radioButtonA.UseVisualStyleBackColor = true;
            // 
            // radioButtonB
            // 
            radioButtonB.Location = new Point(16, 80);
            radioButtonB.Name = "radioButtonB";
            radioButtonB.Size = new Size(772, 24);
            radioButtonB.TabIndex = 2;
            radioButtonB.TabStop = true;
            radioButtonB.Text = "radioButtonB";
            radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonC
            // 
            radioButtonC.Location = new Point(16, 110);
            radioButtonC.Name = "radioButtonC";
            radioButtonC.Size = new Size(772, 24);
            radioButtonC.TabIndex = 3;
            radioButtonC.TabStop = true;
            radioButtonC.Text = "radioButtonC";
            radioButtonC.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(16, 140);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(82, 35);
            buttonNext.TabIndex = 5;
            buttonNext.Text = "Następne";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // labelTime
            // 
            labelTime.Location = new Point(12, 190);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(772, 23);
            labelTime.TabIndex = 6;
            labelTime.Text = "Pozostały czas: 30 sekund";
            labelTime.Click += Timer_Tick;
            // 
            // Teoretyczny
            // 
            ClientSize = new Size(800, 287);
            Controls.Add(labelTime);
            Controls.Add(buttonNext);
            Controls.Add(radioButtonC);
            Controls.Add(radioButtonB);
            Controls.Add(radioButtonA);
            Controls.Add(labelQuestion);
            Name = "Teoretyczny";
            Load += TeoretycznyA1_Load;
            ResumeLayout(false);
        }
    }
}

