namespace SistemaAmbientesUAB
{
    partial class FormNuevaReserva
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
            // ── Panel "En nombre de" (solo admin) ─────────────
            this.pnlEnNombreDe = new System.Windows.Forms.Panel();
            this.lblEnNombreDeIcon = new System.Windows.Forms.Label();
            this.lblEnNombreDe = new System.Windows.Forms.Label();
            this.cmbUsuarioBeneficiario = new System.Windows.Forms.ComboBox();
            // ── Panel filtros ──────────────────────────────────
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblSecFiltros = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.cmbHoraFin = new System.Windows.Forms.ComboBox();
            this.lblAsistentes = new System.Windows.Forms.Label();
            this.nudAsistentes = new System.Windows.Forms.NumericUpDown();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblReqTitle = new System.Windows.Forms.Label();
            this.chkProyector = new System.Windows.Forms.CheckBox();
            this.chkComputadoras = new System.Windows.Forms.CheckBox();
            this.chkEnchufes = new System.Windows.Forms.CheckBox();
            this.lblRecurrente = new System.Windows.Forms.Label();
            this.chkRecurrente = new System.Windows.Forms.CheckBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.cmbFrecuencia = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            // ── Panel grid ────────────────────────────────────
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblSecGrid = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            // ── Panel acciones ────────────────────────────────
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).BeginInit();
            this.pnlEnNombreDe.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════
            //  FORM
            // ═══════════════════════════════════════════════════
            this.Text = "Nueva Reserva";
            this.Size = new System.Drawing.Size(960, 760);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = TemaManager.FondoPrincipal;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormNuevaReserva_Load);
            this.Padding = new System.Windows.Forms.Padding(20);

            // ═══════════════════════════════════════════════════
            //  TÍTULO
            // ═══════════════════════════════════════════════════
            this.lblTitulo.Text = "Nueva Reserva";
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size = new System.Drawing.Size(400, 36);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = TemaManager.TextoPrincipal;

            // ═══════════════════════════════════════════════════
            //  PANEL "EN NOMBRE DE" — solo visible para admin
            //  Se posiciona entre el título y los filtros.
            //  Cuando Visible=false el espacio sigue reservado,
            //  por eso pnlFiltros se mueve dinámicamente en Load.
            // ═══════════════════════════════════════════════════
            int yPanel = 62;

            this.pnlEnNombreDe.Location = new System.Drawing.Point(20, yPanel);
            this.pnlEnNombreDe.Size = new System.Drawing.Size(908, 54);
            this.pnlEnNombreDe.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);  // amarillo suave
            this.pnlEnNombreDe.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlEnNombreDe.Visible = false;   // .cs lo activa si es admin

            // Ícono
            this.lblEnNombreDeIcon.Text = "👤";
            this.lblEnNombreDeIcon.Location = new System.Drawing.Point(12, 16);
            this.lblEnNombreDeIcon.Size = new System.Drawing.Size(24, 22);
            this.lblEnNombreDeIcon.Font = new System.Drawing.Font("Segoe UI", 12F);

            // Etiqueta
            this.lblEnNombreDe.Text = "Reservar en nombre de:";
            this.lblEnNombreDe.Location = new System.Drawing.Point(42, 18);
            this.lblEnNombreDe.Size = new System.Drawing.Size(190, 20);
            this.lblEnNombreDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEnNombreDe.ForeColor = System.Drawing.Color.FromArgb(120, 80, 0);

            // ComboBox de usuarios
            this.cmbUsuarioBeneficiario.Location = new System.Drawing.Point(240, 14);
            this.cmbUsuarioBeneficiario.Size = new System.Drawing.Size(640, 26);
            this.cmbUsuarioBeneficiario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUsuarioBeneficiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarioBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUsuarioBeneficiario.BackColor = System.Drawing.Color.White;

            this.pnlEnNombreDe.Controls.Add(this.lblEnNombreDeIcon);
            this.pnlEnNombreDe.Controls.Add(this.lblEnNombreDe);
            this.pnlEnNombreDe.Controls.Add(this.cmbUsuarioBeneficiario);

            // ═══════════════════════════════════════════════════
            //  PANEL FILTROS
            //  Se desplaza 62 px hacia abajo cuando hay panel admin
            //  El ajuste ocurre en FormNuevaReserva_Load (Visible=true => shift).
            // ═══════════════════════════════════════════════════
            int yFiltros = yPanel + 62;   // debajo del panel admin (aunque esté oculto)

            this.pnlFiltros.Location = new System.Drawing.Point(20, yFiltros);
            this.pnlFiltros.Size = new System.Drawing.Size(908, 240);
            this.pnlFiltros.BackColor = TemaManager.FondoTarjeta;
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(16);

            this.lblSecFiltros.Text = "Parámetros de búsqueda";
            this.lblSecFiltros.Location = new System.Drawing.Point(16, 12);
            this.lblSecFiltros.Size = new System.Drawing.Size(350, 22);
            this.lblSecFiltros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecFiltros.ForeColor = TemaManager.TextoPrincipal;

            // ── Fila 1 ──
            int yR1 = 44; int col1 = 16; int col2 = 240; int col3 = 464; int col4 = 688;
            int lblH = 20; int ctrlH = 30; int lblW = 110; int ctrlW = 200;

            this.lblFecha.Text = "Fecha inicio";
            this.lblFecha.Location = new System.Drawing.Point(col1, yR1);
            this.lblFecha.Size = new System.Drawing.Size(lblW, lblH);
            this.lblFecha.ForeColor = TemaManager.TextoSecundario;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.dtpFecha.Location = new System.Drawing.Point(col1, yR1 + lblH + 2);
            this.dtpFecha.Size = new System.Drawing.Size(ctrlW, ctrlH);
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            this.lblFechaFin.Text = "Fecha fin";
            this.lblFechaFin.Location = new System.Drawing.Point(col2, yR1);
            this.lblFechaFin.Size = new System.Drawing.Size(lblW, lblH);
            this.lblFechaFin.ForeColor = TemaManager.TextoSecundario;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.dtpFechaFin.Location = new System.Drawing.Point(col2, yR1 + lblH + 2);
            this.dtpFechaFin.Size = new System.Drawing.Size(ctrlW, ctrlH);
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblHoraInicio.Text = "Hora inicio";
            this.lblHoraInicio.Location = new System.Drawing.Point(col3, yR1);
            this.lblHoraInicio.Size = new System.Drawing.Size(lblW, lblH);
            this.lblHoraInicio.ForeColor = TemaManager.TextoSecundario;
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.cmbHoraInicio.Location = new System.Drawing.Point(col3, yR1 + lblH + 2);
            this.cmbHoraInicio.Size = new System.Drawing.Size(ctrlW, ctrlH);
            this.cmbHoraInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.lblHoraFin.Text = "Hora fin";
            this.lblHoraFin.Location = new System.Drawing.Point(col4, yR1);
            this.lblHoraFin.Size = new System.Drawing.Size(lblW, lblH);
            this.lblHoraFin.ForeColor = TemaManager.TextoSecundario;
            this.lblHoraFin.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.cmbHoraFin.Location = new System.Drawing.Point(col4, yR1 + lblH + 2);
            this.cmbHoraFin.Size = new System.Drawing.Size(ctrlW, ctrlH);
            this.cmbHoraFin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // ── Fila 2 ──
            int yR2 = yR1 + lblH + ctrlH + 18;

            this.lblAsistentes.Text = "N.º asistentes";
            this.lblAsistentes.Location = new System.Drawing.Point(col1, yR2);
            this.lblAsistentes.Size = new System.Drawing.Size(lblW, lblH);
            this.lblAsistentes.ForeColor = TemaManager.TextoSecundario;
            this.lblAsistentes.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.nudAsistentes.Location = new System.Drawing.Point(col1, yR2 + lblH + 2);
            this.nudAsistentes.Size = new System.Drawing.Size(110, ctrlH);
            this.nudAsistentes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudAsistentes.Minimum = 1;
            this.nudAsistentes.Maximum = 500;
            this.nudAsistentes.Value = 1;

            this.lblMotivo.Text = "Motivo de la reserva";
            this.lblMotivo.Location = new System.Drawing.Point(col2, yR2);
            this.lblMotivo.Size = new System.Drawing.Size(200, lblH);
            this.lblMotivo.ForeColor = TemaManager.TextoSecundario;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.txtMotivo.Location = new System.Drawing.Point(col2, yR2 + lblH + 2);
            this.txtMotivo.Size = new System.Drawing.Size(464, ctrlH);
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblRecurrente.Text = "¿Recurrente?";
            this.lblRecurrente.Location = new System.Drawing.Point(col4, yR2);
            this.lblRecurrente.Size = new System.Drawing.Size(110, lblH);
            this.lblRecurrente.ForeColor = TemaManager.TextoSecundario;
            this.lblRecurrente.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.chkRecurrente.Location = new System.Drawing.Point(col4, yR2 + lblH + 6);
            this.chkRecurrente.Size = new System.Drawing.Size(18, 18);
            this.chkRecurrente.CheckedChanged += new System.EventHandler(this.chkRecurrente_CheckedChanged);

            this.lblFrecuencia.Text = "Frecuencia";
            this.lblFrecuencia.Location = new System.Drawing.Point(col4 + 28, yR2);
            this.lblFrecuencia.Size = new System.Drawing.Size(100, lblH);
            this.lblFrecuencia.ForeColor = TemaManager.TextoSecundario;
            this.lblFrecuencia.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFrecuencia.Visible = false;

            this.cmbFrecuencia.Location = new System.Drawing.Point(col4 + 28, yR2 + lblH + 2);
            this.cmbFrecuencia.Size = new System.Drawing.Size(150, ctrlH);
            this.cmbFrecuencia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrecuencia.Items.AddRange(new object[] { "diaria", "semanal", "mensual", "anual" });
            this.cmbFrecuencia.SelectedIndex = 1;
            this.cmbFrecuencia.Visible = false;

            // ── Fila 3: Requerimientos ──
            int yR3 = yR2 + lblH + ctrlH + 18;

            this.lblReqTitle.Text = "Requerimientos:";
            this.lblReqTitle.Location = new System.Drawing.Point(col1, yR3 + 4);
            this.lblReqTitle.Size = new System.Drawing.Size(120, lblH);
            this.lblReqTitle.ForeColor = TemaManager.TextoSecundario;
            this.lblReqTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.chkProyector.Text = "Proyector";
            this.chkProyector.Location = new System.Drawing.Point(col1 + 125, yR3 + 2);
            this.chkProyector.Size = new System.Drawing.Size(100, 22);
            this.chkProyector.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkProyector.ForeColor = TemaManager.TextoPrincipal;

            this.chkComputadoras.Text = "Computadoras";
            this.chkComputadoras.Location = new System.Drawing.Point(col1 + 235, yR3 + 2);
            this.chkComputadoras.Size = new System.Drawing.Size(130, 22);
            this.chkComputadoras.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkComputadoras.ForeColor = TemaManager.TextoPrincipal;

            this.chkEnchufes.Text = "Enchufes";
            this.chkEnchufes.Location = new System.Drawing.Point(col1 + 375, yR3 + 2);
            this.chkEnchufes.Size = new System.Drawing.Size(100, 22);
            this.chkEnchufes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkEnchufes.ForeColor = TemaManager.TextoPrincipal;

            this.btnBuscar.Text = "Buscar Ambientes";
            this.btnBuscar.Location = new System.Drawing.Point(col4, yR3);
            this.btnBuscar.Size = new System.Drawing.Size(200, 34);
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.BackColor = TemaManager.Acento;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // Agregar al panel filtros
            this.pnlFiltros.Controls.Add(this.lblSecFiltros);
            this.pnlFiltros.Controls.Add(this.lblFecha);
            this.pnlFiltros.Controls.Add(this.dtpFecha);
            this.pnlFiltros.Controls.Add(this.lblFechaFin);
            this.pnlFiltros.Controls.Add(this.dtpFechaFin);
            this.pnlFiltros.Controls.Add(this.lblHoraInicio);
            this.pnlFiltros.Controls.Add(this.cmbHoraInicio);
            this.pnlFiltros.Controls.Add(this.lblHoraFin);
            this.pnlFiltros.Controls.Add(this.cmbHoraFin);
            this.pnlFiltros.Controls.Add(this.lblAsistentes);
            this.pnlFiltros.Controls.Add(this.nudAsistentes);
            this.pnlFiltros.Controls.Add(this.lblMotivo);
            this.pnlFiltros.Controls.Add(this.txtMotivo);
            this.pnlFiltros.Controls.Add(this.lblRecurrente);
            this.pnlFiltros.Controls.Add(this.chkRecurrente);
            this.pnlFiltros.Controls.Add(this.lblFrecuencia);
            this.pnlFiltros.Controls.Add(this.cmbFrecuencia);
            this.pnlFiltros.Controls.Add(this.lblReqTitle);
            this.pnlFiltros.Controls.Add(this.chkProyector);
            this.pnlFiltros.Controls.Add(this.chkComputadoras);
            this.pnlFiltros.Controls.Add(this.chkEnchufes);
            this.pnlFiltros.Controls.Add(this.btnBuscar);

            // ═══════════════════════════════════════════════════
            //  PANEL GRID
            // ═══════════════════════════════════════════════════
            int yGrid = yFiltros + 248;   // filtros (240) + 8 de margen

            this.pnlGrid.Location = new System.Drawing.Point(20, yGrid);
            this.pnlGrid.Size = new System.Drawing.Size(908, 290);
            this.pnlGrid.BackColor = TemaManager.FondoTarjeta;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);

            this.lblSecGrid.Text = "Ambientes disponibles";
            this.lblSecGrid.Location = new System.Drawing.Point(16, 12);
            this.lblSecGrid.Size = new System.Drawing.Size(350, 22);
            this.lblSecGrid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecGrid.ForeColor = TemaManager.TextoPrincipal;

            this.lblMensaje.Text = "";
            this.lblMensaje.Location = new System.Drawing.Point(16, 38);
            this.lblMensaje.Size = new System.Drawing.Size(870, 20);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMensaje.ForeColor = TemaManager.TextoSecundario;

            this.dgvAmbientes.Location = new System.Drawing.Point(16, 62);
            this.dgvAmbientes.Size = new System.Drawing.Size(874, 210);
            this.dgvAmbientes.BackgroundColor = TemaManager.FondoGrid;
            this.dgvAmbientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAmbientes.RowHeadersVisible = false;
            this.dgvAmbientes.AllowUserToAddRows = false;
            this.dgvAmbientes.AllowUserToDeleteRows = false;
            this.dgvAmbientes.ReadOnly = true;
            this.dgvAmbientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmbientes.MultiSelect = false;
            this.dgvAmbientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAmbientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvAmbientes.RowTemplate.Height = 34;
            this.dgvAmbientes.GridColor = TemaManager.FondoTarjeta2;
            this.dgvAmbientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.BackColor = TemaManager.FondoMenu;
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(178, 200, 230);
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvAmbientes.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvAmbientes.ColumnHeadersHeight = 32;
            this.dgvAmbientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAmbientes.EnableHeadersVisualStyles = false;
            this.dgvAmbientes.DefaultCellStyle.BackColor = TemaManager.FondoGrid;
            this.dgvAmbientes.DefaultCellStyle.ForeColor = TemaManager.TextoPrincipal;
            this.dgvAmbientes.DefaultCellStyle.SelectionBackColor = TemaManager.Acento;
            this.dgvAmbientes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAmbientes.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvAmbientes.AlternatingRowsDefaultCellStyle.BackColor = TemaManager.FondoTarjeta2;
            this.dgvAmbientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAmbientes_CellPainting);

            this.pnlGrid.Controls.Add(this.lblSecGrid);
            this.pnlGrid.Controls.Add(this.lblMensaje);
            this.pnlGrid.Controls.Add(this.dgvAmbientes);

            // ═══════════════════════════════════════════════════
            //  PANEL ACCIONES
            // ═══════════════════════════════════════════════════
            int yAcciones = yGrid + 298;

            this.pnlAcciones.Location = new System.Drawing.Point(20, yAcciones);
            this.pnlAcciones.Size = new System.Drawing.Size(908, 48);
            this.pnlAcciones.BackColor = System.Drawing.Color.Transparent;

            this.btnReservar.Text = "Confirmar Reserva";
            this.btnReservar.Location = new System.Drawing.Point(668, 6);
            this.btnReservar.Size = new System.Drawing.Size(168, 36);
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReservar.BackColor = TemaManager.Exito;
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.FlatAppearance.BorderSize = 0;
            this.btnReservar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(844, 6);
            this.btnCancelar.Size = new System.Drawing.Size(86, 36);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.BackColor = TemaManager.Peligro;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.pnlAcciones.Controls.Add(this.btnReservar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);

            // ═══════════════════════════════════════════════════
            //  CONTROLES AL FORM
            // ═══════════════════════════════════════════════════
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlEnNombreDe);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlAcciones);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).EndInit();
            this.pnlEnNombreDe.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaraciones ─────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        // Panel en nombre de
        private System.Windows.Forms.Panel pnlEnNombreDe;
        private System.Windows.Forms.Label lblEnNombreDeIcon;
        private System.Windows.Forms.Label lblEnNombreDe;
        private System.Windows.Forms.ComboBox cmbUsuarioBeneficiario;
        // Filtros
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblSecFiltros;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.ComboBox cmbHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.ComboBox cmbHoraFin;
        private System.Windows.Forms.Label lblAsistentes;
        private System.Windows.Forms.NumericUpDown nudAsistentes;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblReqTitle;
        private System.Windows.Forms.CheckBox chkProyector;
        private System.Windows.Forms.CheckBox chkComputadoras;
        private System.Windows.Forms.CheckBox chkEnchufes;
        private System.Windows.Forms.Label lblRecurrente;
        private System.Windows.Forms.CheckBox chkRecurrente;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.ComboBox cmbFrecuencia;
        private System.Windows.Forms.Button btnBuscar;
        // Grid
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSecGrid;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        // Acciones
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnCancelar;
    }
}