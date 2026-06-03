namespace SistemaAmbientesUAB
{
    partial class FormHome
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelTarjetas = new System.Windows.Forms.Panel();
            this.lblActividad = new System.Windows.Forms.Label();
            this.dgvActividad = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).BeginInit();
            this.SuspendLayout();

            this.Text = "Inicio";
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Load += new System.EventHandler(this.FormHome_Load);

            // Título
            this.lblTitulo.Text = "🏠 Panel de Inicio";
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(400, 35);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // Fecha
            this.lblFecha.Text = "";
            this.lblFecha.Location = new System.Drawing.Point(20, 52);
            this.lblFecha.Size = new System.Drawing.Size(500, 22);
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.ForeColor = System.Drawing.Color.Gray;

            // Panel tarjetas
            this.panelTarjetas.Location = new System.Drawing.Point(20, 82);
            this.panelTarjetas.Size = new System.Drawing.Size(840, 240);
            this.panelTarjetas.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // Label actividad
            this.lblActividad.Text = "📋 Últimas reservas registradas";
            this.lblActividad.Location = new System.Drawing.Point(20, 340);
            this.lblActividad.Size = new System.Drawing.Size(350, 25);
            this.lblActividad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblActividad.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // DataGridView
            this.dgvActividad.Location = new System.Drawing.Point(20, 370);
            this.dgvActividad.Size = new System.Drawing.Size(840, 250);
            this.dgvActividad.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActividad.RowHeadersVisible = false;
            this.dgvActividad.AllowUserToAddRows = false;
            this.dgvActividad.AllowUserToDeleteRows = false;
            this.dgvActividad.ReadOnly = true;
            this.dgvActividad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvActividad.EnableHeadersVisualStyles = false;
            this.dgvActividad.RowTemplate.Height = 33;

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