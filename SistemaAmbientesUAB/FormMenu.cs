using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMenu : Form
    {
        private int _idUsuario;
        private string _nombre;
        private bool _esAdmin;

        public FormMenu(int idUsuario, string nombre, bool esAdmin)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _nombre = nombre;
            _esAdmin = esAdmin;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = "👤 " + _nombre;
            AplicarTema();
            CargarFormulario(new FormHome(_idUsuario, _nombre));
        }

        // ── TEMA ──────────────────────────────────────────────
        public void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            panelMenu.BackColor = TemaManager.FondoMenu;
            panelContenido.BackColor = TemaManager.FondoContenido;

            lblNombreUsuario.ForeColor = Color.White;
            lblNombreUsuario.BackColor = TemaManager.FondoMenu;

            // Estilo de todos los botones del menú
            Button[] botones = { btnHome, btnReservas, btnNuevaReserva,
                                  btnAmbientes, btnUsuarios, btnReportes,
                                  btnTema, btnCerrarSesion };

            foreach (var btn in botones)
            {
                btn.BackColor = TemaManager.BotonMenu;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }

            // Colores especiales
            btnCerrarSesion.BackColor = Color.FromArgb(160, 40, 40);
            btnTema.BackColor = TemaManager.TemaActual == TipoTema.Claro
                ? Color.FromArgb(50, 70, 120)
                : Color.FromArgb(80, 60, 20);
            btnTema.Text = TemaManager.TemaActual == TipoTema.Claro
                ? "🌙  Modo Oscuro"
                : "☀️  Modo Claro";

            // Registrar hover en todos
            foreach (var btn in botones)
                RegistrarHover(btn);
        }

        private void RegistrarHover(Button btn)
        {
            btn.MouseEnter -= OnBotonEnter;
            btn.MouseLeave -= OnBotonLeave;
            btn.MouseEnter += OnBotonEnter;
            btn.MouseLeave += OnBotonLeave;
        }

        private void OnBotonEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn != btnCerrarSesion && btn != btnTema)
                btn.BackColor = TemaManager.BotonHover;
        }

        private void OnBotonLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnCerrarSesion)
                btn.BackColor = Color.FromArgb(160, 40, 40);
            else if (btn == btnTema)
                btn.BackColor = TemaManager.TemaActual == TipoTema.Claro
                    ? Color.FromArgb(50, 70, 120)
                    : Color.FromArgb(80, 60, 20);
            else
                btn.BackColor = TemaManager.BotonMenu;
        }

        // ── NAVEGACIÓN ────────────────────────────────────────
        private void CargarFormulario(Form frm)
        {
            panelContenido.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormHome(_idUsuario, _nombre));

        private void btnReservas_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormMisReservas(_idUsuario));

        private void btnNuevaReserva_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormNuevaReserva(_idUsuario));

        private void btnAmbientes_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormAmbientes());

        private void btnUsuarios_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormUsuarios());

        private void btnReportes_Click(object sender, EventArgs e) =>
            CargarFormulario(new FormReportes());

        private void btnTema_Click(object sender, EventArgs e)
        {
            TemaManager.CambiarTema();
            AplicarTema();
            CargarFormulario(new FormHome(_idUsuario, _nombre));
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Seguro que deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                new Form1().Show();
                this.Close();
            }
        }
    }
}