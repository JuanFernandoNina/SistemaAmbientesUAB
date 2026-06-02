namespace SistemaAmbientesUAB
{
    partial class FormUsuarios
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTipoFiltro = new System.Windows.Forms.Label();
            this.cmbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnToggleEstado = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Gestión de Usuarios";
            this.Size = new System.Drawing.Size(900, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormUsuarios_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "👥 Gestión de Usuarios";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(350, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── BUSCAR ────────────────────────────────────────
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Location = new System.Drawing.Point(20, 68);
            this.lblBuscar.Size = new System.Drawing.Size(60, 25);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.txtBuscar.Location = new System.Drawing.Point(85, 65);
            this.txtBuscar.Size = new System.Drawing.Size(200, 25);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            // this.txtBuscar.PlaceholderText = "Nombre o código...";

            // ── FILTRO TIPO ───────────────────────────────────
            this.lblTipoFiltro.Text = "Tipo:";
            this.lblTipoFiltro.Location = new System.Drawing.Point(305, 68);
            this.lblTipoFiltro.Size = new System.Drawing.Size(45, 25);
            this.lblTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbTipoFiltro.Location = new System.Drawing.Point(355, 65);
            this.cmbTipoFiltro.Size = new System.Drawing.Size(160, 25);
            this.cmbTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFiltro.Items.AddRange(new object[] {
                "Todos", "docente", "estudiante", "administrativo", "iglesia" });
            this.cmbTipoFiltro.SelectedIndex = 0;

            // ── BOTÓN FILTRAR ─────────────────────────────────
            this.btnFiltrar.Text = "🔍 Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(530, 62);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 35);
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── DATAGRIDVIEW ──────────────────────────────────
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 110);
            this.dgvUsuarios.Size = new System.Drawing.Size(850, 340);
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.RowTemplate.Height = 35;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 255);

            // ── BOTÓN NUEVO ───────────────────────────────────
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(20, 465);
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
            this.btnEditar.Location = new System.Drawing.Point(165, 465);
            this.btnEditar.Size = new System.Drawing.Size(130, 40);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(40, 80, 160);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // ── BOTÓN TOGGLE ESTADO ───────────────────────────
            this.btnToggleEstado.Text = "🔄 Activar/Desactivar";
            this.btnToggleEstado.Location = new System.Drawing.Point(310, 465);
            this.btnToggleEstado.Size = new System.Drawing.Size(200, 40);
            this.btnToggleEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnToggleEstado.BackColor = System.Drawing.Color.FromArgb(160, 100, 0);
            this.btnToggleEstado.ForeColor = System.Drawing.Color.White;
            this.btnToggleEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleEstado.FlatAppearance.BorderSize = 0;
            this.btnToggleEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleEstado.Click += new System.EventHandler(this.btnToggleEstado_Click);

            // ── LABEL MENSAJE ─────────────────────────────────
            this.lblMensaje.Text = "";
            this.lblMensaje.Location = new System.Drawing.Point(530, 475);
            this.lblMensaje.Size = new System.Drawing.Size(340, 25);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTipoFiltro);
            this.Controls.Add(this.cmbTipoFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnToggleEstado);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTipoFiltro;
        private System.Windows.Forms.ComboBox cmbTipoFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnToggleEstado;
        private System.Windows.Forms.Label lblMensaje;
    }
}