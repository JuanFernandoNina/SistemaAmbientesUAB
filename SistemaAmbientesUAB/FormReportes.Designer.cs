namespace SistemaAmbientesUAB
{
    partial class FormReportes
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
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnAmbientesMasUsados = new System.Windows.Forms.Button();
            this.btnReservasCanceladas = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnUsoPorCarrera = new System.Windows.Forms.Button();
            this.btnTodasReservas = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelFiltroFecha = new System.Windows.Forms.Panel();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFechaGuion = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAplicarFiltroFecha = new System.Windows.Forms.Button();
            this.btnQuitarFiltroFecha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Reportes y Estadísticas";
            this.Size = new System.Drawing.Size(950, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Load += new System.EventHandler(this.FormReportes_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "📊 Reportes y Estadísticas";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(400, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── PANEL BOTONES ─────────────────────────────────
            this.panelBotones.Location = new System.Drawing.Point(20, 60);
            this.panelBotones.Size = new System.Drawing.Size(900, 60);
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            ConfigurarBotonReporte(this.btnAmbientesMasUsados, "🏆 Ambientes más usados", 0);
            ConfigurarBotonReporte(this.btnReservasCanceladas, "❌ Cancelaciones", 185);
            ConfigurarBotonReporte(this.btnDisponibilidad, "📅 Disponibilidad hoy", 370);
            ConfigurarBotonReporte(this.btnUsoPorCarrera, "🎓 Uso por carrera", 555);
            ConfigurarBotonReporte(this.btnTodasReservas, "📋 Todas las reservas", 740);

            this.btnAmbientesMasUsados.Click += new System.EventHandler(this.btnAmbientesMasUsados_Click);
            this.btnReservasCanceladas.Click += new System.EventHandler(this.btnReservasCanceladas_Click);
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            this.btnUsoPorCarrera.Click += new System.EventHandler(this.btnUsoPorCarrera_Click);
            this.btnTodasReservas.Click += new System.EventHandler(this.btnTodasReservas_Click);

            this.panelBotones.Controls.Add(this.btnAmbientesMasUsados);
            this.panelBotones.Controls.Add(this.btnReservasCanceladas);
            this.panelBotones.Controls.Add(this.btnDisponibilidad);
            this.panelBotones.Controls.Add(this.btnUsoPorCarrera);
            this.panelBotones.Controls.Add(this.btnTodasReservas);

            // ── PANEL FILTRO DE FECHA ──────────────────────────
            this.panelFiltroFecha.Location = new System.Drawing.Point(20, 128);
            this.panelFiltroFecha.Size = new System.Drawing.Size(900, 36);
            this.panelFiltroFecha.BackColor = System.Drawing.Color.White;

            this.lblFiltroFecha.Text = "Rango de fechas:";
            this.lblFiltroFecha.Location = new System.Drawing.Point(0, 10);
            this.lblFiltroFecha.Size = new System.Drawing.Size(130, 20);
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);

            this.dtpDesde.Location = new System.Drawing.Point(135, 5);
            this.dtpDesde.Size = new System.Drawing.Size(110, 27);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Value = System.DateTime.Today.AddMonths(-1);

            this.lblFiltroFechaGuion.Text = "—";
            this.lblFiltroFechaGuion.Location = new System.Drawing.Point(250, 10);
            this.lblFiltroFechaGuion.Size = new System.Drawing.Size(15, 20);
            this.lblFiltroFechaGuion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroFechaGuion.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);

            this.dtpHasta.Location = new System.Drawing.Point(270, 5);
            this.dtpHasta.Size = new System.Drawing.Size(110, 27);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Value = System.DateTime.Today;

            this.btnAplicarFiltroFecha.Text = "Aplicar";
            this.btnAplicarFiltroFecha.Location = new System.Drawing.Point(395, 3);
            this.btnAplicarFiltroFecha.Size = new System.Drawing.Size(85, 30);
            this.btnAplicarFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAplicarFiltroFecha.Click += new System.EventHandler(this.btnAplicarFiltroFecha_Click);

            this.btnQuitarFiltroFecha.Text = "Quitar filtro";
            this.btnQuitarFiltroFecha.Location = new System.Drawing.Point(488, 3);
            this.btnQuitarFiltroFecha.Size = new System.Drawing.Size(110, 30);
            this.btnQuitarFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuitarFiltroFecha.Click += new System.EventHandler(this.btnQuitarFiltroFecha_Click);

            this.panelFiltroFecha.Controls.Add(this.lblFiltroFecha);
            this.panelFiltroFecha.Controls.Add(this.dtpDesde);
            this.panelFiltroFecha.Controls.Add(this.lblFiltroFechaGuion);
            this.panelFiltroFecha.Controls.Add(this.dtpHasta);
            this.panelFiltroFecha.Controls.Add(this.btnAplicarFiltroFecha);
            this.panelFiltroFecha.Controls.Add(this.btnQuitarFiltroFecha);

            // ── SUBTÍTULO reporte activo ──────────────────────
            this.lblSubtitulo.Text = "Selecciona un reporte arriba";
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 174);
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 28);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(40, 80, 160);

            // ── DATAGRIDVIEW ──────────────────────────────────
            this.dgvReporte.Location = new System.Drawing.Point(20, 210);
            this.dgvReporte.Size = new System.Drawing.Size(900, 360);
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReporte.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.RowTemplate.Height = 35;
            this.dgvReporte.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 255);
            this.dgvReporte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReporte.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvReporte_CellPainting);

            // ── LABEL TOTAL ───────────────────────────────────
            this.lblTotal.Text = "";
            this.lblTotal.Location = new System.Drawing.Point(20, 580);
            this.lblTotal.Size = new System.Drawing.Size(700, 25);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltroFecha);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblTotal);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarBotonReporte(System.Windows.Forms.Button btn, string texto, int posX)
        {
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(posX, 10);
            btn.Size = new System.Drawing.Size(175, 40);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            btn.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnAmbientesMasUsados;
        private System.Windows.Forms.Button btnReservasCanceladas;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.Button btnUsoPorCarrera;
        private System.Windows.Forms.Button btnTodasReservas;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel panelFiltroFecha;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblFiltroFechaGuion;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicarFiltroFecha;
        private System.Windows.Forms.Button btnQuitarFiltroFecha;
    }
}