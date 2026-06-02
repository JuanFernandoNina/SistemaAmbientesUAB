using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios(string buscar = "", string tipo = "Todos")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string filtroBuscar = !string.IsNullOrWhiteSpace(buscar)
                        ? "AND (nombre_completo LIKE @buscar OR codigo LIKE @buscar)" : "";
                    string filtroTipo = tipo != "Todos" ? "AND tipo_usuario = @tipo" : "";

                    string query = $@"
                        SELECT
                            id_usuario      AS ID,
                            codigo          AS Código,
                            nombre_completo AS Nombre,
                            tipo_usuario    AS Tipo,
                            carrera_area    AS [Carrera/Área],
                            correo          AS Correo,
                            username        AS Usuario,
                            CASE WHEN es_admin = 1 THEN '✅' ELSE '❌' END AS Admin,
                            estado          AS Estado
                        FROM Usuario
                        WHERE 1=1
                        {filtroBuscar}
                        {filtroTipo}
                        ORDER BY nombre_completo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (!string.IsNullOrWhiteSpace(buscar))
                        cmd.Parameters.AddWithValue("@buscar", $"%{buscar}%");
                    if (tipo != "Todos")
                        cmd.Parameters.AddWithValue("@tipo", tipo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsuarios.DataSource = dt;

                    // Colorear según estado
                    foreach (DataGridViewRow row in dgvUsuarios.Rows)
                    {
                        string estado = row.Cells["Estado"].Value?.ToString();
                        row.DefaultCellStyle.ForeColor = estado == "activo"
                            ? System.Drawing.Color.FromArgb(20, 120, 20)
                            : System.Drawing.Color.Red;
                    }

                    lblMensaje.Text = $"Total: {dt.Rows.Count} usuario(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim(), cmbTipoFiltro.SelectedItem?.ToString() ?? "Todos");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormUsuarioDetalle frm = new FormUsuarioDetalle(0);
            frm.ShowDialog();
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["ID"].Value);
            FormUsuarioDetalle frm = new FormUsuarioDetalle(idUsuario);
            frm.ShowDialog();
            CargarUsuarios();
        }

        private void btnToggleEstado_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["ID"].Value);
            string estadoActual = dgvUsuarios.SelectedRows[0].Cells["Estado"].Value?.ToString();
            string nombre = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            string nuevoEstado = estadoActual == "activo" ? "inactivo" : "activo";

            var confirm = MessageBox.Show(
                $"¿Cambiar estado de '{nombre}' a '{nuevoEstado}'?",
                "Cambiar Estado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Usuario SET estado = @estado WHERE id_usuario = @id", con);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = $"✅ Usuario '{nombre}' ahora está {nuevoEstado}.";
                lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}