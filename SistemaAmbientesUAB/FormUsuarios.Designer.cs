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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTipoFiltro = new System.Windows.Forms.Label();
            this.cmbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnToggleEstado = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────
            this.Text = "Gestión de Usuarios";
            this.Size = new System.Drawing.Size(960, 600);
            this.MinimumSize = new System.Drawing.Size(880, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormUsuarios_Load);

            // ── TÍTULO ────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Usuarios";
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size = new System.Drawing.Size(380, 36);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);

            // ── BARRA DE FILTROS ──────────────────────────────
            int yF = 78; int h = 30;

            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBuscar.Size = new System.Drawing.Size(60, 16);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.txtBuscar.Location = new System.Drawing.Point(20, yF);
            this.txtBuscar.Size = new System.Drawing.Size(220, h);
            this.txtBuscar.Text = "Buscar usuario...";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);

            this.lblTipoFiltro.Text = "Tipo";
            this.lblTipoFiltro.Location = new System.Drawing.Point(252, yF - 18);
            this.lblTipoFiltro.Size = new System.Drawing.Size(60, 16);
            this.lblTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbTipoFiltro.Location = new System.Drawing.Point(252, yF);
            this.cmbTipoFiltro.Size = new System.Drawing.Size(160, h);
            this.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFiltro.Items.AddRange(new object[] { "Todos", "docente", "estudiante", "administrativo", "iglesia" });
            this.cmbTipoFiltro.SelectedIndex = 0;

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(424, yF);
            this.btnFiltrar.Size = new System.Drawing.Size(90, h);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── DATAGRIDVIEW RESPONSIVO ───────────────────────
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 122);
            // Bajamos la altura inicial a 340 (antes 370 o 380) para dejar una brecha libre abajo
            this.dgvUsuarios.Size = new System.Drawing.Size(904, 340);
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsuarios_CellPainting);
            this.dgvUsuarios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_CellMouseDown);

            // ── BOTONES INFERIORES Y MENSAJES ─────────────────
            // Colocamos los botones en la coordenada Y = 485 (justo 23 píxeles debajo de donde termina la tabla)
            // ── BARRA DE FILTROS Y BOTONES (TODO ARRIBA) ──────────────────────
            // ── BARRA DE FILTROS Y BOTONES (ARRIBA SIN ERROR CS0128) ──────────
            // Quitamos el 'int' porque las variables ya existen previamente en el código
            yF = 78;
            h = 30;

            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBuscar.Size = new System.Drawing.Size(60, 16);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.txtBuscar.Location = new System.Drawing.Point(20, yF);
            this.txtBuscar.Size = new System.Drawing.Size(180, h);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Text = "Buscar usuario...";
            this.txtBuscar.ForeColor = TemaManager.TextoMuted;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);

            this.lblTipoFiltro.Text = "Tipo";
            this.lblTipoFiltro.Location = new System.Drawing.Point(212, yF - 18);
            this.lblTipoFiltro.Size = new System.Drawing.Size(60, 16);
            this.lblTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbTipoFiltro.Location = new System.Drawing.Point(212, yF);
            this.cmbTipoFiltro.Size = new System.Drawing.Size(130, h);
            this.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoFiltro.Items.AddRange(new object[] { "Todos", "docente", "estudiante", "administrativo", "iglesia" });
            this.cmbTipoFiltro.SelectedIndex = 0;

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(354, yF);
            this.btnFiltrar.Size = new System.Drawing.Size(80, h);
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // UBICACIÓN DE LOS BOTONES DE ACCIÓN (Alineados arriba como en Eventos)
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(454, yF);
            this.btnNuevo.Size = new System.Drawing.Size(100, h);
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(564, yF);
            this.btnEditar.Size = new System.Drawing.Size(100, h);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnToggleEstado.Text = "Estado";
            this.btnToggleEstado.Location = new System.Drawing.Point(674, yF);
            this.btnToggleEstado.Size = new System.Drawing.Size(110, h);
            this.btnToggleEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnToggleEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleEstado.Click += new System.EventHandler(this.btnToggleEstado_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(794, yF);
            this.btnEliminar.Size = new System.Drawing.Size(100, h);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ── DATAGRIDVIEW RESPONSIVO ───────────────────────
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 130);
            this.dgvUsuarios.Size = new System.Drawing.Size(904, 400);
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsuarios_CellPainting);
            this.dgvUsuarios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_CellMouseDown);

            // ── LBLMENSAJE (Abajo a la derecha) ────────────────
            this.lblMensaje.Text = "";
            this.lblMensaje.Size = new System.Drawing.Size(324, 22);
            this.lblMensaje.Location = new System.Drawing.Point(600, 540);
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            // Rediseño Dinámico de Esquinas (Evita deformaciones al cambiar el tamaño)
            this.btnNuevo.SizeChanged += (s, e) => RedondearControlInterno(this.btnNuevo, 6);
            this.btnEditar.SizeChanged += (s, e) => RedondearControlInterno(this.btnEditar, 6);
            this.btnToggleEstado.SizeChanged += (s, e) => RedondearControlInterno(this.btnToggleEstado, 6);
            this.btnEliminar.SizeChanged += (s, e) => RedondearControlInterno(this.btnEliminar, 6);

            // ── AGREGAR AL FORM ──────────────────────────────
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
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblMensaje);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void RedondearControlInterno(System.Windows.Forms.Control ctrl, int radio)
        {
            var gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            gp.AddArc(ctrl.Width - (radio * 2), 0, radio * 2, radio * 2, 270, 90);
            gp.AddArc(ctrl.Width - (radio * 2), ctrl.Height - (radio * 2), radio * 2, radio * 2, 0, 90);
            gp.AddArc(0, ctrl.Height - (radio * 2), radio * 2, radio * 2, 90, 90);
            gp.CloseFigure();
            ctrl.Region = new System.Drawing.Region(gp);
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
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblMensaje;
    }
}