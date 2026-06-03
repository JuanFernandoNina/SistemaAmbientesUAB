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
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Reportes y Estadísticas";
            this.Size = new System.Drawing.Size(950, 600);
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

            // ── SUBTÍTULO reporte activo ──────────────────────
            this.lblSubtitulo.Text = "Selecciona un reporte arriba";
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 130);
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 28);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(40, 80, 160);

            // ── DATAGRIDVIEW ──────────────────────────────────
            this.dgvReporte.Location = new System.Drawing.Point(20, 165);
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

            // ── LABEL TOTAL ───────────────────────────────────
            this.lblTotal.Text = "";
            this.lblTotal.Location = new System.Drawing.Point(20, 535);
            this.lblTotal.Size = new System.Drawing.Size(500, 25);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);

            // ── AGREGAR CONTROLES ─────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelBotones);
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
    }
}