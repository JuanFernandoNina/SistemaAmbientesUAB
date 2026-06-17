namespace SistemaAmbientesUAB
{
    partial class FormUsuarios
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
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblBuscar       = new System.Windows.Forms.Label();
            this.txtBuscar       = new System.Windows.Forms.TextBox();
            this.lblTipoFiltro   = new System.Windows.Forms.Label();
            this.cmbTipoFiltro   = new System.Windows.Forms.ComboBox();
            this.btnFiltrar      = new System.Windows.Forms.Button();
            this.dgvUsuarios     = new System.Windows.Forms.DataGridView();
            this.btnNuevo        = new System.Windows.Forms.Button();
            this.btnEditar       = new System.Windows.Forms.Button();
            this.btnToggleEstado = new System.Windows.Forms.Button();
            this.lblMensaje      = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text          = "Gestión de Usuarios";
            this.Size          = new System.Drawing.Size(960, 600);
            this.MinimumSize   = new System.Drawing.Size(860, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor     = System.Drawing.Color.White;
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load         += new System.EventHandler(this.FormUsuarios_Load);

            // TÍTULO
            this.lblTitulo.Text      = "Gestión de Usuarios";
            this.lblTitulo.Location  = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size      = new System.Drawing.Size(380, 36);
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = TemaManager.TextoPrincipal;

            // BARRA DE FILTROS
            int yF = 66; int h = 30;

            this.lblBuscar.Text     = "Buscar";
            this.lblBuscar.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBuscar.Size     = new System.Drawing.Size(60, 16);
            this.lblBuscar.Font     = new System.Drawing.Font("Segoe UI", 8F);

            this.txtBuscar.Location    = new System.Drawing.Point(20, yF);
            this.txtBuscar.Size        = new System.Drawing.Size(220, h);
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Text        = "Buscar usuario...";
            this.txtBuscar.ForeColor   = TemaManager.TextoMuted;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter       += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave       += new System.EventHandler(this.txtBuscar_Leave);

            this.lblTipoFiltro.Text     = "Tipo";
            this.lblTipoFiltro.Location = new System.Drawing.Point(252, yF - 18);
            this.lblTipoFiltro.Size     = new System.Drawing.Size(60, 16);
            this.lblTipoFiltro.Font     = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbTipoFiltro.Location     = new System.Drawing.Point(252, yF);
            this.cmbTipoFiltro.Size         = new System.Drawing.Size(160, h);
            this.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFiltro.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoFiltro.Items.AddRange(new object[] {
                "Todos", "docente", "estudiante", "administrativo", "iglesia" });
            this.cmbTipoFiltro.SelectedIndex = 0;

            this.btnFiltrar.Text     = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(424, yF);
            this.btnFiltrar.Size     = new System.Drawing.Size(90, h);
            this.btnFiltrar.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFiltrar.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click   += new System.EventHandler(this.btnFiltrar_Click);

            // DATAGRIDVIEW
            this.dgvUsuarios.Location           = new System.Drawing.Point(20, 112);
            this.dgvUsuarios.Size               = new System.Drawing.Size(910, 390);
            this.dgvUsuarios.BackgroundColor     = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.RowHeadersVisible   = false;
            this.dgvUsuarios.AllowUserToAddRows  = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly            = true;
            this.dgvUsuarios.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect         = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.RowTemplate.Height  = 36;
            this.dgvUsuarios.CellBorderStyle     = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.CellPainting       += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsuarios_CellPainting);

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

            this.btnToggleEstado.Text     = "🔄 Cambiar Estado";
            this.btnToggleEstado.Location = new System.Drawing.Point(284, yB);
            this.btnToggleEstado.Size     = new System.Drawing.Size(165, 36);
            this.btnToggleEstado.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnToggleEstado.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnToggleEstado.Click   += new System.EventHandler(this.btnToggleEstado_Click);

            this.lblMensaje.Text      = "";
            this.lblMensaje.Location  = new System.Drawing.Point(464, yB + 8);
            this.lblMensaje.Size      = new System.Drawing.Size(460, 22);
            this.lblMensaje.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = TemaManager.TextoMuted;

            // AGREGAR AL FORM
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTipoFiltro);
            this.Controls.Add(this.cmbTipoFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnToggleEstado);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTipoFiltro;
        private System.Windows.Forms.ComboBox cmbTipoFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnToggleEstado;
        private System.Windows.Forms.Label lblMensaje;
    }
}
