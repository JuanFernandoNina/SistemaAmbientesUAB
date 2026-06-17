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
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnAmbientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnEventos = new System.Windows.Forms.Button();
            this.btnTema = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblRolBadge = new System.Windows.Forms.Label();
            this.panelSep = new System.Windows.Forms.Panel();

            // ── FORM ──────────────────────────────────────────
            this.Text = "AmbientesUAB";
            this.Size = new System.Drawing.Size(1160, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Load += new System.EventHandler(this.FormMenu_Load);

            // ── PANEL MENÚ ────────────────────────────────────
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Size = new System.Drawing.Size(220, 720);
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                   System.Windows.Forms.AnchorStyles.Left |
                                   System.Windows.Forms.AnchorStyles.Bottom;

            // ── APP NAME ──────────────────────────────────────
            this.lblAppName.Text = "AmbientesUAB";
            this.lblAppName.Location = new System.Drawing.Point(0, 18);
            this.lblAppName.Size = new System.Drawing.Size(220, 28);
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;

            // ── SEPARADOR ─────────────────────────────────────
            this.panelSep.Location = new System.Drawing.Point(20, 52);
            this.panelSep.Size = new System.Drawing.Size(180, 1);
            this.panelSep.BackColor = System.Drawing.Color.FromArgb(40, 60, 100);

            // ── AVATAR CÍRCULO ────────────────────────────────
            this.lblAvatar.Text = "A";
            this.lblAvatar.Location = new System.Drawing.Point(84, 64);
            this.lblAvatar.Size = new System.Drawing.Size(52, 52);
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── NOMBRE USUARIO ────────────────────────────────
            this.lblNombreUsuario.Text = "Usuario";
            this.lblNombreUsuario.Location = new System.Drawing.Point(0, 122);
            this.lblNombreUsuario.Size = new System.Drawing.Size(220, 22);
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.Transparent;

            // ── BADGE DE ROL ──────────────────────────────────
            this.lblRolBadge.Text = "";
            this.lblRolBadge.Location = new System.Drawing.Point(60, 148);
            this.lblRolBadge.Size = new System.Drawing.Size(100, 20);
            this.lblRolBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblRolBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRolBadge.Visible = false;

            // ── BOTONES MENÚ  (Primer botón desde y=178, incrementos de 46px) ──
            SetupBtn(this.btnHome, "   \u2302   Inicio", 178);
            SetupBtn(this.btnNuevaReserva, "   +   Nueva Reserva", 224);
            SetupBtn(this.btnReservas, "   \u25A6   Mis Reservas", 270);
            SetupBtn(this.btnAmbientes, "   \u25A3   Ambientes", 316);
            SetupBtn(this.btnUsuarios, "   \u25C9   Usuarios", 362);
            SetupBtn(this.btnReportes, "   \u25AA   Reportes", 408);
            SetupBtn(this.btnEventos, "   📅   Eventos", 454);

            // Posición inferior fija
            SetupBtn(this.btnTema, "   \u25D1   Modo Oscuro", 558);
            SetupBtn(this.btnCerrarSesion, "   \u2715   Cerrar Sesión", 618);

            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTema.BackColor = System.Drawing.Color.FromArgb(30, 50, 100);

            // ── EVENTOS ───────────────────────────────────────
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            this.btnAmbientes.Click += new System.EventHandler(this.btnAmbientes_Click);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.btnEventos.Click += new System.EventHandler(this.btnEventos_Click);
            this.btnTema.Click += new System.EventHandler(this.btnTema_Click);
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // ── AGREGAR AL PANEL MENÚ ─────────────────────────
            this.panelMenu.Controls.Add(this.lblAppName);
            this.panelMenu.Controls.Add(this.panelSep);
            this.panelMenu.Controls.Add(this.lblAvatar);
            this.panelMenu.Controls.Add(this.lblNombreUsuario);
            this.panelMenu.Controls.Add(this.lblRolBadge);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.btnNuevaReserva);
            this.panelMenu.Controls.Add(this.btnReservas);
            this.panelMenu.Controls.Add(this.btnAmbientes);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnEventos);
            this.panelMenu.Controls.Add(this.btnTema);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);

            // ── PANEL CONTENIDO ───────────────────────────────
            this.panelContenido.Location = new System.Drawing.Point(220, 0);
            this.panelContenido.Size = new System.Drawing.Size(924, 720);
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelContenido.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                         System.Windows.Forms.AnchorStyles.Left |
                                         System.Windows.Forms.AnchorStyles.Right |
                                         System.Windows.Forms.AnchorStyles.Bottom;

            // ── AGREGAR AL FORM ───────────────────────────────
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenido);
        }

        private void SetupBtn(System.Windows.Forms.Button btn, string texto, int posY)
        {
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(0, posY);
            btn.Size = new System.Drawing.Size(220, 46);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            btn.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelSep;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblRolBadge;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnAmbientes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnEventos;
        private System.Windows.Forms.Button btnTema;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}