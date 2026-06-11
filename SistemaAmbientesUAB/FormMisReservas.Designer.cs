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
            this.lblLinea = new System.Windows.Forms.Label();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPagina1 = new System.Windows.Forms.Button();
            this.btnPagina2 = new System.Windows.Forms.Button();
            this.btnPagina3 = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.panelBuscar.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.Text = "Mis Reservas";
            this.Size = new System.Drawing.Size(900, 560);
            this.MinimumSize = new System.Drawing.Size(720, 460);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormMisReservas_Load);
            this.Resize += new System.EventHandler(this.FormMisReservas_Resize);

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "Mis reservas";
            this.lblTitulo.Location = new System.Drawing.Point(13, 14);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);

            this.lblLinea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinea.BackColor = System.Drawing.Color.FromArgb(231, 236, 243);
            this.lblLinea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblLinea.Location = new System.Drawing.Point(0, 50);
            this.lblLinea.Size = new System.Drawing.Size(884, 1);

            // BUSCADOR (panel con icono + textbox, bordeado y redondeado)
            this.panelBuscar.Location = new System.Drawing.Point(13, 68);
            this.panelBuscar.Size = new System.Drawing.Size(260, 32);
            this.panelBuscar.BackColor = System.Drawing.Color.White;

            this.lblIconoBuscar.Text = "??";
            this.lblIconoBuscar.Location = new System.Drawing.Point(10, 5);
            this.lblIconoBuscar.Size = new System.Drawing.Size(20, 22);
            this.lblIconoBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIconoBuscar.ForeColor = System.Drawing.Color.FromArgb(165, 176, 196);
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBuscar.Location = new System.Drawing.Point(34, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(216, 22);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(150, 161, 184);
            this.txtBuscar.Text = "Buscar reserva...";
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.panelBuscar.Controls.Add(this.lblIconoBuscar);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBuscar_Paint);

            // FILTRO ESTADO
            this.lblFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltro.Text = "Estado";
            this.lblFiltro.Location = new System.Drawing.Point(574, 76);
            this.lblFiltro.Size = new System.Drawing.Size(52, 21);
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(87, 101, 126);

            this.cmbFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] { "Todas", "activa", "cancelada", "finalizada" });
            this.cmbFiltroEstado.Location = new System.Drawing.Point(632, 73);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(140, 24);
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroEstado.SelectedIndex = 0;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);

            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(782, 71);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 28);
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(221, 228, 238);
            this.btnActualizar.FlatAppearance.BorderSize = 1;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // TABLA
            this.panelTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabla.BackColor = System.Drawing.Color.White;
            this.panelTabla.Location = new System.Drawing.Point(13, 114);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(859, 314);

            this.dgvReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.AllowUserToResizeRows = false;
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.TabStop = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvReservas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReservas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReservas.ColumnHeadersHeight = 46;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservas.EnableHeadersVisualStyles = false;
            this.dgvReservas.GridColor = System.Drawing.Color.FromArgb(230, 235, 243);
            this.dgvReservas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvReservas.RowTemplate.Height = 44;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            this.dgvReservas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReservas_CellMouseMove);
            this.dgvReservas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvReservas_CellPainting);

            this.panelTabla.Controls.Add(this.dgvReservas);

            // ACCIONES / PAGINACION
            this.panelAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAcciones.BackColor = System.Drawing.Color.Transparent;
            this.panelAcciones.Location = new System.Drawing.Point(13, 446);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(859, 48);

            this.lblEstado.Text = "Showing 0 reservas";
            this.lblEstado.Location = new System.Drawing.Point(0, 12);
            this.lblEstado.Size = new System.Drawing.Size(330, 24);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(139, 152, 176);

            // Botones de paginación redondeados (pintura custom vía Paint)
            this.btnAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnterior.Text = "‹";
            this.btnAnterior.Location = new System.Drawing.Point(665, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(34, 32);
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            this.btnAnterior.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPaginacion_Paint);

            this.btnPagina1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina1.Text = "1";
            this.btnPagina1.Location = new System.Drawing.Point(705, 4);
            this.btnPagina1.Name = "btnPagina1";
            this.btnPagina1.Size = new System.Drawing.Size(34, 32);
            this.btnPagina1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina1.FlatAppearance.BorderSize = 0;
            this.btnPagina1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagina1.Click += new System.EventHandler(this.btnPagina_Click);
            this.btnPagina1.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPaginacion_Paint);

            this.btnPagina2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina2.Text = "2";
            this.btnPagina2.Location = new System.Drawing.Point(745, 4);
            this.btnPagina2.Name = "btnPagina2";
            this.btnPagina2.Size = new System.Drawing.Size(34, 32);
            this.btnPagina2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina2.FlatAppearance.BorderSize = 0;
            this.btnPagina2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagina2.Click += new System.EventHandler(this.btnPagina_Click);
            this.btnPagina2.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPaginacion_Paint);

            this.btnPagina3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina3.Text = "3";
            this.btnPagina3.Location = new System.Drawing.Point(785, 4);
            this.btnPagina3.Name = "btnPagina3";
            this.btnPagina3.Size = new System.Drawing.Size(34, 32);
            this.btnPagina3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina3.FlatAppearance.BorderSize = 0;
            this.btnPagina3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagina3.Click += new System.EventHandler(this.btnPagina_Click);
            this.btnPagina3.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPaginacion_Paint);

            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.Text = "›";
            this.btnSiguiente.Location = new System.Drawing.Point(825, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(34, 32);
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            this.btnSiguiente.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPaginacion_Paint);

            this.panelAcciones.Controls.Add(this.lblEstado);
            this.panelAcciones.Controls.Add(this.btnAnterior);
            this.panelAcciones.Controls.Add(this.btnPagina1);
            this.panelAcciones.Controls.Add(this.btnPagina2);
            this.panelAcciones.Controls.Add(this.btnPagina3);
            this.panelAcciones.Controls.Add(this.btnSiguiente);

            // CONTROLES
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.panelBuscar);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelAcciones);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            this.panelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.Label lblIconoBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPagina1;
        private System.Windows.Forms.Button btnPagina2;
        private System.Windows.Forms.Button btnPagina3;
        private System.Windows.Forms.Button btnSiguiente;
    }
}