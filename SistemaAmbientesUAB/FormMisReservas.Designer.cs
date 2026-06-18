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
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.panelBuscar.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();

            // FORM BASE
            this.Text = "Mis Reservas";
            this.Size = new System.Drawing.Size(1120, 650);
            this.MinimumSize = new System.Drawing.Size(1040, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormMisReservas_Load);
            this.Resize += new System.EventHandler(this.FormMisReservas_Resize);

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "Mis reservas";
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);

            // LÍNEA DIVISORIA INSTITUCIONAL
            this.lblLinea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinea.BackColor = System.Drawing.Color.FromArgb(231, 236, 243);
            this.lblLinea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblLinea.Location = new System.Drawing.Point(0, 58);
            this.lblLinea.Size = new System.Drawing.Size(1124, 1);

            int yBarra = 78;
            int hBarra = 32;

            // PANEL BUSCADOR
            this.panelBuscar.Location = new System.Drawing.Point(20, yBarra);
            this.panelBuscar.Size = new System.Drawing.Size(200, hBarra);
            this.panelBuscar.BackColor = System.Drawing.Color.White;

            this.lblIconoBuscar.Text = "🔍";
            this.lblIconoBuscar.Location = new System.Drawing.Point(6, 4);
            this.lblIconoBuscar.Size = new System.Drawing.Size(20, 22);
            this.lblIconoBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIconoBuscar.ForeColor = System.Drawing.Color.FromArgb(165, 176, 196);
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBuscar.Location = new System.Drawing.Point(28, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(164, 22);
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

            // BOTÓN: CANCELAR RESERVA (Ocre) - Reubicado a la izquierda
            this.btnCancelarReserva.Location = new System.Drawing.Point(232, yBarra);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(110, hBarra);
            this.btnCancelarReserva.Text = "Cancelar";
            this.btnCancelarReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnCancelarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarReserva.FlatAppearance.BorderSize = 0;
            this.btnCancelarReserva.BackColor = System.Drawing.Color.FromArgb(161, 110, 13);
            this.btnCancelarReserva.ForeColor = System.Drawing.Color.White;
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);

            // BOTÓN: ELIMINAR (Rojo Sólido) - Reubicado al lado de Cancelar
            this.btnEliminar.Location = new System.Drawing.Point(352, yBarra);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, hBarra);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(186, 31, 37);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ETIQUETA ESTADO FILTRO
            this.lblFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltro.Text = "Estado";
            this.lblFiltro.Location = new System.Drawing.Point(745, yBarra + 6);
            this.lblFiltro.Size = new System.Drawing.Size(50, 20);
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(87, 101, 126);

            // COMBOBOX FILTRO ESTADO
            this.cmbFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] { "Todas", "activa", "cancelada", "finalizada" });
            this.cmbFiltroEstado.Location = new System.Drawing.Point(800, yBarra);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 25);
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltroEstado.SelectedIndex = 0;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);

            // BOTÓN: ACTUALIZAR
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Location = new System.Drawing.Point(942, yBarra);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(140, hBarra);
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(39, 85, 166);
            this.btnActualizar.FlatAppearance.BorderSize = 1;
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(39, 85, 166);
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // PANEL CONTENEDOR DE LA TABLA
            this.panelTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabla.BackColor = System.Drawing.Color.White;
            this.panelTabla.Location = new System.Drawing.Point(20, 130);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(1062, 400);

            // CONFIGURACIÓN INTERNA DE DATA GRID VIEW
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
            this.dgvReservas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReservas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReservas.ColumnHeadersHeight = 40;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservas.RowTemplate.Height = 38;

            this.dgvReservas.SelectionChanged += new System.EventHandler(this.dgvReservas_SelectionChanged);
            this.dgvReservas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvReservas_CellPainting);

            this.panelTabla.Controls.Add(this.dgvReservas);

            // PANEL ACCIONES INFERIORES / PAGINACIÓN
            this.panelAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAcciones.BackColor = System.Drawing.Color.Transparent;
            this.panelAcciones.Location = new System.Drawing.Point(20, 545);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(1062, 45);

            this.lblEstado.Text = "Mostrando 0 reservas";
            this.lblEstado.Location = new System.Drawing.Point(0, 10);
            this.lblEstado.Size = new System.Drawing.Size(350, 24);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(139, 152, 176);

            // BOTONES PAGINACIÓN
            this.btnAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnterior.Text = "‹";
            this.btnAnterior.Size = new System.Drawing.Size(34, 32);
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 224, 233);
            this.btnAnterior.BackColor = System.Drawing.Color.White;
            this.btnAnterior.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);

            this.btnPagina1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina1.Text = "1";
            this.btnPagina1.Size = new System.Drawing.Size(34, 32);
            this.btnPagina1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 224, 233);
            this.btnPagina1.BackColor = System.Drawing.Color.White;
            this.btnPagina1.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);
            this.btnPagina1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina1.UseVisualStyleBackColor = false;
            this.btnPagina1.Click += new System.EventHandler(this.btnPagina_Click);

            this.btnPagina2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina2.Text = "2";
            this.btnPagina2.Size = new System.Drawing.Size(34, 32);
            this.btnPagina2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 224, 233);
            this.btnPagina2.BackColor = System.Drawing.Color.White;
            this.btnPagina2.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);
            this.btnPagina2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina2.UseVisualStyleBackColor = false;
            this.btnPagina2.Click += new System.EventHandler(this.btnPagina_Click);

            this.btnPagina3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagina3.Text = "3";
            this.btnPagina3.Size = new System.Drawing.Size(34, 32);
            this.btnPagina3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 224, 233);
            this.btnPagina3.BackColor = System.Drawing.Color.White;
            this.btnPagina3.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);
            this.btnPagina3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina3.UseVisualStyleBackColor = false;
            this.btnPagina3.Click += new System.EventHandler(this.btnPagina_Click);

            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.Text = "›";
            this.btnSiguiente.Size = new System.Drawing.Size(34, 32);
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 224, 233);
            this.btnSiguiente.BackColor = System.Drawing.Color.White;
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(28, 37, 58);
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            this.panelAcciones.Controls.Add(this.lblEstado);
            this.panelAcciones.Controls.Add(this.btnAnterior);
            this.panelAcciones.Controls.Add(this.btnPagina1);
            this.panelAcciones.Controls.Add(this.btnPagina2);
            this.panelAcciones.Controls.Add(this.btnPagina3);
            this.panelAcciones.Controls.Add(this.btnSiguiente);

            // AGREGAR CONTROLES AL FORM
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.panelBuscar);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnEliminar);
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
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnEliminar;
    }
}