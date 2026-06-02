namespace SistemaAmbientesUAB
{
    partial class FormUsuarioDetalle
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.Text = "Usuario";
            this.Size = new System.Drawing.Size(500, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormUsuarioDetalle_Load);

            // Título
            this.lblTitulo.Text = "➕ Usuario"; this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(300, 35); this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // Código
            this.lblCodigo.Text = "Código:"; this.lblCodigo.Location = new System.Drawing.Point(20, 65); this.lblCodigo.Size = new System.Drawing.Size(90, 25); this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(130, 62); this.txtCodigo.Size = new System.Drawing.Size(330, 25); this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Nombre
            this.lblNombre.Text = "Nombre:"; this.lblNombre.Location = new System.Drawing.Point(20, 100); this.lblNombre.Size = new System.Drawing.Size(90, 25); this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(130, 97); this.txtNombre.Size = new System.Drawing.Size(330, 25); this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Tipo
            this.lblTipo.Text = "Tipo:"; this.lblTipo.Location = new System.Drawing.Point(20, 135); this.lblTipo.Size = new System.Drawing.Size(90, 25); this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.Location = new System.Drawing.Point(130, 132); this.cmbTipo.Size = new System.Drawing.Size(180, 25); this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "docente", "estudiante", "administrativo", "iglesia" });
            this.cmbTipo.SelectedIndex = 0;

            // Carrera
            this.lblCarrera.Text = "Carrera:"; this.lblCarrera.Location = new System.Drawing.Point(20, 170); this.lblCarrera.Size = new System.Drawing.Size(90, 25); this.lblCarrera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCarrera.Location = new System.Drawing.Point(130, 167); this.txtCarrera.Size = new System.Drawing.Size(330, 25); this.txtCarrera.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Correo
            this.lblCorreo.Text = "Correo:"; this.lblCorreo.Location = new System.Drawing.Point(20, 205); this.lblCorreo.Size = new System.Drawing.Size(90, 25); this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCorreo.Location = new System.Drawing.Point(130, 202); this.txtCorreo.Size = new System.Drawing.Size(330, 25); this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Teléfono
            this.lblTelefono.Text = "Teléfono:"; this.lblTelefono.Location = new System.Drawing.Point(20, 240); this.lblTelefono.Size = new System.Drawing.Size(90, 25); this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(130, 237); this.txtTelefono.Size = new System.Drawing.Size(180, 25); this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Username
            this.lblUsername.Text = "Usuario:"; this.lblUsername.Location = new System.Drawing.Point(20, 275); this.lblUsername.Size = new System.Drawing.Size(90, 25); this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(130, 272); this.txtUsername.Size = new System.Drawing.Size(180, 25); this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Password
            this.lblPassword.Text = "Contraseña:"; this.lblPassword.Location = new System.Drawing.Point(20, 310); this.lblPassword.Size = new System.Drawing.Size(90, 25); this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(130, 307); this.txtPassword.Size = new System.Drawing.Size(180, 25); this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Estado
            this.lblEstado.Text = "Estado:"; this.lblEstado.Location = new System.Drawing.Point(20, 345); this.lblEstado.Size = new System.Drawing.Size(90, 25); this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.Location = new System.Drawing.Point(130, 342); this.cmbEstado.Size = new System.Drawing.Size(150, 25); this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] { "activo", "inactivo" });
            this.cmbEstado.SelectedIndex = 0;

            // Admin
            this.chkAdmin.Text = "Es Administrador"; this.chkAdmin.Location = new System.Drawing.Point(130, 380);
            this.chkAdmin.Size = new System.Drawing.Size(180, 25); this.chkAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Botones
            this.btnGuardar.Text = "💾 Guardar"; this.btnGuardar.Location = new System.Drawing.Point(130, 420);
            this.btnGuardar.Size = new System.Drawing.Size(140, 40); this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(40, 120, 40); this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "✖ Cancelar"; this.btnCancelar.Location = new System.Drawing.Point(285, 420);
            this.btnCancelar.Size = new System.Drawing.Size(140, 40); this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40); this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblCodigo); this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombre); this.Controls.Add(this.txtNombre); this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo); this.Controls.Add(this.lblCarrera); this.Controls.Add(this.txtCarrera);
            this.Controls.Add(this.lblCorreo); this.Controls.Add(this.txtCorreo); this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono); this.Controls.Add(this.lblUsername); this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword); this.Controls.Add(this.txtPassword); this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado); this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}