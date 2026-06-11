using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Login - AmbientesUAB";
            AplicarTema();
        }

        private void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            lblTitulo.ForeColor = TemaManager.TextoPrincipal;
            lblUsuario.ForeColor = TemaManager.TextoSecundario;
            lblPassword.ForeColor = TemaManager.TextoSecundario;
            txtUsuario.BackColor = TemaManager.FondoGrid;
            txtUsuario.ForeColor = TemaManager.TextoPrincipal;
            txtPassword.BackColor = TemaManager.FondoGrid;
            txtPassword.ForeColor = TemaManager.TextoPrincipal;
            TemaManager.AplicarBoton(btnIngresar, TemaManager.Acento);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingresa usuario y contraseña.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        WHERE username = @user
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
                        string tipoUsuario = dr["tipo_usuario"].ToString();
                        bool esAdmin = Convert.ToBoolean(dr["es_admin"]);

                        dr.Close();

                        // Construir permisos según tipo_usuario
                        var permisos = new PermisosUsuario
                        {
                            VerHome = true,
                            VerNuevaReserva = true,
                            VerMisReservas = true,
                            VerAmbientes = esAdmin || tipoUsuario == "administrativo",
                            VerUsuarios = esAdmin || tipoUsuario == "administrativo",
                            VerReportes = esAdmin || tipoUsuario == "administrativo" || tipoUsuario == "docente",
                            TipoUsuario = tipoUsuario
                        };

                        new FormMenu(idUsuario, nombre, tipoUsuario, permisos).Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "❌ Acceso denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}