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
            this.btnHome = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnAmbientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnTema = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();

            // ── FORM ────────────────────────────────────────
            this.Text = "AmbientesUAB - Menú Principal";
            this.Size = new System.Drawing.Size(1100, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.FormMenu_Load);

            // ── PANEL MENÚ ────────────────────────────────────
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Size = new System.Drawing.Size(210, 680);
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(30, 41, 30);

            // ── LABEL USUARIO ─────────────────────────────────
            this.lblNombreUsuario.Location = new System.Drawing.Point(0, 15);
            this.lblNombreUsuario.Size = new System.Drawing.Size(210, 55);
            this.lblNombreUsuario.Text = "👤 Bienvenido";
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.FromArgb(30, 41, 30);

            // ── SEPARADOR visual (label vacío como línea) ─────
            var sep = new System.Windows.Forms.Label();
            sep.Size = new System.Drawing.Size(170, 1);
            sep.Location = new System.Drawing.Point(20, 72);
            sep.BackColor = System.Drawing.Color.FromArgb(60, 80, 60);
            this.panelMenu.Controls.Add(sep);

            // ── BOTONES ───────────────────────────────────────
            ConfigurarBoton(this.btnHome, "🏠  Inicio", 85);
            ConfigurarBoton(this.btnReservas, "📅  Mis Reservas", 145);
            ConfigurarBoton(this.btnNuevaReserva, "➕  Nueva Reserva", 205);
            ConfigurarBoton(this.btnAmbientes, "🏫  Ambientes", 265);
            ConfigurarBoton(this.btnUsuarios, "👥  Usuarios", 325);
            ConfigurarBoton(this.btnReportes, "📊  Reportes", 385);
            ConfigurarBoton(this.btnTema, "🌙  Modo Oscuro", 480);
            ConfigurarBoton(this.btnCerrarSesion, "🚪  Cerrar Sesión", 560);

            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(160, 40, 40);
            this.btnTema.BackColor = System.Drawing.Color.FromArgb(50, 70, 120);

            // ── EVENTOS ───────────────────────────────────────
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            this.btnAmbientes.Click += new System.EventHandler(this.btnAmbientes_Click);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.btnTema.Click += new System.EventHandler(this.btnTema_Click);
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // ── AGREGAR AL PANEL MENÚ ─────────────────────────
            this.panelMenu.Controls.Add(this.lblNombreUsuario);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.btnReservas);
            this.panelMenu.Controls.Add(this.btnNuevaReserva);
            this.panelMenu.Controls.Add(this.btnAmbientes);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnTema);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);

            // ── PANEL CONTENIDO ───────────────────────────────
            this.panelContenido.Location = new System.Drawing.Point(210, 0);
            this.panelContenido.Size = new System.Drawing.Size(874, 680);
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);

            // ── AGREGAR AL FORM ───────────────────────────────
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenido);
        }

        private void ConfigurarBoton(System.Windows.Forms.Button btn, string texto, int posY)
        {
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(0, posY);
            btn.Size = new System.Drawing.Size(210, 50);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(30, 41, 30);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnAmbientes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnTema;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}