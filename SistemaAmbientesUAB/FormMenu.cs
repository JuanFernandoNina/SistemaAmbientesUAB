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

            // Estilo de botones del menú
            EstilarBoton(btnReservas);
            EstilarBoton(btnNuevaReserva);
            EstilarBoton(btnAmbientes);
            EstilarBoton(btnUsuarios);
            EstilarBoton(btnReportes);
            EstilarBoton(btnCerrarSesion);

            // Color especial para cerrar sesión
            btnCerrarSesion.BackColor = Color.FromArgb(180, 50, 50);
        }

        private void EstilarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(64, 64, 64);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Cursor = Cursors.Hand;

            // Efecto hover
            btn.MouseEnter += (s, e) =>
                ((Button)s).BackColor = Color.FromArgb(100, 100, 100);
            btn.MouseLeave += (s, e) =>
            {
                if ((Button)s == btnCerrarSesion)
                    ((Button)s).BackColor = Color.FromArgb(180, 50, 50);
                else
                    ((Button)s).BackColor = Color.FromArgb(64, 64, 64);
            };
        }

        // ── Navegación ──────────────────────────────────────

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            // FormNuevaReserva frm = new FormNuevaReserva(_idUsuario);
            // AbrirEnPanel(frm);
            MessageBox.Show("Próximamente: Nueva Reserva");
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            FormMisReservas frm = new FormMisReservas(_idUsuario);
            frm.ShowDialog();
            //MessageBox.Show("Próximamente: Mis Reservas");
        }

        private void btnAmbientes_Click(object sender, EventArgs e)
        {
            // FormAmbientes frm = new FormAmbientes();
            // AbrirEnPanel(frm);
            MessageBox.Show("Próximamente: Ambientes");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // FormUsuarios frm = new FormUsuarios();
            // AbrirEnPanel(frm);
            MessageBox.Show("Próximamente: Usuarios");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // FormReportes frm = new FormReportes();
            // AbrirEnPanel(frm);
            MessageBox.Show("Próximamente: Reportes");
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