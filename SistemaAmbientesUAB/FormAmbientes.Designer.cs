namespace SistemaAmbientesUAB
{
    partial class FormAmbientes
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
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblBloque        = new System.Windows.Forms.Label();
            this.cmbBloque        = new System.Windows.Forms.ComboBox();
            this.lblTipo          = new System.Windows.Forms.Label();
            this.cmbTipo          = new System.Windows.Forms.ComboBox();
            this.txtBuscar        = new System.Windows.Forms.TextBox();
            this.btnFiltrar       = new System.Windows.Forms.Button();
            this.dgvAmbientes     = new System.Windows.Forms.DataGridView();
            this.btnNuevo         = new System.Windows.Forms.Button();
            this.btnEditar        = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.lblMensaje       = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text            = "Gestión de Ambientes";
            this.Size            = new System.Drawing.Size(940, 600);
            this.MinimumSize     = new System.Drawing.Size(860, 540);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor       = System.Drawing.Color.White;
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load           += new System.EventHandler(this.FormAmbientes_Load);

            // TÍTULO
            this.lblTitulo.Text      = "Gestión de Ambientes";
            this.lblTitulo.Location  = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size      = new System.Drawing.Size(380, 36);
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = TemaManager.TextoPrincipal;

            // BARRA DE FILTROS (y = 66)
            int yF = 66; int h = 30;

            this.lblBloque.Text     = "Bloque";
            this.lblBloque.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBloque.Size     = new System.Drawing.Size(60, 16);
            this.lblBloque.Font     = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbBloque.Location     = new System.Drawing.Point(20, yF);
            this.cmbBloque.Size         = new System.Drawing.Size(140, h);
            this.cmbBloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloque.Font         = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblTipo.Text     = "Tipo";
            this.lblTipo.Location = new System.Drawing.Point(172, yF - 18);
            this.lblTipo.Size     = new System.Drawing.Size(60, 16);
            this.lblTipo.Font     = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbTipo.Location     = new System.Drawing.Point(172, yF);
            this.cmbTipo.Size         = new System.Drawing.Size(150, h);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipo.Items.AddRange(new object[] { "Todos", "aula", "laboratorio", "auditorio", "coliseo" });
            this.cmbTipo.SelectedIndex = 0;

            // Buscador
            this.txtBuscar.Location    = new System.Drawing.Point(336, yF);
            this.txtBuscar.Size        = new System.Drawing.Size(220, h);
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Text        = "Buscar ambiente...";
            this.txtBuscar.ForeColor   = TemaManager.TextoMuted;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter       += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave       += new System.EventHandler(this.txtBuscar_Leave);

            this.btnFiltrar.Text     = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(568, yF);
            this.btnFiltrar.Size     = new System.Drawing.Size(90, h);
            this.btnFiltrar.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFiltrar.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click   += new System.EventHandler(this.btnFiltrar_Click);

            // DATAGRIDVIEW
            this.dgvAmbientes.Location           = new System.Drawing.Point(20, 112);
            this.dgvAmbientes.Size               = new System.Drawing.Size(892, 390);
            this.dgvAmbientes.BackgroundColor     = System.Drawing.Color.White;
            this.dgvAmbientes.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvAmbientes.RowHeadersVisible   = false;
            this.dgvAmbientes.AllowUserToAddRows  = false;
            this.dgvAmbientes.AllowUserToDeleteRows = false;
            this.dgvAmbientes.ReadOnly            = true;
            this.dgvAmbientes.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmbientes.MultiSelect         = false;
            this.dgvAmbientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAmbientes.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAmbientes.EnableHeadersVisualStyles = false;
            this.dgvAmbientes.RowTemplate.Height  = 36;
            this.dgvAmbientes.CellBorderStyle     = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAmbientes.CellPainting       += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAmbientes_CellPainting);

            // BOTONES INFERIORES
            int yB = 516;
            this.btnNuevo.Text     = "➕ Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(20, yB);
            this.btnNuevo.Size     = new System.Drawing.Size(120, 36);
            this.btnNuevo.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNuevo.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Click   += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Text     = "✏️ Editar";
            this.btnEditar.Location = new System.Drawing.Point(152, yB);
            this.btnEditar.Size     = new System.Drawing.Size(120, 36);
            this.btnEditar.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEditar.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click   += new System.EventHandler(this.btnEditar_Click);

            this.btnCambiarEstado.Text     = "🔄 Cambiar Estado";
            this.btnCambiarEstado.Location = new System.Drawing.Point(284, yB);
            this.btnCambiarEstado.Size     = new System.Drawing.Size(165, 36);
            this.btnCambiarEstado.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCambiarEstado.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.Click   += new System.EventHandler(this.btnCambiarEstado_Click);

            this.lblMensaje.Text      = "";
            this.lblMensaje.Location  = new System.Drawing.Point(464, yB + 8);
            this.lblMensaje.Size      = new System.Drawing.Size(440, 22);
            this.lblMensaje.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = TemaManager.TextoMuted;

            // AGREGAR AL FORM
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBloque);
            this.Controls.Add(this.cmbBloque);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvAmbientes);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBloque;
        private System.Windows.Forms.ComboBox cmbBloque;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvAmbientes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Label lblMensaje;
    }
}
