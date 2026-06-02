using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormAmbientes : Form
    {
        public FormAmbientes()
        {
            InitializeComponent();
        }

        private void FormAmbientes_Load(object sender, EventArgs e)
        {
            CargarBloques();
            CargarAmbientes();
        }

        private void CargarBloques()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_bloque, nombre FROM Bloque ORDER BY nombre", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbBloque.Items.Clear();
                    cmbBloque.Items.Add(new { id = 0, nombre = "Todos" });

                    while (dr.Read())
                        cmbBloque.Items.Add(new { id = dr["id_bloque"], nombre = dr["nombre"].ToString() });

                    cmbBloque.DisplayMember = "nombre";
                    cmbBloque.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bloques: " + ex.Message);
            }
        }

        private void CargarAmbientes(int idBloque = 0, string tipo = "Todos")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string filtroBloque = idBloque > 0 ? "AND a.id_bloque = @idBloque" : "";
                    string filtroTipo = tipo != "Todos" ? "AND a.tipo = @tipo" : "";

                    string query = $@"
                        SELECT
                            a.id_ambiente       AS ID,
                            b.nombre            AS Bloque,
                            a.codigo            AS Código,
                            a.tipo              AS Tipo,
                            a.capacidad         AS Capacidad,
                            CASE WHEN a.tiene_proyector    = 1 THEN '✅' ELSE '❌' END AS Proyector,
                            CASE WHEN a.tiene_computadoras = 1 THEN '✅' ELSE '❌' END AS Computadoras,
                            CASE WHEN a.tiene_enchufes     = 1 THEN '✅' ELSE '❌' END AS Enchufes,
                            a.estado            AS Estado
                        FROM Ambiente a
                        INNER JOIN Bloque b ON a.id_bloque = b.id_bloque
                        WHERE 1=1
                        {filtroBloque}
                        {filtroTipo}
                        ORDER BY b.nombre, a.codigo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (idBloque > 0) cmd.Parameters.AddWithValue("@idBloque", idBloque);
                    if (tipo != "Todos") cmd.Parameters.AddWithValue("@tipo", tipo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAmbientes.DataSource = dt;

                    // Colorear según estado
                    foreach (DataGridViewRow row in dgvAmbientes.Rows)
                    {
                        string estado = row.Cells["Estado"].Value?.ToString();
                        if (estado == "mantenimiento")
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkOrange;
                        else if (estado == "inhabilitado")
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        else
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(20, 120, 20);
                    }

                    lblMensaje.Text = $"Total: {dt.Rows.Count} ambiente(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ambientes: " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idBloque = 0;
            dynamic selBloque = cmbBloque.SelectedItem;
            if (selBloque != null) idBloque = (int)selBloque.id;

            string tipo = cmbTipo.SelectedItem?.ToString() ?? "Todos";
            CargarAmbientes(idBloque, tipo);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAmbienteDetalle frm = new FormAmbienteDetalle(0);
            frm.ShowDialog();
            CargarAmbientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAmbientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ambiente para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAmbiente = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["ID"].Value);
            FormAmbienteDetalle frm = new FormAmbienteDetalle(idAmbiente);
            frm.ShowDialog();
            CargarAmbientes();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvAmbientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ambiente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAmbiente = Convert.ToInt32(dgvAmbientes.SelectedRows[0].Cells["ID"].Value);
            string estadoActual = dgvAmbientes.SelectedRows[0].Cells["Estado"].Value?.ToString();
            string codigo = dgvAmbientes.SelectedRows[0].Cells["Código"].Value?.ToString();

            // Determinar siguiente estado
            string nuevoEstado = estadoActual == "disponible" ? "mantenimiento"
                               : estadoActual == "mantenimiento" ? "inhabilitado"
                               : "disponible";

            var confirm = MessageBox.Show(
                $"¿Cambiar estado del ambiente {codigo} de '{estadoActual}' a '{nuevoEstado}'?",
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
                        "UPDATE Ambiente SET estado = @estado WHERE id_ambiente = @id", con);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", idAmbiente);
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = $"✅ Estado actualizado a '{nuevoEstado}'";
                lblMensaje.ForeColor = System.Drawing.Color.FromArgb(40, 120, 40);
                CargarAmbientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}