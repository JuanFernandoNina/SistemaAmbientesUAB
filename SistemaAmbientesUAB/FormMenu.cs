using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMenu : Form
    {
        private int _idUsuario;
        private string _nombre;
        private string _tipoUsuario;
        private PermisosUsuario _permisos;
        private Button _btnActivo;

        public FormMenu(int idUsuario, string nombre, string tipoUsuario, PermisosUsuario permisos)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _nombre = nombre;
            _tipoUsuario = tipoUsuario;
            _permisos = permisos;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            string inicial = _nombre.Length > 0 ? _nombre[0].ToString().ToUpper() : "U";
            lblAvatar.Text = inicial;
            lblNombreUsuario.Text = _nombre.Length > 20 ? _nombre.Substring(0, 20) + "…" : _nombre;

            ConfigurarBadgeRol();
            AplicarPermisos();
            AplicarTema();
            SetBtnActivo(btnHome);
            CargarFormulario(new FormHome(_idUsuario, _nombre));
        }

        private void ConfigurarBadgeRol()
        {
            switch (_tipoUsuario)
            {
                case "estudiante":
                    lblRolBadge.Text = "Estudiante";
                    lblRolBadge.ForeColor = Color.FromArgb(30, 64, 175);
                    lblRolBadge.BackColor = Color.FromArgb(219, 234, 254);
                    break;
                case "docente":
                    lblRolBadge.Text = "Docente";
                    lblRolBadge.ForeColor = Color.FromArgb(6, 95, 70);
                    lblRolBadge.BackColor = Color.FromArgb(209, 250, 229);
                    break;
                case "iglesia":
                    lblRolBadge.Text = "Iglesia";
                    lblRolBadge.ForeColor = Color.FromArgb(92, 45, 145);
                    lblRolBadge.BackColor = Color.FromArgb(237, 233, 254);
                    break;
                default:
                    lblRolBadge.Text = "Admin";
                    lblRolBadge.ForeColor = Color.FromArgb(146, 64, 14);
                    lblRolBadge.BackColor = Color.FromArgb(254, 243, 199);
                    break;
            }
            lblRolBadge.Visible = true;
        }

        private void AplicarPermisos()
        {
            btnNuevaReserva.Visible = _permisos.VerNuevaReserva;
            btnReservas.Visible = _permisos.VerMisReservas;
            btnAmbientes.Visible = _permisos.VerAmbientes;
            btnUsuarios.Visible = _permisos.VerUsuarios;
            btnReportes.Visible = _permisos.VerReportes;
        }

        public void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            panelMenu.BackColor = TemaManager.FondoMenu;
            panelContenido.BackColor = TemaManager.FondoContenido;
            panelSep.BackColor = TemaManager.TemaActual == TipoTema.Claro
                                        ? Color.FromArgb(20, 48, 90)
                                        : Color.FromArgb(14, 22, 40);

            lblAppName.ForeColor = Color.White;
            lblNombreUsuario.ForeColor = TemaManager.NavIcono;
            lblAvatar.BackColor = TemaManager.Acento;

            Button[] botones = { btnHome, btnReservas, btnNuevaReserva,
                                  btnAmbientes, btnUsuarios, btnReportes,
                                  btnTema, btnCerrarSesion };

            foreach (var btn in botones)
            {
                btn.BackColor = TemaManager.BotonMenu;
                btn.ForeColor = TemaManager.NavIcono;
                btn.FlatAppearance.BorderSize = 0;
                RegistrarHover(btn);
            }

            if (_btnActivo != null) AplicarActivo(_btnActivo);

            btnCerrarSesion.BackColor = TemaManager.TemaActual == TipoTema.Claro
                ? Color.FromArgb(185, 28, 28) : Color.FromArgb(127, 29, 29);
            btnCerrarSesion.ForeColor = Color.White;

            btnTema.BackColor = TemaManager.TemaActual == TipoTema.Claro
                ? Color.FromArgb(20, 48, 90) : Color.FromArgb(28, 36, 54);
            btnTema.ForeColor = Color.White;
            btnTema.Text = TemaManager.TemaActual == TipoTema.Claro
                ? "   \u25D1   Modo Oscuro"
                : "   \u263C   Modo Claro";
        }

        private void SetBtnActivo(Button btn)
        {
            if (_btnActivo != null)
            {
                _btnActivo.BackColor = TemaManager.BotonMenu;
                _btnActivo.ForeColor = TemaManager.NavIcono;
            }
            _btnActivo = btn;
            AplicarActivo(btn);
        }

        private void AplicarActivo(Button btn)
        {
            btn.BackColor = TemaManager.BotonActivo;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderColor = TemaManager.Acento;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void RegistrarHover(Button btn)
        {
            btn.MouseEnter -= OnEnter;
            btn.MouseLeave -= OnLeave;
            btn.MouseEnter += OnEnter;
            btn.MouseLeave += OnLeave;
        }

        private void OnEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnCerrarSesion || btn == btnTema || btn == _btnActivo) return;
            btn.BackColor = TemaManager.BotonHover;
            btn.ForeColor = Color.White;
        }

        private void OnLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnCerrarSesion)
            {
                btn.BackColor = TemaManager.TemaActual == TipoTema.Claro
                    ? Color.FromArgb(185, 28, 28) : Color.FromArgb(127, 29, 29);
                return;
            }
            if (btn == btnTema)
            {
                btn.BackColor = TemaManager.TemaActual == TipoTema.Claro
                    ? Color.FromArgb(20, 48, 90) : Color.FromArgb(28, 36, 54);
                return;
            }
            if (btn == _btnActivo) return;
            btn.BackColor = TemaManager.BotonMenu;
            btn.ForeColor = TemaManager.NavIcono;
        }

        private void CargarFormulario(Form frm)
        {
            panelContenido.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        { SetBtnActivo(btnHome); CargarFormulario(new FormHome(_idUsuario, _nombre)); }

        private void btnReservas_Click(object sender, EventArgs e)
        { SetBtnActivo(btnReservas); CargarFormulario(new FormMisReservas(_idUsuario, _permisos.EsAdmin)); }   // ← CAMBIADO

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        { SetBtnActivo(btnNuevaReserva); CargarFormulario(new FormNuevaReserva(_idUsuario, _permisos.EsAdmin)); }   // ← CAMBIADO

        private void btnAmbientes_Click(object sender, EventArgs e)
        { SetBtnActivo(btnAmbientes); CargarFormulario(new FormAmbientes()); }

        private void btnUsuarios_Click(object sender, EventArgs e)
        { SetBtnActivo(btnUsuarios); CargarFormulario(new FormUsuarios()); }

        private void btnReportes_Click(object sender, EventArgs e)
        { SetBtnActivo(btnReportes); CargarFormulario(new FormReportes()); }

        private void btnTema_Click(object sender, EventArgs e)
        {
            TemaManager.CambiarTema();
            AplicarTema();
            CargarFormulario(new FormHome(_idUsuario, _nombre));
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesión?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new FormLogin().Show();
                this.Close();
            }
        }
    }
}