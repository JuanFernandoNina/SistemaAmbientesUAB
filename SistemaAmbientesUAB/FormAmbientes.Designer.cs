using System;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBloque = new System.Windows.Forms.Label();
            this.cmbBloque = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvAmbientes = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAmbientes)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "Gestión de Ambientes";
            this.Size = new System.Drawing.Size(1120, 650); // Se amplía el ancho inicial para acomodar la barra superior completa
            this.MinimumSize = new System.Drawing.Size(1040, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormAmbientes_Load);

            // TÍTULO
            this.lblTitulo.Text = "Gestión de Ambientes";
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Size = new System.Drawing.Size(380, 36);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);

            // BARRA DE FILTROS Y BUSCADOR (Alineación Y = 78)
            int yF = 78; int h = 30;

            this.lblBloque.Text = "Bloque";
            this.lblBloque.Location = new System.Drawing.Point(20, yF - 18);
            this.lblBloque.Size = new System.Drawing.Size(60, 16);
            this.lblBloque.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbBloque.Location = new System.Drawing.Point(20, yF);
            this.cmbBloque.Size = new System.Drawing.Size(130, h);
            this.cmbBloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblTipo.Text = "Tipo";
            this.lblTipo.Location = new System.Drawing.Point(162, yF - 18);
            this.lblTipo.Size = new System.Drawing.Size(60, 16);
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.cmbTipo.Location = new System.Drawing.Point(162, yF);
            this.cmbTipo.Size = new System.Drawing.Size(130, h);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "Todos", "aula", "laboratorio", "auditorio", "coliseo" });
            this.cmbTipo.SelectedIndex = 0;

            this.txtBuscar.Location = new System.Drawing.Point(304, yF);
            this.txtBuscar.Size = new System.Drawing.Size(170, h);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Text = "Buscar ambiente...";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(484, yF);
            this.btnFiltrar.Size = new System.Drawing.Size(80, h);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── BOTONES DE ACCIÓN (MOVIDOS ARRIBA AL LADO DE FILTRAR) ──
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(584, yF);
            this.btnNuevo.Size = new System.Drawing.Size(100, h);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.Location = new System.Drawing.Point(694, yF);
            this.btnEditar.Size = new System.Drawing.Size(100, h);
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnCambiarEstado.Text = "🔄 Estado"; // Texto optimizado para mantener coherencia estética
            this.btnCambiarEstado.Location = new System.Drawing.Point(804, yF);
            this.btnCambiarEstado.Size = new System.Drawing.Size(110, h);
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            this.btnEliminar.Text = "❌ Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(924, yF);
            this.btnEliminar.Size = new System.Drawing.Size(100, h);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ── DATAGRIDVIEW TOTALMENTE RESPONSIVO ──
            this.dgvAmbientes.Location = new System.Drawing.Point(20, 130);
            this.dgvAmbientes.Size = new System.Drawing.Size(1064, 420);
            // El Anchor en los 4 ejes permite que se estire al maximizar la pantalla
            this.dgvAmbientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAmbientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAmbientes_CellPainting);
            this.dgvAmbientes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAmbientes_CellMouseDown);

            // ── LBLMENSAJE (Abajo a la derecha) ──
            this.lblMensaje.Text = "";
            this.lblMensaje.Location = new System.Drawing.Point(770, 565);
            this.lblMensaje.Size = new System.Drawing.Size(314, 22);
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            // AGREGAR AL FORM CONTROLS
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
            this.Controls.Add(this.btnEliminar);
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
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblMensaje;
    }
}