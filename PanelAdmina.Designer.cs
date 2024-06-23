namespace prawo_jazdy
{
    partial class PanelAdmina
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnTestTeoretyczny;
        private System.Windows.Forms.Button btnTestPraktyczny;
        private System.Windows.Forms.Button btnDodajUzytkownika;
        private System.Windows.Forms.Button btnUsunUzytkownika;
        private System.Windows.Forms.Button btnZmodyfikujUzytkownika;
        private System.Windows.Forms.Button btnListaUzytkownikow;

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
            btnTestTeoretyczny = new Button();
            btnTestPraktyczny = new Button();
            btnDodajUzytkownika = new Button();
            btnUsunUzytkownika = new Button();
            btnZmodyfikujUzytkownika = new Button();
            btnListaUzytkownikow = new Button();
            SuspendLayout();
            // 
            // btnTestTeoretyczny
            // 
            btnTestTeoretyczny.Location = new Point(324, 103);
            btnTestTeoretyczny.Margin = new Padding(4, 5, 4, 5);
            btnTestTeoretyczny.Name = "btnTestTeoretyczny";
            btnTestTeoretyczny.Size = new Size(200, 46);
            btnTestTeoretyczny.TabIndex = 0;
            btnTestTeoretyczny.Text = "Egzamin teoretyczny";
            btnTestTeoretyczny.UseVisualStyleBackColor = true;
            btnTestTeoretyczny.Click += btnTestTeoretyczny_Click;
            // 
            // btnTestPraktyczny
            // 
            btnTestPraktyczny.Location = new Point(324, 159);
            btnTestPraktyczny.Margin = new Padding(4, 5, 4, 5);
            btnTestPraktyczny.Name = "btnTestPraktyczny";
            btnTestPraktyczny.Size = new Size(200, 46);
            btnTestPraktyczny.TabIndex = 1;
            btnTestPraktyczny.Text = "Egzamin praktyczny";
            btnTestPraktyczny.UseVisualStyleBackColor = true;
            btnTestPraktyczny.Click += btnTestPraktyczny_Click;
            // 
            // btnDodajUzytkownika
            // 
            btnDodajUzytkownika.Location = new Point(324, 215);
            btnDodajUzytkownika.Margin = new Padding(4, 5, 4, 5);
            btnDodajUzytkownika.Name = "btnDodajUzytkownika";
            btnDodajUzytkownika.Size = new Size(200, 46);
            btnDodajUzytkownika.TabIndex = 2;
            btnDodajUzytkownika.Text = "Dodaj użytkownika";
            btnDodajUzytkownika.UseVisualStyleBackColor = true;
            btnDodajUzytkownika.Click += btnDodajUzytkownika_Click;
            // 
            // btnUsunUzytkownika
            // 
            btnUsunUzytkownika.Location = new Point(324, 271);
            btnUsunUzytkownika.Margin = new Padding(4, 5, 4, 5);
            btnUsunUzytkownika.Name = "btnUsunUzytkownika";
            btnUsunUzytkownika.Size = new Size(200, 46);
            btnUsunUzytkownika.TabIndex = 3;
            btnUsunUzytkownika.Text = "Usuń użytkownika";
            btnUsunUzytkownika.UseVisualStyleBackColor = true;
            btnUsunUzytkownika.Click += btnUsunUzytkownika_Click;
            // 
            // btnZmodyfikujUzytkownika
            // 
            btnZmodyfikujUzytkownika.Location = new Point(324, 327);
            btnZmodyfikujUzytkownika.Margin = new Padding(4, 5, 4, 5);
            btnZmodyfikujUzytkownika.Name = "btnZmodyfikujUzytkownika";
            btnZmodyfikujUzytkownika.Size = new Size(200, 46);
            btnZmodyfikujUzytkownika.TabIndex = 4;
            btnZmodyfikujUzytkownika.Text = "Zmodyfikuj użytkownika";
            btnZmodyfikujUzytkownika.UseVisualStyleBackColor = true;
            btnZmodyfikujUzytkownika.Click += btnZmodyfikujUzytkownika_Click;
            // 
            // btnListaUzytkownikow
            // 
            btnListaUzytkownikow.Location = new Point(324, 383);
            btnListaUzytkownikow.Margin = new Padding(4, 5, 4, 5);
            btnListaUzytkownikow.Name = "btnListaUzytkownikow";
            btnListaUzytkownikow.Size = new Size(200, 46);
            btnListaUzytkownikow.TabIndex = 5;
            btnListaUzytkownikow.Text = "Lista użytkowników";
            btnListaUzytkownikow.UseVisualStyleBackColor = true;
            btnListaUzytkownikow.Click += btnListaUzytkownikow_Click;
            // 
            // PanelAdmina
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 545);
            Controls.Add(btnListaUzytkownikow);
            Controls.Add(btnZmodyfikujUzytkownika);
            Controls.Add(btnUsunUzytkownika);
            Controls.Add(btnDodajUzytkownika);
            Controls.Add(btnTestPraktyczny);
            Controls.Add(btnTestTeoretyczny);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PanelAdmina";
            Text = "Panel Admina";
            Load += PanelAdmina_Load;
            ResumeLayout(false);
        }
    }
}
