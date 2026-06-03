using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    public partial class FormMisReservas : Form
    {
        private int _idUsuario;

        public FormMisReservas(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            AplicarTema();
            CargarReservas("Todas");
        }

        private void AplicarTema()
        {
            this.BackColor = TemaManager.FondoPrincipal;
            TemaManager.AplicarLabel(lblTitulo);
            TemaManager.AplicarLabel(lblFiltro, true);
            TemaManager.AplicarLabel(lblEstado, true);
            TemaManager.AplicarGrid(dgvReservas);

            cmbFiltroEstado.BackColor = TemaManager.FondoGrid;
            cmbFiltroEstado.ForeColor = TemaManager.TextoPrincipal;

            TemaManager.AplicarBoton(btnCancelar, System.Drawing.Color.FromArgb(180, 40, 40));
            TemaManager.AplicarBoton(btnActualizar, TemaManager.AcentoOscuro);
        }

        private void CargarReservas(string filtro)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string where = filtro == "Todas" ? "" : "AND r.estado = @estado";
                    string query = $@"
                        SELECT
                            r.id_reserva          AS ID,
                            a.codigo              AS Ambiente,
                            b.nombre              AS Bloque,
                            a.tipo                AS Tipo,
                            r.fecha_inicio        AS Fecha,
                            r.hora_inicio         AS [Hora Inicio],
                            r.hora_fin            AS [Hora Fin],
                            r.motivo              AS Motivo,
                            r.cantidad_asistentes AS Asistentes,
                            r.estado              AS Estado
                        FROM Reserva r
                        INNER JOIN Ambiente a ON r.id_ambiente = a.id_ambiente
                        INNER JOIN Bloque b   ON a.id_bloque   = b.id_bloque
                        WHERE r.id_usuario = @idUsuario {where}
                        ORDER BY r.fecha_inicio DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);
                    if (filtro != "Todas")
                        cmd.Parameters.AddWithValue("@estado", filtro);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReservas.DataSource = dt;

                    foreach (DataGridViewRow row in dgvReservas.Rows)
                    {
                        string estado = row.Cells["Estado"].Value?.ToString();
                        if (estado == "cancelada")
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
                        else if (estado == "finalizada")
                            row.DefaultCellStyle.ForeColor = TemaManager.TextoSecundario;
                        else
                            row.DefaultCellStyle.ForeColor = TemaManager.Acento;
                    }

                    lblEstado.Text = $"Total: {dt.Rows.Count} reserva(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reserva para cancelar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idReserva = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ID"].Value);
            string estado = dgvReservas.SelectedRows[0].Cells["Estado"].Value?.ToString();

            if (estado != "activa")
            {
                MessageBox.Show("Solo puedes cancelar reservas activas.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingresa el motivo de cancelación:", "Cancelar Reserva", "");
            if (string.IsNullOrWhiteSpace(motivo)) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_CancelarReserva", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_reserva", idReserva);
                    cmd.Parameters.AddWithValue("@id_usuario_cancela", _idUsuario);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Reserva cancelada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) =>
            CargarReservas(cmbFiltroEstado.SelectedItem.ToString());

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) =>
            CargarReservas(cmbFiltroEstado.SelectedItem.ToString());
    }
}