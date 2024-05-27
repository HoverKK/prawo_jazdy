namespace prawo_jazdy
{
    partial class Wynik
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelResult;

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
            labelResult = new Label();
            SuspendLayout();
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(12, 9);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 0;
            labelResult.Text = "label1";
            // 
            // Wynik
            // 
            ClientSize = new Size(685, 443);
            Controls.Add(labelResult);
            Name = "Wynik";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}