namespace SistemaAmbientesUAB
{
    partial class FormLogin
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            // ── Roles badge strip ──
            this.pnlRoles = new System.Windows.Forms.Panel();
            this.lblRol1 = new System.Windows.Forms.Label();
            this.lblRol2 = new System.Windows.Forms.Label();
            this.lblRol3 = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.pnlRoles.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════
            //  FORM
            // ═══════════════════════════════════════════════════
            this.Text = "Iniciar Sesión — Sistema de Ambientes UAB";
            this.Size = new System.Drawing.Size(480, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = TemaManager.FondoPrincipal;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormLogin_Load);

            // ═══════════════════════════════════════════════════
            //  CARD CENTRAL
            // ═══════════════════════════════════════════════════
            this.pnlCard.Location = new System.Drawing.Point(40, 48);
            this.pnlCard.Size = new System.Drawing.Size(392, 490);
            this.pnlCard.BackColor = TemaManager.FondoTarjeta;

            // ── Logo / nombre app ──
            this.lblAppName.Text = "Sistema de Ambientes";
            this.lblAppName.Location = new System.Drawing.Point(24, 28);
            this.lblAppName.Size = new System.Drawing.Size(344, 32);
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = TemaManager.TextoPrincipal;
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitulo.Text = "Universidad Adventista de Bolivia";
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 62);
            this.lblSubtitulo.Size = new System.Drawing.Size(344, 20);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = TemaManager.TextoSecundario;
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Badges de roles ──
            this.pnlRoles.Location = new System.Drawing.Point(24, 92);
            this.pnlRoles.Size = new System.Drawing.Size(344, 30);
            this.pnlRoles.BackColor = System.Drawing.Color.Transparent;

            // Badge Estudiante
            this.lblRol1.Text = "Estudiante";
            this.lblRol1.Location = new System.Drawing.Point(0, 4);
            this.lblRol1.Size = new System.Drawing.Size(84, 22);
            this.lblRol1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRol1.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblRol1.BackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.lblRol1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Badge Docente
            this.lblRol2.Text = "Docente";
            this.lblRol2.Location = new System.Drawing.Point(94, 4);
            this.lblRol2.Size = new System.Drawing.Size(74, 22);
            this.lblRol2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRol2.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            this.lblRol2.BackColor = System.Drawing.Color.FromArgb(209, 250, 229);
            this.lblRol2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Badge Iglesia
            this.lblRol3.Text = "Iglesia";
            this.lblRol3.Location = new System.Drawing.Point(178, 4);
            this.lblRol3.Size = new System.Drawing.Size(68, 22);
            this.lblRol3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRol3.ForeColor = System.Drawing.Color.FromArgb(92, 45, 145);
            this.lblRol3.BackColor = System.Drawing.Color.FromArgb(237, 233, 254);
            this.lblRol3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlRoles.Controls.Add(this.lblRol1);
            this.pnlRoles.Controls.Add(this.lblRol2);
            this.pnlRoles.Controls.Add(this.lblRol3);

            // ── Divisor ──
            this.pnlDivider.Location = new System.Drawing.Point(24, 136);
            this.pnlDivider.Size = new System.Drawing.Size(344, 1);
            this.pnlDivider.BackColor = TemaManager.FondoTarjeta2;

            // ── Label + TextBox Usuario ──
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Location = new System.Drawing.Point(24, 152);
            this.lblUsuario.Size = new System.Drawing.Size(344, 18);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUsuario.ForeColor = TemaManager.TextoSecundario;

            this.txtUsuario.Location = new System.Drawing.Point(24, 174);
            this.txtUsuario.Size = new System.Drawing.Size(344, 34);
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.BackColor = TemaManager.FondoGrid;
            this.txtUsuario.ForeColor = TemaManager.TextoPrincipal;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);

            // ── Label + TextBox Contraseña ──
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.Location = new System.Drawing.Point(24, 222);
            this.lblPassword.Size = new System.Drawing.Size(344, 18);
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPassword.ForeColor = TemaManager.TextoSecundario;

            this.txtPassword.Location = new System.Drawing.Point(24, 244);
            this.txtPassword.Size = new System.Drawing.Size(344, 34);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.BackColor = TemaManager.FondoGrid;
            this.txtPassword.ForeColor = TemaManager.TextoPrincipal;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // ── Label error ──
            this.lblError.Text = "";
            this.lblError.Location = new System.Drawing.Point(24, 288);
            this.lblError.Size = new System.Drawing.Size(344, 20);
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = TemaManager.Peligro;
            this.lblError.Visible = false;

            // ── Botón Ingresar ──
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Location = new System.Drawing.Point(24, 318);
            this.btnIngresar.Size = new System.Drawing.Size(344, 42);
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.BackColor = TemaManager.Acento;
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // ── Versión / footer ──
            this.lblVersion.Text = "v1.0  ·  UAB Sistemas";
            this.lblVersion.Location = new System.Drawing.Point(24, 450);
            this.lblVersion.Size = new System.Drawing.Size(344, 18);
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblVersion.ForeColor = TemaManager.TextoMuted;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Agregar a pnlCard ──
            this.pnlCard.Controls.Add(this.lblAppName);
            this.pnlCard.Controls.Add(this.lblSubtitulo);
            this.pnlCard.Controls.Add(this.pnlRoles);
            this.pnlCard.Controls.Add(this.pnlDivider);
            this.pnlCard.Controls.Add(this.lblUsuario);
            this.pnlCard.Controls.Add(this.txtUsuario);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnIngresar);
            this.pnlCard.Controls.Add(this.lblVersion);

            // ── Agregar al form ──
            this.Controls.Add(this.pnlCard);

            this.pnlCard.ResumeLayout(false);
            this.pnlRoles.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlRoles;
        private System.Windows.Forms.Label lblRol1;
        private System.Windows.Forms.Label lblRol2;
        private System.Windows.Forms.Label lblRol3;
    }
}