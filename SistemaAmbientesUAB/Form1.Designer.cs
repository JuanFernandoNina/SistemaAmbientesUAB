namespace SistemaAmbientesUAB
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "Sistema de Ambientes UAB";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(56, 39);
            this.lblTitulo.Size = new System.Drawing.Size(350, 35);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;

            // lblUsuario
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(56, 116);
            this.lblUsuario.Size = new System.Drawing.Size(120, 25);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 1;

            // txtUsuario
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(204, 113);
            this.txtUsuario.Size = new System.Drawing.Size(295, 31);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.TabIndex = 2;

            // lblPassword
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPassword.Location = new System.Drawing.Point(56, 170);
            this.lblPassword.Size = new System.Drawing.Size(130, 25);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 3;

            // txtPassword
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(204, 167);
            this.txtPassword.Size = new System.Drawing.Size(295, 31);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 4;

            // btnIngresar
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnIngresar.Location = new System.Drawing.Point(204, 230);
            this.btnIngresar.Size = new System.Drawing.Size(180, 45);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Form1";
            this.Text = "Login - AmbientesUAB";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnIngresar;
    }
}