using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormAmbienteDetalle : Form
    {
        private int _idAmbiente;

        public FormAmbienteDetalle(int idAmbiente)
        {
            InitializeComponent();
            _idAmbiente = idAmbiente;
        }

        private void FormAmbienteDetalle_Load(object sender, EventArgs e)
        {
            CargarBloques();
            this.Text = _idAmbiente == 0 ? "Nuevo Ambiente" : "Editar Ambiente";
            lblTitulo.Text = _idAmbiente == 0 ? "➕ Nuevo Ambiente" : "✏️ Editar Ambiente";

            if (_idAmbiente > 0) CargarDatos();
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
                    while (dr.Read())
                        cmbBloque.Items.Add(new { id = (int)dr["id_bloque"], nombre = dr["nombre"].ToString() });
                    cmbBloque.DisplayMember = "nombre";
                    if (cmbBloque.Items.Count > 0) cmbBloque.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Ambiente WHERE id_ambiente = @id", con);
                    cmd.Parameters.AddWithValue("@id", _idAmbiente);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtCodigo.Text = dr["codigo"].ToString();
                        nudCapacidad.Value = Convert.ToInt32(dr["capacidad"]);
                        chkProyector.Checked = Convert.ToBoolean(dr["tiene_proyector"]);
                        chkComputadoras.Checked = Convert.ToBoolean(dr["tiene_computadoras"]);
                        chkEnchufes.Checked = Convert.ToBoolean(dr["tiene_enchufes"]);
                        cmbTipo.SelectedItem = dr["tipo"].ToString();
                        cmbEstado.SelectedItem = dr["estado"].ToString();

                        int idBloque = Convert.ToInt32(dr["id_bloque"]);
                        foreach (var item in cmbBloque.Items)
                        {
                            dynamic d = item;
                            if (d.id == idBloque) { cmbBloque.SelectedItem = item; break; }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingresa el código del ambiente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selBloque = cmbBloque.SelectedItem;
            if (selBloque == null) { MessageBox.Show("Selecciona un bloque."); return; }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = _idAmbiente == 0
                        ? @"INSERT INTO Ambiente (id_bloque, codigo, tipo, capacidad,
                                tiene_proyector, tiene_computadoras, tiene_enchufes, estado)
                            VALUES (@bloque, @codigo, @tipo, @capacidad,
                                @proyector, @computadoras, @enchufes, @estado)"
                        : @"UPDATE Ambiente SET id_bloque=@bloque, codigo=@codigo, tipo=@tipo,
                                capacidad=@capacidad, tiene_proyector=@proyector,
                                tiene_computadoras=@computadoras, tiene_enchufes=@enchufes,
                                estado=@estado
                            WHERE id_ambiente=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@bloque", (int)selBloque.id);
                    cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipo", cmbTipo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@capacidad", (int)nudCapacidad.Value);
                    cmd.Parameters.AddWithValue("@proyector", chkProyector.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@computadoras", chkComputadoras.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@enchufes", chkEnchufes.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());
                    if (_idAmbiente > 0)
                        cmd.Parameters.AddWithValue("@id", _idAmbiente);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Ambiente guardado correctamente.", "Éxito",
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