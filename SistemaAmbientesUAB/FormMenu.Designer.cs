namespace SistemaAmbientesUAB
{
    partial class FormMenu
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnAmbientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();

            // ── FORM ────────────────────────────────────────
            this.Text = "AmbientesUAB - Menú Principal";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.FormMenu_Load);

            // ── PANEL MENÚ (izquierdo) ───────────────────────
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Size = new System.Drawing.Size(200, 600);
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // ── LABEL nombre usuario ─────────────────────────
            this.lblNombreUsuario.Location = new System.Drawing.Point(0, 20);
            this.lblNombreUsuario.Size = new System.Drawing.Size(200, 50);
            this.lblNombreUsuario.Text = "👤 Bienvenido";
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── BOTONES ──────────────────────────────────────
            ConfigurarBoton(this.btnReservas, "📅  Mis Reservas", 80);
            ConfigurarBoton(this.btnNuevaReserva, "➕  Nueva Reserva", 140);
            ConfigurarBoton(this.btnAmbientes, "🏫  Ambientes", 200);
            ConfigurarBoton(this.btnUsuarios, "👥  Usuarios", 260);
            ConfigurarBoton(this.btnReportes, "📊  Reportes", 320);
            ConfigurarBoton(this.btnCerrarSesion, "🚪  Cerrar Sesión", 480);
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(160, 40, 40);

            // Eventos botones
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            this.btnAmbientes.Click += new System.EventHandler(this.btnAmbientes_Click);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // Agregar controles al panelMenu
            this.panelMenu.Controls.Add(this.lblNombreUsuario);
            this.panelMenu.Controls.Add(this.btnReservas);
            this.panelMenu.Controls.Add(this.btnNuevaReserva);
            this.panelMenu.Controls.Add(this.btnAmbientes);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);

            // ── PANEL CONTENIDO (derecho) ────────────────────
            this.panelContenido.Location = new System.Drawing.Point(200, 0);
            this.panelContenido.Size = new System.Drawing.Size(684, 562);
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── AGREGAR AL FORM ──────────────────────────────
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenido);
        }

        private void ConfigurarBoton(System.Windows.Forms.Button btn, string texto, int posY)
        {
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(0, posY);
            btn.Size = new System.Drawing.Size(200, 50);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        // Declaración de controles
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnAmbientes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}