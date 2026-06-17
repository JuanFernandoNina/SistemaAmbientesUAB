namespace SistemaAmbientesUAB
{
    partial class FormEventoDetalle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreEvento;
        private System.Windows.Forms.TextBox txtNombreEvento;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label lblAsistentes;
        private System.Windows.Forms.NumericUpDown nudAsistentes;
        private System.Windows.Forms.Label lblFechaEvento;
        private System.Windows.Forms.DateTimePicker dtpFechaEvento;
        private System.Windows.Forms.Label lblRequerimientos;
        private System.Windows.Forms.TextBox txtRequerimientos;

        private System.Windows.Forms.CheckBox chkCrearReserva;
        private System.Windows.Forms.GroupBox grpReserva;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.ComboBox cmbHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.ComboBox cmbHoraFin;
        private System.Windows.Forms.Button btnBuscarAmbiente;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        private System.Windows.Forms.Label lblMensajeReserva;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreEvento = new System.Windows.Forms.Label();
            this.txtNombreEvento = new System.Windows.Forms.TextBox();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.lblAsistentes = new System.Windows.Forms.Label();
            this.nudAsistentes = new System.Windows.Forms.NumericUpDown();
            this.lblFechaEvento = new System.Windows.Forms.Label();
            this.dtpFechaEvento = new System.Windows.Forms.DateTimePicker();
            this.lblRequerimientos = new System.Windows.Forms.Label();
            this.txtRequerimientos = new System.Windows.Forms.TextBox();

            this.chkCrearReserva = new System.Windows.Forms.CheckBox();
            this.grpReserva = new System.Windows.Forms.GroupBox();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.cmbHoraFin = new System.Windows.Forms.ComboBox();
            this.btnBuscarAmbiente = new System.Windows.Forms.Button();
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            this.lblMensajeReserva = new System.Windows.Forms.Label();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            this.grpReserva.SuspendLayout();
            this.SuspendLayout();

            // FORM (Configuración Base)
            this.Text = "Nuevo Evento";
            this.Size = new System.Drawing.Size(620, 730);
            this.MinimumSize = new System.Drawing.Size(620, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Load += new System.EventHandler(this.FormEventoDetalle_Load);

            // TÍTULO
            this.lblTitulo.Location = new System.Drawing.Point(24, 18);
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);

            int x1 = 24, x2 = 320, w = 260, h = 30, y = 64, gap = 50;

            // NOMBRE DEL EVENTO
            this.lblNombreEvento.Text = "Nombre del evento";
            this.lblNombreEvento.Location = new System.Drawing.Point(x1, y);
            this.lblNombreEvento.Size = new System.Drawing.Size(200, 18);
            this.lblNombreEvento.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            y += 20;
            this.txtNombreEvento.Location = new System.Drawing.Point(x1, y);
            this.txtNombreEvento.Size = new System.Drawing.Size(556, h);
            y += gap;

            // RESPONSABLE / ASISTENTES
            this.lblResponsable.Text = "Responsable";
            this.lblResponsable.Location = new System.Drawing.Point(x1, y);
            this.lblResponsable.Size = new System.Drawing.Size(200, 18);
            this.lblResponsable.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.lblAsistentes.Text = "Asistentes esperados";
            this.lblAsistentes.Location = new System.Drawing.Point(x2, y);
            this.lblAsistentes.Size = new System.Drawing.Size(200, 18);
            this.lblAsistentes.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            y += 20;

            this.cmbResponsable.Location = new System.Drawing.Point(x1, y);
            this.cmbResponsable.Size = new System.Drawing.Size(w, h);
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.nudAsistentes.Location = new System.Drawing.Point(x2, y);
            this.nudAsistentes.Size = new System.Drawing.Size(w, h);
            this.nudAsistentes.Minimum = 1;
            this.nudAsistentes.Maximum = 5000;
            this.nudAsistentes.Value = 20;
            y += gap;

            // FECHA DEL EVENTO
            this.lblFechaEvento.Text = "Fecha del evento";
            this.lblFechaEvento.Location = new System.Drawing.Point(x1, y);
            this.lblFechaEvento.Size = new System.Drawing.Size(200, 18);
            this.lblFechaEvento.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            y += 20;
            this.dtpFechaEvento.Location = new System.Drawing.Point(x1, y);
            this.dtpFechaEvento.Size = new System.Drawing.Size(w, h);
            this.dtpFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEvento.ValueChanged += new System.EventHandler(this.dtpFechaEvento_ValueChanged);
            y += gap;

            // REQUERIMIENTOS
            this.lblRequerimientos.Text = "Requerimientos especiales";
            this.lblRequerimientos.Location = new System.Drawing.Point(x1, y);
            this.lblRequerimientos.Size = new System.Drawing.Size(300, 18);
            this.lblRequerimientos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            y += 20;
            this.txtRequerimientos.Location = new System.Drawing.Point(x1, y);
            this.txtRequerimientos.Size = new System.Drawing.Size(556, 50);
            this.txtRequerimientos.Multiline = true;
            y += 64;

            // CHECKBOX DE CONTROL
            this.chkCrearReserva.Text = "Reservar un ambiente para este evento ahora";
            this.chkCrearReserva.Location = new System.Drawing.Point(x1, y);
            this.chkCrearReserva.Size = new System.Drawing.Size(360, 24);
            this.chkCrearReserva.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkCrearReserva.Checked = true;
            this.chkCrearReserva.CheckedChanged += new System.EventHandler(this.chkCrearReserva_CheckedChanged);
            y += 32;

            // CONTENEDOR DE RESERVA
            this.grpReserva.Text = "Reserva del ambiente";
            this.grpReserva.Location = new System.Drawing.Point(x1, y);
            this.grpReserva.Size = new System.Drawing.Size(556, 280);
            this.grpReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            int ry = 26;
            this.lblHoraInicio.Text = "Hora inicio";
            this.lblHoraInicio.Location = new System.Drawing.Point(14, ry);
            this.lblHoraInicio.Size = new System.Drawing.Size(90, 16);
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.lblHoraFin.Text = "Hora fin";
            this.lblHoraFin.Location = new System.Drawing.Point(180, ry);
            this.lblHoraFin.Size = new System.Drawing.Size(90, 16);
            this.lblHoraFin.Font = new System.Drawing.Font("Segoe UI", 8F);
            ry += 18;

            this.cmbHoraInicio.Location = new System.Drawing.Point(14, ry);
            this.cmbHoraInicio.Size = new System.Drawing.Size(150, 28);
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbHoraFin.Location = new System.Drawing.Point(180, ry);
            this.cmbHoraFin.Size = new System.Drawing.Size(150, 28);
            this.cmbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFin.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnBuscarAmbiente.Text = "Buscar ambientes disponibles";
            this.btnBuscarAmbiente.Location = new System.Drawing.Point(350, ry - 1);
            this.btnBuscarAmbiente.Size = new System.Drawing.Size(192, 28);
            this.btnBuscarAmbiente.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscarAmbiente.Click += new System.EventHandler(this.btnBuscarAmbiente_Click);
            ry += 38;

            this.dgvAmbientes.Location = new System.Drawing.Point(14, ry);
            this.dgvAmbientes.Size = new System.Drawing.Size(528, 170);
            ry += 178;

            this.lblMensajeReserva.Text = "";
            this.lblMensajeReserva.Location = new System.Drawing.Point(14, ry);
            this.lblMensajeReserva.Size = new System.Drawing.Size(528, 20);
            this.lblMensajeReserva.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.grpReserva.Controls.Add(this.lblHoraInicio);
            this.grpReserva.Controls.Add(this.cmbHoraInicio);
            this.grpReserva.Controls.Add(this.lblHoraFin);
            this.grpReserva.Controls.Add(this.cmbHoraFin);
            this.grpReserva.Controls.Add(this.btnBuscarAmbiente);
            this.grpReserva.Controls.Add(this.dgvAmbientes);
            this.grpReserva.Controls.Add(this.lblMensajeReserva);

            y += 295; // Posición de seguridad por defecto inicial

            // BOTONES PRINCIPALES (Anchos expandidos para evitar textos cortados)
            this.btnGuardar.Location = new System.Drawing.Point(220, y);
            this.btnGuardar.Size = new System.Drawing.Size(190, 34);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(420, y);
            this.btnCancelar.Size = new System.Drawing.Size(160, 34);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // AGREGAR CONTROLES AL FORMULARIO
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombreEvento);
            this.Controls.Add(this.txtNombreEvento);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.cmbResponsable);
            this.Controls.Add(this.lblAsistentes);
            this.Controls.Add(this.nudAsistentes);
            this.Controls.Add(this.lblFechaEvento);
            this.Controls.Add(this.dtpFechaEvento);
            this.Controls.Add(this.lblRequerimientos);
            this.Controls.Add(this.txtRequerimientos);
            this.Controls.Add(this.chkCrearReserva);
            this.Controls.Add(this.grpReserva);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            ((System.ComponentModel.ISupportInitialize)(this.nudAsistentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            this.grpReserva.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}