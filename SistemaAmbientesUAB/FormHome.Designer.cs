namespace SistemaAmbientesUAB
{
    partial class FormHome
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelTarjetas = new System.Windows.Forms.Panel();
            this.lblActividad = new System.Windows.Forms.Label();
            this.dgvActividad = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).BeginInit();
            this.SuspendLayout();

            // ── PROPIEDADES DEL FORM ─────────────────────────
            this.Text = "Inicio";
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BackColor = System.Drawing.Color.FromArgb(239, 244, 251);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.Resize += new System.EventHandler(this.FormHome_Resize);

            int L = 28; // Margen izquierdo consistente

            // ── LBL TITULO ───────────────────────────────────
            this.lblTitulo.Text = "Panel de Inicio";
            this.lblTitulo.Location = new System.Drawing.Point(L, 22);
            this.lblTitulo.Size = new System.Drawing.Size(600, 36);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(12, 30, 62);
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── LBL FECHA ────────────────────────────────────
            this.lblFecha.Text = "";
            this.lblFecha.Location = new System.Drawing.Point(L, 60);
            this.lblFecha.Size = new System.Drawing.Size(500, 20);
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(74, 96, 128);
            this.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── PANEL TARJETAS ────────────────────────────────
            this.panelTarjetas.Location = new System.Drawing.Point(L, 90);
            this.panelTarjetas.Size = new System.Drawing.Size(880, 130);
            this.panelTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.panelTarjetas.Anchor = System.Windows.Forms.AnchorStyles.Top
                                         | System.Windows.Forms.AnchorStyles.Left
                                         | System.Windows.Forms.AnchorStyles.Right;

            // ── LBL ACTIVIDAD (SUBTÍTULO SECCIÓN) ─────────────
            this.lblActividad.Text = "Últimas reservas registradas";
            this.lblActividad.Location = new System.Drawing.Point(L, 240);
            this.lblActividad.Size = new System.Drawing.Size(500, 26);
            this.lblActividad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActividad.ForeColor = System.Drawing.Color.FromArgb(12, 30, 62);
            this.lblActividad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── DATAGRIDVIEW ──────────────────────────────────
            this.dgvActividad.Location = new System.Drawing.Point(L, 272);
            this.dgvActividad.Size = new System.Drawing.Size(880, 300);
            this.dgvActividad.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActividad.RowHeadersVisible = false;
            this.dgvActividad.AllowUserToAddRows = false;
            this.dgvActividad.AllowUserToDeleteRows = false;
            this.dgvActividad.ReadOnly = true;
            this.dgvActividad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividad.EnableHeadersVisualStyles = false;
            this.dgvActividad.RowTemplate.Height = 34;
            this.dgvActividad.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActividad.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                     | System.Windows.Forms.AnchorStyles.Left
                                                     | System.Windows.Forms.AnchorStyles.Right
                                                     | System.Windows.Forms.AnchorStyles.Bottom;

            // ── AGREGAR CONTROLES AL FORM ────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.panelTarjetas);
            this.Controls.Add(this.lblActividad);
            this.Controls.Add(this.dgvActividad);

            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panelTarjetas;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.DataGridView dgvActividad;
    }
}