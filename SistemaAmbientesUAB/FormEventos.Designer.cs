namespace SistemaAmbientesUAB
{
    partial class FormEventos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblMensaje;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "Gestión de Eventos";
            this.Size = new System.Drawing.Size(940, 600);
            this.MinimumSize = new System.Drawing.Size(860, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormEventos_Load);

            // TÍTULO
            this.lblTitulo.Text = "Gestión de Eventos";
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size = new System.Drawing.Size(380, 36);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = TemaManager.TextoPrincipal;

            // BARRA DE BÚSQUEDA (Continuación)
            int yF = 66; int h = 30;

            this.lblBuscar.Text = "Buscar por nombre";
            this.lblBuscar.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBuscar.Size = new System.Drawing.Size(120, 16);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.txtBuscar.Location = new System.Drawing.Point(20, yF);
            this.txtBuscar.Size = new System.Drawing.Size(320, h);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.btnFiltrar.Text = "🔍 Limpiar Filtro";
            this.btnFiltrar.Location = new System.Drawing.Point(348, yF - 1);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 28);
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // BOTONES PRINCIPALES (Alineados a la derecha de la barra superior)
            this.btnNuevo.Text = "➕ Nuevo Evento";
            this.btnNuevo.Location = new System.Drawing.Point(520, yF - 1);
            this.btnNuevo.Size = new System.Drawing.Size(120, 28);
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.Location = new System.Drawing.Point(646, yF - 1);
            this.btnEditar.Size = new System.Drawing.Size(100, 28);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "❌ Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(752, yF - 1);
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // TABLA DE EVENTOS (Abarca el resto del formulario)
            this.dgvEventos.Location = new System.Drawing.Point(20, 110);
            this.dgvEventos.Size = new System.Drawing.Size(884, 400);
            this.dgvEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // LBL MENSAJE DE ESTADO (Pie de página)
            this.lblMensaje.Text = "Cargando eventos...";
            this.lblMensaje.Location = new System.Drawing.Point(20, 525);
            this.lblMensaje.Size = new System.Drawing.Size(500, 20);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

            // AGREGAR CONTROLES AL FORM
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvEventos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}