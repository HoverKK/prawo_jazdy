namespace prawo_jazdy
{
    partial class UsunUzytkownika
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnUsun;

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
            txtUserId = new TextBox();
            lblUserId = new Label();
            btnUsun = new Button();
            SuspendLayout();
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(214, 191);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(200, 27);
            txtUserId.TabIndex = 0;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(83, 194);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(112, 20);
            lblUserId.TabIndex = 1;
            lblUserId.Text = "ID użytkownika:";
            // 
            // btnUsun
            // 
            btnUsun.Location = new Point(214, 263);
            btnUsun.Name = "btnUsun";
            btnUsun.Size = new Size(200, 54);
            btnUsun.TabIndex = 2;
            btnUsun.Text = "Usuń użytkownika";
            btnUsun.UseVisualStyleBackColor = true;
            btnUsun.Click += btnUsun_Click;
            // 
            // UsunUzytkownika
            // 
            ClientSize = new Size(650, 482);
            Controls.Add(btnUsun);
            Controls.Add(lblUserId);
            Controls.Add(txtUserId);
            Name = "UsunUzytkownika";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
