namespace SistemaAmbientesUAB
{
    partial class FormAmbienteDetalle
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
            this.lblBloque = new System.Windows.Forms.Label();
            this.cmbBloque = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.nudCapacidad = new System.Windows.Forms.NumericUpDown();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkProyector = new System.Windows.Forms.CheckBox();
            this.chkComputadoras = new System.Windows.Forms.CheckBox();
            this.chkEnchufes = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).BeginInit();
            this.SuspendLayout();

            this.Text = "Ambiente";
            this.Size = new System.Drawing.Size(480, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormAmbienteDetalle_Load);

            this.lblTitulo.Text = "➕ Ambiente";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(300, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // Código
            this.lblCodigo.Text = "Código:"; this.lblCodigo.Location = new System.Drawing.Point(20, 70);
            this.lblCodigo.Size = new System.Drawing.Size(80, 25); this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(130, 67); this.txtCodigo.Size = new System.Drawing.Size(300, 25);
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Bloque
            this.lblBloque.Text = "Bloque:"; this.lblBloque.Location = new System.Drawing.Point(20, 110);
            this.lblBloque.Size = new System.Drawing.Size(80, 25); this.lblBloque.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBloque.Location = new System.Drawing.Point(130, 107); this.cmbBloque.Size = new System.Drawing.Size(150, 25);
            this.cmbBloque.Font = new System.Drawing.Font("Segoe UI", 10F); this.cmbBloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Tipo
            this.lblTipo.Text = "Tipo:"; this.lblTipo.Location = new System.Drawing.Point(20, 150);
            this.lblTipo.Size = new System.Drawing.Size(80, 25); this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.Location = new System.Drawing.Point(130, 147); this.cmbTipo.Size = new System.Drawing.Size(150, 25);
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F); this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "aula", "laboratorio", "auditorio", "coliseo" });
            this.cmbTipo.SelectedIndex = 0;

            // Capacidad
            this.lblCapacidad.Text = "Capacidad:"; this.lblCapacidad.Location = new System.Drawing.Point(20, 190);
            this.lblCapacidad.Size = new System.Drawing.Size(90, 25); this.lblCapacidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCapacidad.Location = new System.Drawing.Point(130, 188); this.nudCapacidad.Size = new System.Drawing.Size(100, 25);
            this.nudCapacidad.Font = new System.Drawing.Font("Segoe UI", 10F); this.nudCapacidad.Minimum = 1; this.nudCapacidad.Maximum = 1000;

            // Estado
            this.lblEstado.Text = "Estado:"; this.lblEstado.Location = new System.Drawing.Point(20, 230);
            this.lblEstado.Size = new System.Drawing.Size(80, 25); this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.Location = new System.Drawing.Point(130, 227); this.cmbEstado.Size = new System.Drawing.Size(150, 25);
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F); this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] { "disponible", "mantenimiento", "inhabilitado" });
            this.cmbEstado.SelectedIndex = 0;

            // Checkboxes
            this.chkProyector.Text = "Tiene Proyector"; this.chkProyector.Location = new System.Drawing.Point(20, 275);
            this.chkProyector.Size = new System.Drawing.Size(150, 25); this.chkProyector.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkComputadoras.Text = "Tiene Computadoras"; this.chkComputadoras.Location = new System.Drawing.Point(180, 275);
            this.chkComputadoras.Size = new System.Drawing.Size(170, 25); this.chkComputadoras.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkEnchufes.Text = "Tiene Enchufes"; this.chkEnchufes.Location = new System.Drawing.Point(20, 310);
            this.chkEnchufes.Size = new System.Drawing.Size(150, 25); this.chkEnchufes.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Botones
            this.btnGuardar.Text = "💾 Guardar"; this.btnGuardar.Location = new System.Drawing.Point(130, 345);
            this.btnGuardar.Size = new System.Drawing.Size(140, 40); this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(40, 120, 40); this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "✖ Cancelar"; this.btnCancelar.Location = new System.Drawing.Point(290, 345);
            this.btnCancelar.Size = new System.Drawing.Size(140, 40); this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40); this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblCodigo); this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblBloque); this.Controls.Add(this.cmbBloque); this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo); this.Controls.Add(this.lblCapacidad); this.Controls.Add(this.nudCapacidad);
            this.Controls.Add(this.lblEstado); this.Controls.Add(this.cmbEstado); this.Controls.Add(this.chkProyector);
            this.Controls.Add(this.chkComputadoras); this.Controls.Add(this.chkEnchufes);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);

            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblBloque;
        private System.Windows.Forms.ComboBox cmbBloque;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.NumericUpDown nudCapacidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkProyector;
        private System.Windows.Forms.CheckBox chkComputadoras;
        private System.Windows.Forms.CheckBox chkEnchufes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}