namespace SistemaAmbientesUAB
{
    partial class FormMisReservas
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
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────
            this.Text = "Mis Reservas";
            this.Size = new System.Drawing.Size(860, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormMisReservas_Load);

            // ── TÍTULO ───────────────────────────────────────
            this.lblTitulo.Text = "📅 Mis Reservas";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(300, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── FILTRO ESTADO ────────────────────────────────
            this.lblFiltro.Text = "Filtrar por estado:";
            this.lblFiltro.Location = new System.Drawing.Point(20, 65);
            this.lblFiltro.Size = new System.Drawing.Size(130, 25);
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbFiltroEstado.Location = new System.Drawing.Point(155, 62);
            this.cmbFiltroEstado.Size = new System.Drawing.Size(150, 25);
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] { "Todas", "activa", "cancelada", "finalizada" });
            this.cmbFiltroEstado.SelectedIndex = 0;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);

            // ── DATAGRIDVIEW ─────────────────────────────────
            this.dgvReservas.Location = new System.Drawing.Point(20, 100);
            this.dgvReservas.Size = new System.Drawing.Size(820, 330);
            this.dgvReservas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReservas.EnableHeadersVisualStyles = false;
            this.dgvReservas.RowTemplate.Height = 35;
            this.dgvReservas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 255);

            // ── BOTÓN CANCELAR RESERVA ───────────────────────
            this.btnCancelar.Text = "❌  Cancelar Reserva";
            this.btnCancelar.Location = new System.Drawing.Point(20, 445);
            this.btnCancelar.Size = new System.Drawing.Size(200, 40);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── BOTÓN ACTUALIZAR ─────────────────────────────
            this.btnActualizar.Text = "🔄  Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(640, 445);
            this.btnActualizar.Size = new System.Drawing.Size(200, 40);
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // ── LABEL ESTADO (mensajes) ──────────────────────
            this.lblEstado.Text = "";
            this.lblEstado.Location = new System.Drawing.Point(240, 455);
            this.lblEstado.Size = new System.Drawing.Size(380, 25);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblEstado);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
    }
}