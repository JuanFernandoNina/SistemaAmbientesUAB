using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = TemaManager.FondoPrincipal;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MostrarError("Ingresa usuario y contraseña.");
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                        SELECT id_usuario, nombre_completo, tipo_usuario, es_admin
                        FROM Usuario
                        WHERE username  = @user
                          AND password_hash = @pass
                          AND estado = 'activo'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@pass", password);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int idUsuario = Convert.ToInt32(dr["id_usuario"]);
                        string nombre = dr["nombre_completo"].ToString();
                        string tipoUsuario = dr["tipo_usuario"].ToString();   // estudiante | docente | iglesia | administrativo
                        bool esAdmin = Convert.ToBoolean(dr["es_admin"]);

                        dr.Close();

                        // Construir los permisos según tipo_usuario
                        var permisos = ResolverPermisos(tipoUsuario, esAdmin);

                        FormMenu menu = new FormMenu(idUsuario, nombre, tipoUsuario, permisos);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MostrarError("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
        }

        // Devuelve los permisos que tiene el rol
        private PermisosUsuario ResolverPermisos(string tipoUsuario, bool esAdmin)
        {
            return new PermisosUsuario
            {
                VerHome = true,
                VerNuevaReserva = true,
                VerMisReservas = true,
                VerAmbientes = esAdmin || tipoUsuario == "administrativo",
                VerUsuarios = esAdmin || tipoUsuario == "administrativo",
                VerReportes = esAdmin || tipoUsuario == "administrativo" || tipoUsuario == "docente",
                TipoUsuario = tipoUsuario
            };
        }

        private void MostrarError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        // Permitir Enter en los campos
        private void txtUsuario_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter) txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter) btnIngresar_Click(sender, e);
        }
    }

    // ── Clase de permisos ──────────────────────────────────────
    public class PermisosUsuario
    {
        public bool VerHome;
        public bool VerNuevaReserva;
        public bool VerMisReservas;
        public bool VerAmbientes;
        public bool VerUsuarios;
        public bool VerReportes;
        public string TipoUsuario;  // estudiante | docente | iglesia | administrativo
    }
}