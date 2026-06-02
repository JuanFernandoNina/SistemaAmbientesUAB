namespace SistemaAmbientesUAB
{
    partial class FormAmbientes
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
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            this.lblBloque = new System.Windows.Forms.Label();
            this.cmbBloque = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Gestión de Ambientes";
            this.Size = new System.Drawing.Size(900, 580);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormAmbientes_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "🏫 Gestión de Ambientes";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(350, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── FILTRO BLOQUE ─────────────────────────────────
            this.lblBloque.Text = "Bloque:";
            this.lblBloque.Location = new System.Drawing.Point(20, 68);
            this.lblBloque.Size = new System.Drawing.Size(60, 25);
            this.lblBloque.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbBloque.Location = new System.Drawing.Point(85, 65);
            this.cmbBloque.Size = new System.Drawing.Size(130, 25);
            this.cmbBloque.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ── FILTRO TIPO ───────────────────────────────────
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new System.Drawing.Point(235, 68);
            this.lblTipo.Size = new System.Drawing.Size(45, 25);
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbTipo.Location = new System.Drawing.Point(285, 65);
            this.cmbTipo.Size = new System.Drawing.Size(150, 25);
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "Todos", "aula", "laboratorio", "auditorio", "coliseo" });
            this.cmbTipo.SelectedIndex = 0;

            // ── BOTÓN FILTRAR ─────────────────────────────────
            this.btnFiltrar.Text = "🔍 Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(450, 62);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 35);
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── DATAGRIDVIEW ──────────────────────────────────
            this.dgvAmbientes.Location = new System.Drawing.Point(20, 110);
            this.dgvAmbientes.Size = new System.Drawing.Size(850, 360);
            this.dgvAmbientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvAmbientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAmbientes.RowHeadersVisible = false;
            this.dgvAmbientes.AllowUserToAddRows = false;
            this.dgvAmbientes.AllowUserToDeleteRows = false;
            this.dgvAmbientes.ReadOnly = true;
            this.dgvAmbientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmbientes.MultiSelect = false;
            this.dgvAmbientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAmbientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvAmbientes.EnableHeadersVisualStyles = false;
            this.dgvAmbientes.RowTemplate.Height = 35;
            this.dgvAmbientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 255);

            // ── BOTÓN NUEVO ───────────────────────────────────
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(20, 485);
            this.btnNuevo.Size = new System.Drawing.Size(130, 40);
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(40, 120, 40);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // ── BOTÓN EDITAR ──────────────────────────────────
            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.Location = new System.Drawing.Point(165, 485);
            this.btnEditar.Size = new System.Drawing.Size(130, 40);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(40, 80, 160);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // ── BOTÓN CAMBIAR ESTADO ──────────────────────────
            this.btnCambiarEstado.Text = "🔄 Cambiar Estado";
            this.btnCambiarEstado.Location = new System.Drawing.Point(310, 485);
            this.btnCambiarEstado.Size = new System.Drawing.Size(180, 40);
            this.btnCambiarEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCambiarEstado.BackColor = System.Drawing.Color.FromArgb(160, 100, 0);
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.FlatAppearance.BorderSize = 0;
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            // ── LABEL MENSAJE ─────────────────────────────────
            this.lblMensaje.Text = "";
            this.lblMensaje.Location = new System.Drawing.Point(510, 495);
            this.lblMensaje.Size = new System.Drawing.Size(360, 25);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBloque);
            this.Controls.Add(this.cmbBloque);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvAmbientes);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBloque;
        private System.Windows.Forms.ComboBox cmbBloque;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Label lblMensaje;
    }
}