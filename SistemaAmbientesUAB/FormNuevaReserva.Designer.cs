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
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.cmbHoraFin = new System.Windows.Forms.ComboBox();
            this.lblAsistentes = new System.Windows.Forms.Label();
            this.nudAsistentes = new System.Windows.Forms.NumericUpDown();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblProyector = new System.Windows.Forms.Label();
            this.chkProyector = new System.Windows.Forms.CheckBox();
            this.lblComputadoras = new System.Windows.Forms.Label();
            this.chkComputadoras = new System.Windows.Forms.CheckBox();
            this.lblEnchufes = new System.Windows.Forms.Label();
            this.chkEnchufes = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblAmbientes = new System.Windows.Forms.Label();
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblRecurrente = new System.Windows.Forms.Label();
            this.chkRecurrente = new System.Windows.Forms.CheckBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.cmbFrecuencia = new System.Windows.Forms.ComboBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Nueva Reserva";
            this.Size = new System.Drawing.Size(900, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormNuevaReserva_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "➕ Nueva Reserva";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(300, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── FECHA INICIO ──────────────────────────────────
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Location = new System.Drawing.Point(20, 70);
            this.lblFecha.Size = new System.Drawing.Size(120, 25);
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.dtpFecha.Location = new System.Drawing.Point(150, 67);
            this.dtpFecha.Size = new System.Drawing.Size(180, 25);
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            // ── FECHA FIN ─────────────────────────────────────
            this.lblFechaFin.Text = "Fecha fin:";
            this.lblFechaFin.Location = new System.Drawing.Point(350, 70);
            this.lblFechaFin.Size = new System.Drawing.Size(100, 25);
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.dtpFechaFin.Location = new System.Drawing.Point(455, 67);
            this.dtpFechaFin.Size = new System.Drawing.Size(180, 25);
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // ── HORA INICIO ───────────────────────────────────
            this.lblHoraInicio.Text = "Hora inicio:";
            this.lblHoraInicio.Location = new System.Drawing.Point(20, 110);
            this.lblHoraInicio.Size = new System.Drawing.Size(120, 25);
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbHoraInicio.Location = new System.Drawing.Point(150, 107);
            this.cmbHoraInicio.Size = new System.Drawing.Size(180, 25);
            this.cmbHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ── HORA FIN ──────────────────────────────────────
            this.lblHoraFin.Text = "Hora fin:";
            this.lblHoraFin.Location = new System.Drawing.Point(350, 110);
            this.lblHoraFin.Size = new System.Drawing.Size(100, 25);
            this.lblHoraFin.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.cmbHoraFin.Location = new System.Drawing.Point(455, 107);
            this.cmbHoraFin.Size = new System.Drawing.Size(180, 25);
            this.cmbHoraFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ── ASISTENTES ────────────────────────────────────
            this.lblAsistentes.Text = "Asistentes:";
            this.lblAsistentes.Location = new System.Drawing.Point(20, 150);
            this.lblAsistentes.Size = new System.Drawing.Size(120, 25);
            this.lblAsistentes.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.nudAsistentes.Location = new System.Drawing.Point(150, 148);
            this.nudAsistentes.Size = new System.Drawing.Size(100, 25);
            this.nudAsistentes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAsistentes.Minimum = 1;
            this.nudAsistentes.Maximum = 500;
            this.nudAsistentes.Value = 1;

            // ── MOTIVO ────────────────────────────────────────
            this.lblMotivo.Text = "Motivo:";
            this.lblMotivo.Location = new System.Drawing.Point(350, 150);
            this.lblMotivo.Size = new System.Drawing.Size(100, 25);
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.txtMotivo.Location = new System.Drawing.Point(455, 148);
            this.txtMotivo.Size = new System.Drawing.Size(400, 25);
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ── REQUERIMIENTOS ────────────────────────────────
            this.lblProyector.Text = "Proyector:";
            this.lblProyector.Location = new System.Drawing.Point(20, 190);
            this.lblProyector.Size = new System.Drawing.Size(90, 25);
            this.lblProyector.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkProyector.Location = new System.Drawing.Point(115, 192);
            this.chkProyector.Size = new System.Drawing.Size(20, 20);

            this.lblComputadoras.Text = "Computadoras:";
            this.lblComputadoras.Location = new System.Drawing.Point(160, 190);
            this.lblComputadoras.Size = new System.Drawing.Size(110, 25);
            this.lblComputadoras.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkComputadoras.Location = new System.Drawing.Point(275, 192);
            this.chkComputadoras.Size = new System.Drawing.Size(20, 20);

            this.lblEnchufes.Text = "Enchufes:";
            this.lblEnchufes.Location = new System.Drawing.Point(320, 190);
            this.lblEnchufes.Size = new System.Drawing.Size(80, 25);
            this.lblEnchufes.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkEnchufes.Location = new System.Drawing.Point(405, 192);
            this.chkEnchufes.Size = new System.Drawing.Size(20, 20);

            // ── RECURRENTE ────────────────────────────────────
            this.lblRecurrente.Text = "¿Recurrente?:";
            this.lblRecurrente.Location = new System.Drawing.Point(20, 230);
            this.lblRecurrente.Size = new System.Drawing.Size(110, 25);
            this.lblRecurrente.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.chkRecurrente.Location = new System.Drawing.Point(135, 232);
            this.chkRecurrente.Size = new System.Drawing.Size(20, 20);
            this.chkRecurrente.CheckedChanged += new System.EventHandler(this.chkRecurrente_CheckedChanged);

            this.lblFrecuencia.Text = "Frecuencia:";
            this.lblFrecuencia.Location = new System.Drawing.Point(180, 230);
            this.lblFrecuencia.Size = new System.Drawing.Size(90, 25);
            this.lblFrecuencia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrecuencia.Visible = false;

            this.cmbFrecuencia.Location = new System.Drawing.Point(275, 228);
            this.cmbFrecuencia.Size = new System.Drawing.Size(150, 25);
            this.cmbFrecuencia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrecuencia.Items.AddRange(new object[] { "diaria", "semanal", "mensual", "anual" });
            this.cmbFrecuencia.SelectedIndex = 1;
            this.cmbFrecuencia.Visible = false;

            // ── BOTÓN BUSCAR AMBIENTES ────────────────────────
            this.btnBuscar.Text = "🔍  Buscar Ambientes Disponibles";
            this.btnBuscar.Location = new System.Drawing.Point(20, 270);
            this.btnBuscar.Size = new System.Drawing.Size(280, 40);
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // ── LABEL AMBIENTES ───────────────────────────────
            this.lblAmbientes.Text = "Ambientes disponibles:";
            this.lblAmbientes.Location = new System.Drawing.Point(20, 325);
            this.lblAmbientes.Size = new System.Drawing.Size(200, 25);
            this.lblAmbientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // ── DATAGRIDVIEW AMBIENTES ────────────────────────
            this.dgvAmbientes.Location = new System.Drawing.Point(20, 350);
            this.dgvAmbientes.Size = new System.Drawing.Size(850, 170);
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
            this.dgvAmbientes.RowTemplate.Height = 32;
            this.dgvAmbientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 255);

            // ── BOTÓN RESERVAR ────────────────────────────────
            this.btnReservar.Text = "✅  Confirmar Reserva";
            this.btnReservar.Location = new System.Drawing.Point(560, 535);
            this.btnReservar.Size = new System.Drawing.Size(200, 40);
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReservar.BackColor = System.Drawing.Color.FromArgb(40, 120, 40);
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.FlatAppearance.BorderSize = 0;
            this.btnReservar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);

            // ── BOTÓN CANCELAR ────────────────────────────────
            this.btnCancelar.Text = "✖  Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(770, 535);
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── LABEL MENSAJE ─────────────────────────────────
            this.lblMensaje.Text = "";
            this.lblMensaje.Location = new System.Drawing.Point(20, 545);
            this.lblMensaje.Size = new System.Drawing.Size(520, 25);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.cmbHoraInicio);
            this.Controls.Add(this.lblHoraFin);
            this.Controls.Add(this.cmbHoraFin);
            this.Controls.Add(this.lblAsistentes);
            this.Controls.Add(this.nudAsistentes);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblProyector);
            this.Controls.Add(this.chkProyector);
            this.Controls.Add(this.lblComputadoras);
            this.Controls.Add(this.chkComputadoras);
            this.Controls.Add(this.lblEnchufes);
            this.Controls.Add(this.chkEnchufes);
            this.Controls.Add(this.lblRecurrente);
            this.Controls.Add(this.chkRecurrente);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.cmbFrecuencia);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblAmbientes);
            this.Controls.Add(this.dgvAmbientes);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
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
        private System.Windows.Forms.Label lblProyector;
        private System.Windows.Forms.CheckBox chkProyector;
        private System.Windows.Forms.Label lblComputadoras;
        private System.Windows.Forms.CheckBox chkComputadoras;
        private System.Windows.Forms.Label lblEnchufes;
        private System.Windows.Forms.CheckBox chkEnchufes;
        private System.Windows.Forms.Label lblRecurrente;
        private System.Windows.Forms.CheckBox chkRecurrente;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.ComboBox cmbFrecuencia;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblAmbientes;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMensaje;
    }
}