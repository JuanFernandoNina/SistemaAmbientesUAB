using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormUsuarioDetalle : Form
    {
        private int _idUsuario;

        public FormUsuarioDetalle(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void FormUsuarioDetalle_Load(object sender, EventArgs e)
        {
            this.Text = _idUsuario == 0 ? "Nuevo Usuario" : "Editar Usuario";
            lblTitulo.Text = _idUsuario == 0 ? "➕ Nuevo Usuario" : "✏️ Editar Usuario";
            if (_idUsuario > 0) CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Usuario WHERE id_usuario = @id", con);
                    cmd.Parameters.AddWithValue("@id", _idUsuario);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtCodigo.Text = dr["codigo"].ToString();
                        txtNombre.Text = dr["nombre_completo"].ToString();
                        txtCarrera.Text = dr["carrera_area"].ToString();
                        txtCorreo.Text = dr["correo"].ToString();
                        txtTelefono.Text = dr["telefono"].ToString();
                        txtUsername.Text = dr["username"].ToString();
                        txtPassword.Text = dr["password_hash"].ToString();
                        cmbTipo.SelectedItem = dr["tipo_usuario"].ToString();
                        cmbEstado.SelectedItem = dr["estado"].ToString();
                        chkAdmin.Checked = Convert.ToBoolean(dr["es_admin"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Nombre, correo, usuario y contraseña son obligatorios.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = _idUsuario == 0
                        ? @"INSERT INTO Usuario (codigo, nombre_completo, tipo_usuario, carrera_area,
                                correo, telefono, username, password_hash, es_admin, estado)
                            VALUES (@codigo, @nombre, @tipo, @carrera,
                                @correo, @telefono, @username, @password, @admin, @estado)"
                        : @"UPDATE Usuario SET codigo=@codigo, nombre_completo=@nombre,
                                tipo_usuario=@tipo, carrera_area=@carrera, correo=@correo,
                                telefono=@telefono, username=@username, password_hash=@password,
                                es_admin=@admin, estado=@estado
                            WHERE id_usuario=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipo", cmbTipo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@carrera", txtCarrera.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin", chkAdmin.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());
                    if (_idUsuario > 0)
                        cmd.Parameters.AddWithValue("@id", _idUsuario);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Usuario guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}