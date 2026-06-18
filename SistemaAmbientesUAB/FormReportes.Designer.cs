namespace SistemaAmbientesUAB
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.panelFiltroFecha.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Reportes y Estadísticas";
            this.Size = new System.Drawing.Size(960, 650);
            this.MinimumSize = new System.Drawing.Size(940, 580);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormReportes_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "Reportes y Estadísticas";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(400, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);

            // ── PANEL BOTONES (Ancho expandible) ──────────────
            this.panelBotones.Location = new System.Drawing.Point(20, 60);
            this.panelBotones.Size = new System.Drawing.Size(904, 60);
            this.panelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            ConfigurarBotonReporte(this.btnAmbientesMasUsados, "Ambientes más usados", 0);
            ConfigurarBotonReporte(this.btnReservasCanceladas, "Cancelaciones", 181);
            ConfigurarBotonReporte(this.btnDisponibilidad, "Disponibilidad hoy", 362);
            ConfigurarBotonReporte(this.btnUsoPorCarrera, "Uso por carrera", 543);
            ConfigurarBotonReporte(this.btnTodasReservas, "Todas las reservas", 724);

            // Permitir que los botones se estiren proporcionalmente al cambiar el tamaño
            this.btnAmbientesMasUsados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnReservasCanceladas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnDisponibilidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnUsoPorCarrera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnTodasReservas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

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

            // ── PANEL FILTRO DE FECHA (Responsive) ───────────
            this.panelFiltroFecha.Location = new System.Drawing.Point(20, 128);
            this.panelFiltroFecha.Size = new System.Drawing.Size(904, 36);
            this.panelFiltroFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            this.lblFiltroFecha.Text = "Rango de fechas:";
            this.lblFiltroFecha.Location = new System.Drawing.Point(0, 10);
            this.lblFiltroFecha.Size = new System.Drawing.Size(110, 20);

            this.dtpDesde.Location = new System.Drawing.Point(115, 5);
            this.dtpDesde.Size = new System.Drawing.Size(110, 27);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Value = System.DateTime.Today.AddMonths(-1);

            this.lblFiltroFechaGuion.Text = "—";
            this.lblFiltroFechaGuion.Location = new System.Drawing.Point(230, 10);
            this.lblFiltroFechaGuion.Size = new System.Drawing.Size(15, 20);

            this.dtpHasta.Location = new System.Drawing.Point(250, 5);
            this.dtpHasta.Size = new System.Drawing.Size(110, 27);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Value = System.DateTime.Today;

            this.btnAplicarFiltroFecha.Text = "Aplicar";
            this.btnAplicarFiltroFecha.Location = new System.Drawing.Point(370, 3);
            this.btnAplicarFiltroFecha.Size = new System.Drawing.Size(85, 30);
            this.btnAplicarFiltroFecha.Click += new System.EventHandler(this.btnAplicarFiltroFecha_Click);

            this.btnQuitarFiltroFecha.Text = "Quitar filtro";
            this.btnQuitarFiltroFecha.Location = new System.Drawing.Point(461, 3);
            this.btnQuitarFiltroFecha.Size = new System.Drawing.Size(110, 30);
            this.btnQuitarFiltroFecha.Click += new System.EventHandler(this.btnQuitarFiltroFecha_Click);

            // Botones de exportación alineados a la derecha de forma responsiva
            this.btnExportarExcel.Text = "📊 Excel (CSV)";
            this.btnExportarExcel.Location = new System.Drawing.Point(663, 3);
            this.btnExportarExcel.Size = new System.Drawing.Size(115, 30);
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            this.btnExportarPdf.Text = "🖨️ PDF";
            this.btnExportarPdf.Location = new System.Drawing.Point(784, 3);
            this.btnExportarPdf.Size = new System.Drawing.Size(120, 30);
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);

            this.panelFiltroFecha.Controls.Add(this.lblFiltroFecha);
            this.panelFiltroFecha.Controls.Add(this.dtpDesde);
            this.panelFiltroFecha.Controls.Add(this.lblFiltroFechaGuion);
            this.panelFiltroFecha.Controls.Add(this.dtpHasta);
            this.panelFiltroFecha.Controls.Add(this.btnAplicarFiltroFecha);
            this.panelFiltroFecha.Controls.Add(this.btnQuitarFiltroFecha);
            this.panelFiltroFecha.Controls.Add(this.btnExportarExcel);
            this.panelFiltroFecha.Controls.Add(this.btnExportarPdf);

            // ── SUBTÍTULO ─────────────────────────────────────
            this.lblSubtitulo.Text = "Selecciona un reporte arriba";
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 178);
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 28);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // ── DATAGRIDVIEW (Abarca todo el ancho y alto del Form de forma adaptativa) ──
            this.dgvReporte.Location = new System.Drawing.Point(20, 212);
            this.dgvReporte.Size = new System.Drawing.Size(904, 348);
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvReporte_CellPainting);

            // ── LABEL TOTAL (Fijado al pie de página) ──────────
            this.lblTotal.Text = "";
            this.lblTotal.Location = new System.Drawing.Point(20, 575);
            this.lblTotal.Size = new System.Drawing.Size(904, 25);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltroFecha);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblTotal);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.panelFiltroFecha.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void ConfigurarBotonReporte(System.Windows.Forms.Button btn, string texto, int posX)
        {
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(posX, 10);
            btn.Size = new System.Drawing.Size(176, 40);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F);
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
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnExportarPdf;
    }
}